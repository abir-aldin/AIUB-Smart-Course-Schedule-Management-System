using AIUBCourseScheduler.DataAccess;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AIUBCourseScheduler.Services
{
    internal sealed class DatabaseImportResult
    {
        public int ImportId { get; init; }
        public int UniqueCourses { get; init; }
        public int CourseOfferings { get; init; }
        public int ClassMeetings { get; init; }
    }

    internal static class ExcelDatabaseImportService
    {
        public static async Task<DatabaseImportResult> ImportAsync(
            string filePath,
            ExcelValidationResult validationResult)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(
                    "The selected Excel file was not found."
                );
            }

            if (validationResult.ValidRows == 0)
            {
                throw new InvalidOperationException(
                    "The Excel file does not contain any valid rows."
                );
            }

            string fileHash = await CalculateFileHashAsync(filePath);

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            await connection.OpenAsync();

            using SqlTransaction transaction =
                connection.BeginTransaction();

            try
            {
                int termId = await GetOrCreateTermAsync(
                    connection,
                    transaction,
                    validationResult.TermName
                );

                await EnsureTermCanBeImportedAsync(
                    connection,
                    transaction,
                    termId,
                    fileHash
                );

                int importId = await CreateImportRecordAsync(
                    connection,
                    transaction,
                    termId,
                    filePath,
                    fileHash,
                    validationResult
                );

                Dictionary<string, int> courseIds = new Dictionary<string, int>(
                        StringComparer.OrdinalIgnoreCase
                    );

                int offeringCount = 0;
                int meetingCount = 0;

                IEnumerable<IGrouping<string, ExcelCourseRow>>
                    offeringGroups =
                        validationResult.ValidData.GroupBy(
                            row => row.SourceClassId,
                            StringComparer.OrdinalIgnoreCase
                        );

                foreach(IGrouping<string, ExcelCourseRow> group
                         in offeringGroups)
                {
                    ExcelCourseRow firstRow = group.First();

                    string courseKey =
                        $"{firstRow.CourseTitle}\u001F" +
                        firstRow.Department;

                    if (!courseIds.TryGetValue(
                        courseKey,
                        out int courseId))
                    {
                        courseId = await GetOrCreateCourseAsync(
                            connection,
                            transaction,
                            firstRow.CourseTitle,
                            firstRow.Department
                        );

                        courseIds[courseKey] = courseId;
                    }

                    int offeringId =
                        await CreateCourseOfferingAsync(
                            connection,
                            transaction,
                            termId,
                            courseId,
                            importId,
                            firstRow
                        );

                    offeringCount++;

                    foreach(ExcelCourseRow meetingRow in group)
                    {
                        await CreateClassMeetingAsync(
                            connection,
                            transaction,
                            offeringId,
                            meetingRow
                        );

                        meetingCount++;
                    }
                }

                await CompleteImportRecordAsync(
                    connection,
                    transaction,
                    importId
                );

                await transaction.CommitAsync();

                return new DatabaseImportResult
                {
                    ImportId = importId,
                    UniqueCourses = courseIds.Count,
                    CourseOfferings = offeringCount,
                    ClassMeetings = meetingCount
                };
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public static async Task<DataTable> GetImportHistoryAsync()
        {
            const string query = @"
                SELECT
                    EI.ImportId,
                    EI.FileName,
                    AT.TermName,
                    EI.UploadedBy,
                    EI.UploadedAt,
                    EI.ValidRows
                FROM dbo.ExcelImports AS EI
                INNER JOIN dbo.AcademicTerms AS AT
                    ON AT.TermId = EI.TermId
                WHERE EI.ImportStatus = 'Completed'
                ORDER BY EI.UploadedAt DESC;";

            DataTable historyTable = new DataTable();

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            using SqlCommand command =
                new SqlCommand(query, connection);

            await connection.OpenAsync();

            using SqlDataAdapter adapter =
                new SqlDataAdapter(command);

            adapter.Fill(historyTable);

            return historyTable;
        }

        public static async Task DeleteImportAsync(int importId)
        {
            if (importId <= 0)
            {
                throw new ArgumentException(
                    "A valid Import ID is required."
                );
            }

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            await connection.OpenAsync();

            using SqlTransaction transaction =
                connection.BeginTransaction();

            try
            {
                const string existsQuery = @"
            SELECT COUNT(1)
            FROM dbo.ExcelImports
            WHERE ImportId = @ImportId;";

                using (SqlCommand existsCommand =
                       new SqlCommand(
                           existsQuery,
                           connection,
                           transaction))
                {
                    existsCommand.Parameters
                        .Add("@ImportId", SqlDbType.Int)
                        .Value = importId;

                    int exists = Convert.ToInt32(
                        await existsCommand.ExecuteScalarAsync()
                    );

                    if (exists == 0)
                    {
                        throw new InvalidOperationException(
                            "The selected import history was not found."
                        );
                    }
                }

                // Schedule request এই import-এর section ব্যবহার করছে কি না
                const string requestCheckQuery = @"
            SELECT COUNT(1)
            FROM dbo.ScheduleRequestItems AS SRI
            INNER JOIN dbo.CourseOfferings AS CO
                ON CO.OfferingId = SRI.OfferingId
            WHERE CO.ImportId = @ImportId;";

                using (SqlCommand requestCheckCommand =
                       new SqlCommand(
                           requestCheckQuery,
                           connection,
                           transaction))
                {
                    requestCheckCommand.Parameters
                        .Add("@ImportId", SqlDbType.Int)
                        .Value = importId;

                    int requestCount = Convert.ToInt32(
                        await requestCheckCommand.ExecuteScalarAsync()
                    );

                    if (requestCount > 0)
                    {
                        throw new InvalidOperationException(
                            "This import cannot be deleted because " +
                            "one or more schedule requests are using its data."
                        );
                    }
                }

                const string deleteQuery = @"
            DECLARE @ImportedCourseIds TABLE
            (
                CourseId INT PRIMARY KEY
            );

            INSERT INTO @ImportedCourseIds (CourseId)
            SELECT DISTINCT CourseId
            FROM dbo.CourseOfferings
            WHERE ImportId = @ImportId;

            DELETE CM
            FROM dbo.ClassMeetings AS CM
            INNER JOIN dbo.CourseOfferings AS CO
                ON CO.OfferingId = CM.OfferingId
            WHERE CO.ImportId = @ImportId;

            DELETE FROM dbo.CourseOfferings
            WHERE ImportId = @ImportId;

            DELETE C
            FROM dbo.Courses AS C
            INNER JOIN @ImportedCourseIds AS IC
                ON IC.CourseId = C.CourseId
            WHERE NOT EXISTS
            (
                SELECT 1
                FROM dbo.CourseOfferings AS CO
                WHERE CO.CourseId = C.CourseId
            );

            DELETE FROM dbo.ExcelImports
            WHERE ImportId = @ImportId;";

                using SqlCommand deleteCommand =
                    new SqlCommand(
                        deleteQuery,
                        connection,
                        transaction
                    );

                deleteCommand.Parameters
                    .Add("@ImportId", SqlDbType.Int)
                    .Value = importId;

                await deleteCommand.ExecuteNonQueryAsync();

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        private static async Task<int> GetOrCreateTermAsync(
            SqlConnection connection,
            SqlTransaction transaction,
            string termName)
        {
            const string findQuery = @"
                SELECT TermId
                FROM dbo.AcademicTerms
                WHERE TermName = @TermName;";

            using (SqlCommand findCommand =
                   new SqlCommand(
                       findQuery,
                       connection,
                       transaction))
            {
                findCommand.Parameters
                    .Add(
                        "@TermName",
                        SqlDbType.NVarChar,
                        100
                    )
                    .Value = termName;

                object? existingId =
                    await findCommand.ExecuteScalarAsync();

                if (existingId != null &&
                    existingId != DBNull.Value)
                {
                    return Convert.ToInt32(existingId);
                }
            }

            const string insertQuery = @"
                INSERT INTO dbo.AcademicTerms
                (
                    TermName,
                    StartDate,
                    EndDate,
                    IsActive
                )
                OUTPUT INSERTED.TermId
                VALUES
                (
                    @TermName,
                    NULL,
                    NULL,
                    1
                );";

            using SqlCommand insertCommand = new SqlCommand(
                    insertQuery,
                    connection,
                    transaction
                );

            insertCommand.Parameters
                .Add(
                    "@TermName",
                    SqlDbType.NVarChar,
                    100
                )
                .Value = termName;

            object? insertedId = await insertCommand.ExecuteScalarAsync();

            return Convert.ToInt32(insertedId);
        }

        private static async Task EnsureTermCanBeImportedAsync(
            SqlConnection connection,
            SqlTransaction transaction,
            int termId,
            string currentFileHash)
        {
            const string query = @"
                SELECT FileHash
                FROM dbo.ExcelImports
                WHERE TermId = @TermId
                  AND ImportStatus = 'Completed';";

            using SqlCommand command = new SqlCommand(
                    query,
                    connection,
                    transaction
                );

            command.Parameters
                .Add("@TermId", SqlDbType.Int)
                .Value = termId;

            using SqlDataReader reader =
                await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                string previousHash =
                    reader.GetString(0).Trim();

                if (previousHash.Equals(
                    currentFileHash,
                    StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException(
                        "This exact Excel file has already been imported."
                    );
                }

                throw new InvalidOperationException(
                    "Course data for this semester has already " +
                    "been imported. Existing data was not changed."
                );
            }
        }

        private static async Task<int> CreateImportRecordAsync(
            SqlConnection connection,
            SqlTransaction transaction,
            int termId,
            string filePath,
            string fileHash,
            ExcelValidationResult validationResult)
        {
            const string query = @"
                INSERT INTO dbo.ExcelImports
                (
                    TermId,
                    FileName,
                    FileHash,
                    UploadedBy,
                    UploadedAt,
                    TotalRows,
                    ValidRows,
                    InvalidRows,
                    ImportStatus
                )
                OUTPUT INSERTED.ImportId
                VALUES
                (
                    @TermId,
                    @FileName,
                    @FileHash,
                    @UploadedBy,
                    SYSDATETIME(),
                    @TotalRows,
                    @ValidRows,
                    @InvalidRows,
                    'Pending'
                );";

            using SqlCommand command =
                new SqlCommand(
                    query,
                    connection,
                    transaction
                );

            command.Parameters
                .Add("@TermId", SqlDbType.Int)
                .Value = termId;

            command.Parameters
                .Add(
                    "@FileName",
                    SqlDbType.NVarChar,
                    255
                )
                .Value = LimitText(
                    Path.GetFileName(filePath),
                    255
                );

            command.Parameters
                .Add(
                    "@FileHash",
                    SqlDbType.Char,
                    64
                )
                .Value = fileHash;

            command.Parameters
                .Add(
                    "@UploadedBy",
                    SqlDbType.NVarChar,
                    100
                )
                .Value = GetUploadedBy();

            command.Parameters
                .Add("@TotalRows", SqlDbType.Int)
                .Value = validationResult.TotalRows;

            command.Parameters
                .Add("@ValidRows", SqlDbType.Int)
                .Value = validationResult.ValidRows;

            command.Parameters
                .Add("@InvalidRows", SqlDbType.Int)
                .Value = validationResult.InvalidRows;

            object? importId =
                await command.ExecuteScalarAsync();

            return Convert.ToInt32(importId);
        }

        private static async Task<int> GetOrCreateCourseAsync(
            SqlConnection connection,
            SqlTransaction transaction,
            string courseTitle,
            string department)
        {
            const string findQuery = @"
                SELECT CourseId
                FROM dbo.Courses
                WHERE CourseTitle = @CourseTitle
                  AND Department = @Department;";

            using (SqlCommand findCommand =
                   new SqlCommand(
                       findQuery,
                       connection,
                       transaction))
            {
                findCommand.Parameters
                    .Add(
                        "@CourseTitle",
                        SqlDbType.NVarChar,
                        255
                    )
                    .Value = courseTitle;

                findCommand.Parameters
                    .Add(
                        "@Department",
                        SqlDbType.NVarChar,
                        150
                    )
                    .Value = department;

                object? existingId =
                    await findCommand.ExecuteScalarAsync();

                if (existingId != null &&
                    existingId != DBNull.Value)
                {
                    return Convert.ToInt32(existingId);
                }
            }

            const string insertQuery = @"
                INSERT INTO dbo.Courses
                (
                    CourseCode,
                    CourseTitle,
                    Department,
                    IsActive
                )
                OUTPUT INSERTED.CourseId
                VALUES
                (
                    NULL,
                    @CourseTitle,
                    @Department,
                    1
                );";

            using SqlCommand insertCommand =
                new SqlCommand(
                    insertQuery,
                    connection,
                    transaction
                );

            insertCommand.Parameters
                .Add(
                    "@CourseTitle",
                    SqlDbType.NVarChar,
                    255
                )
                .Value = courseTitle;

            insertCommand.Parameters
                .Add(
                    "@Department",
                    SqlDbType.NVarChar,
                    150
                )
                .Value = department;

            object? insertedId =
                await insertCommand.ExecuteScalarAsync();

            return Convert.ToInt32(insertedId);
        }

        private static async Task<int> CreateCourseOfferingAsync(
            SqlConnection connection,
            SqlTransaction transaction,
            int termId,
            int courseId,
            int importId,
            ExcelCourseRow row)
        {
            const string query = @"
                INSERT INTO dbo.CourseOfferings
                (
                    TermId,
                    CourseId,
                    ImportId,
                    SourceClassId,
                    Section,
                    OfferingStatus,
                    Capacity,
                    EnrolledCount,
                    OfferingType,
                    IsActive
                )
                OUTPUT INSERTED.OfferingId
                VALUES
                (
                    @TermId,
                    @CourseId,
                    @ImportId,
                    @SourceClassId,
                    @Section,
                    @OfferingStatus,
                    @Capacity,
                    @EnrolledCount,
                    @OfferingType,
                    1
                );";

            using SqlCommand command =
                new SqlCommand(
                    query,
                    connection,
                    transaction
                );

            command.Parameters
                .Add("@TermId", SqlDbType.Int)
                .Value = termId;

            command.Parameters
                .Add("@CourseId", SqlDbType.Int)
                .Value = courseId;

            command.Parameters
                .Add("@ImportId", SqlDbType.Int)
                .Value = importId;

            command.Parameters
                .Add(
                    "@SourceClassId",
                    SqlDbType.NVarChar,
                    50
                )
                .Value = row.SourceClassId;

            command.Parameters
                .Add(
                    "@Section",
                    SqlDbType.NVarChar,
                    50
                )
                .Value = row.Section;

            command.Parameters
                .Add(
                    "@OfferingStatus",
                    SqlDbType.NVarChar,
                    30
                )
                .Value = row.Status;

            command.Parameters
                .Add("@Capacity", SqlDbType.Int)
                .Value = row.Capacity;

            command.Parameters
                .Add("@EnrolledCount", SqlDbType.Int)
                .Value = row.EnrolledCount;

            command.Parameters
                .Add(
                    "@OfferingType",
                    SqlDbType.NVarChar,
                    50
                )
                .Value = row.OfferingType;

            object? offeringId =
                await command.ExecuteScalarAsync();

            return Convert.ToInt32(offeringId);
        }

        private static async Task CreateClassMeetingAsync(
            SqlConnection connection,
            SqlTransaction transaction,
            int offeringId,
            ExcelCourseRow row)
        {
            const string query = @"
                INSERT INTO dbo.ClassMeetings
                (
                    OfferingId,
                    MeetingDay,
                    StartTime,
                    EndTime,
                    Room
                )
                VALUES
                (
                    @OfferingId,
                    @MeetingDay,
                    @StartTime,
                    @EndTime,
                    @Room
                );";

            using SqlCommand command =
                new SqlCommand(
                    query,
                    connection,
                    transaction
                );

            command.Parameters
                .Add("@OfferingId", SqlDbType.Int)
                .Value = offeringId;

            command.Parameters
                .Add(
                    "@MeetingDay",
                    SqlDbType.NVarChar,
                    20
                )
                .Value = row.MeetingDay;

            command.Parameters
                .Add("@StartTime", SqlDbType.Time)
                .Value = row.StartTime;

            command.Parameters
                .Add("@EndTime", SqlDbType.Time)
                .Value = row.EndTime;

            command.Parameters
                .Add(
                    "@Room",
                    SqlDbType.NVarChar,
                    100
                )
                .Value = row.Room;

            await command.ExecuteNonQueryAsync();
        }

        private static async Task CompleteImportRecordAsync(
            SqlConnection connection,
            SqlTransaction transaction,
            int importId)
        {
            const string query = @"
                UPDATE dbo.ExcelImports
                SET ImportStatus = 'Completed'
                WHERE ImportId = @ImportId;";

            using SqlCommand command =
                new SqlCommand(
                    query,
                    connection,
                    transaction
                );

            command.Parameters
                .Add("@ImportId", SqlDbType.Int)
                .Value = importId;

            await command.ExecuteNonQueryAsync();
        }

        private static async Task<string> CalculateFileHashAsync(
            string filePath)
        {
            await using FileStream stream =
                File.OpenRead(filePath);

            byte[] hash =
                await SHA256.HashDataAsync(stream);

            return Convert.ToHexString(hash);
        }

        private static string GetUploadedBy()
        {
            string uploadedBy =
                !string.IsNullOrWhiteSpace(UserSession.Email)
                    ? UserSession.Email
                    : UserSession.FullName;

            if (string.IsNullOrWhiteSpace(uploadedBy))
            {
                uploadedBy = "Unknown Admin";
            }

            return LimitText(uploadedBy, 100);
        }

        private static string LimitText(
            string value,
            int maximumLength)
        {
            if (value.Length <= maximumLength)
            {
                return value;
            }

            return value.Substring(0, maximumLength);
        }
    }
}