using Microsoft.Data.SqlClient;
using AIUBCourseScheduler.Models;

namespace AIUBCourseScheduler.DataAccess
{
    public static class ScheduleRepository
    {

        public static bool SaveGeneratedSchedules(
            List<GeneratedSchedule> schedules,
            int studentUserId)
        {
            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            using SqlTransaction transaction =
                connection.BeginTransaction();

            try
            {
                foreach (var schedule in schedules)
                {
                    string hash = GenerateScheduleHash(schedule);


                    // Duplicate check
                    string checkQuery = @"
                        SELECT COUNT(*)
                        FROM SavedSchedules
                        WHERE StudentUserId = @StudentUserId
                        AND ScheduleHash = @ScheduleHash
                    ";


                    using SqlCommand checkCommand =
                        new SqlCommand(
                            checkQuery,
                            connection,
                            transaction);


                    checkCommand.Parameters.AddWithValue(
                        "@StudentUserId",
                        studentUserId);

                    checkCommand.Parameters.AddWithValue(
                        "@ScheduleHash",
                        hash);


                    int exists =
                        (int)checkCommand.ExecuteScalar();


                    if (exists > 0)
                    {
                        continue;
                    }



                    // Insert SavedSchedules

                    string insertScheduleQuery = @"
                        INSERT INTO SavedSchedules
                        (
                            StudentUserId,
                            ScheduleName,
                            Status,
                            ScheduleHash
                        )
                        OUTPUT INSERTED.SavedScheduleId
                        VALUES
                        (
                            @StudentUserId,
                            @ScheduleName,
                            'Draft',
                            @ScheduleHash
                        )
                    ";


                    using SqlCommand insertScheduleCommand =
                        new SqlCommand(
                            insertScheduleQuery,
                            connection,
                            transaction);


                    insertScheduleCommand.Parameters.AddWithValue(
                        "@StudentUserId",
                        studentUserId);


                    insertScheduleCommand.Parameters.AddWithValue(
                        "@ScheduleName",
                        $"Schedule {schedules.IndexOf(schedule) + 1}");


                    insertScheduleCommand.Parameters.AddWithValue(
                        "@ScheduleHash",
                        hash);



                    int savedScheduleId =
                        (int)insertScheduleCommand.ExecuteScalar();



                    // Insert details

                    foreach (var offering in schedule.Offerings)
                    {
                        foreach (var meeting in offering.Meetings)
                        {

                            string detailQuery = @"
                                INSERT INTO SavedScheduleDetails
                                (
                                    SavedScheduleId,
                                    CourseId,
                                    Section,
                                    Day,
                                    StartTime,
                                    EndTime,
                                    Room
                                )
                                VALUES
                                (
                                    @SavedScheduleId,
                                    @CourseId,
                                    @Section,
                                    @Day,
                                    @StartTime,
                                    @EndTime,
                                    @Room
                                )
                            ";


                            using SqlCommand detailCommand =
                                new SqlCommand(
                                    detailQuery,
                                    connection,
                                    transaction);


                            detailCommand.Parameters.AddWithValue(
                                "@SavedScheduleId",
                                savedScheduleId);


                            detailCommand.Parameters.AddWithValue(
                                "@CourseId",
                                offering.CourseId);


                            detailCommand.Parameters.AddWithValue(
                                "@Section",
                                offering.Section);


                            detailCommand.Parameters.AddWithValue(
                                    "@Day",
                                        meeting.MeetingDay);


                            detailCommand.Parameters.AddWithValue(
                                "@StartTime",
                                meeting.StartTime);


                            detailCommand.Parameters.AddWithValue(
                                "@EndTime",
                                meeting.EndTime);


                            detailCommand.Parameters.AddWithValue(
                                "@Room",
                                (object?)meeting.Room ?? DBNull.Value);


                            detailCommand.ExecuteNonQuery();

                        }
                    }
                }


                transaction.Commit();

                return true;
            }
            catch
            {
                transaction.Rollback();

                throw;
            }
        }

        public static List<SavedScheduleDetailViewModel>
    GetScheduleDetails(int savedScheduleId)
        {
            List<SavedScheduleDetailViewModel> details =
                new List<SavedScheduleDetailViewModel>();


            using SqlConnection connection =
                DatabaseConnection.GetConnection();


            connection.Open();


            string query = @"
        SELECT
            C.CourseCode,
            C.CourseTitle,
            SSD.Section,
            SSD.Day,
            SSD.StartTime,
            SSD.EndTime,
            SSD.Room

        FROM SavedScheduleDetails SSD

        INNER JOIN Courses C
            ON SSD.CourseId = C.CourseId

        WHERE SSD.SavedScheduleId = @SavedScheduleId

        ORDER BY
            SSD.Day,
            SSD.StartTime
    ";


            using SqlCommand command =
                new SqlCommand(query, connection);


            command.Parameters.AddWithValue(
                "@SavedScheduleId",
                savedScheduleId);


            using SqlDataReader reader =
                command.ExecuteReader();


            while (reader.Read())
            {
                details.Add(
                    new SavedScheduleDetailViewModel
                    {
                        CourseCode = reader.IsDBNull(0)
                                        ? ""
                                        : reader.GetString(0),

                                                 CourseTitle = reader.IsDBNull(1)
                                        ? ""
                                        : reader.GetString(1),

                                                 Section = reader.IsDBNull(2)
                                        ? ""
                                        : reader.GetString(2),

                                                 Day = reader.IsDBNull(3)
                                        ? ""
                                        : reader.GetString(3),

                        StartTime = reader.GetTimeSpan(4),

                        EndTime = reader.GetTimeSpan(5),

                        Room = reader.IsDBNull(6)
                            ? ""
                            : reader.GetString(6)
                    }
                );
            }


            return details;
        }

        public static List<SavedScheduleViewModel>
    GetStudentSavedSchedules(int studentUserId)
        {
            List<SavedScheduleViewModel> schedules =
                new List<SavedScheduleViewModel>();


            using SqlConnection connection =
                DatabaseConnection.GetConnection();


            connection.Open();


            string query = @"
        SELECT
            SS.SavedScheduleId,
            SS.ScheduleName,
            SS.Status,
            SS.CreatedAt,
            COUNT(SSD.SavedScheduleDetailId) AS CourseCount

        FROM SavedSchedules SS

        LEFT JOIN SavedScheduleDetails SSD
            ON SS.SavedScheduleId =
               SSD.SavedScheduleId

        WHERE SS.StudentUserId = @StudentUserId

        GROUP BY
            SS.SavedScheduleId,
            SS.ScheduleName,
            SS.Status,
            SS.CreatedAt

        ORDER BY SS.CreatedAt DESC
    ";


            using SqlCommand command =
                new SqlCommand(
                    query,
                    connection);


            command.Parameters.AddWithValue(
                "@StudentUserId",
                studentUserId);


            using SqlDataReader reader =
                command.ExecuteReader();


            while (reader.Read())
            {
                schedules.Add(
                    new SavedScheduleViewModel
                    {
                        SavedScheduleId =
                            reader.GetInt32(0),

                        ScheduleName =
                            reader.GetString(1),

                        Status =
                            reader.GetString(2),

                        CreatedAt =
                            reader.GetDateTime(3),

                        CourseCount =
                            reader.GetInt32(4)
                    }
                );
            }


            return schedules;
        }

        public static bool DeleteSavedSchedule(int savedScheduleId)
        {
            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            using SqlTransaction transaction =
                connection.BeginTransaction();

            try
            {
                // Check status first
                string checkQuery = @"
            SELECT Status
            FROM SavedSchedules
            WHERE SavedScheduleId = @SavedScheduleId
        ";


                string status = "";

                using (SqlCommand checkCommand =
                    new SqlCommand(checkQuery, connection, transaction))
                {
                    checkCommand.Parameters.AddWithValue(
                        "@SavedScheduleId",
                        savedScheduleId);

                    object result = checkCommand.ExecuteScalar();

                    if (result == null)
                    {
                        return false;
                    }

                    status = result.ToString()!;
                }


                // Only Draft can be deleted
                if (status != "Draft")
                {
                    return false;
                }



                // Delete details first
                string deleteDetailsQuery = @"
            DELETE FROM SavedScheduleDetails
            WHERE SavedScheduleId = @SavedScheduleId
        ";


                using (SqlCommand detailCommand =
                    new SqlCommand(deleteDetailsQuery, connection, transaction))
                {
                    detailCommand.Parameters.AddWithValue(
                        "@SavedScheduleId",
                        savedScheduleId);

                    detailCommand.ExecuteNonQuery();
                }



                // Delete main schedule
                string deleteScheduleQuery = @"
            DELETE FROM SavedSchedules
            WHERE SavedScheduleId = @SavedScheduleId
        ";


                using (SqlCommand scheduleCommand =
                    new SqlCommand(deleteScheduleQuery, connection, transaction))
                {
                    scheduleCommand.Parameters.AddWithValue(
                        "@SavedScheduleId",
                        savedScheduleId);

                    scheduleCommand.ExecuteNonQuery();
                }


                transaction.Commit();

                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public static bool SubmitScheduleForApproval(
    int savedScheduleId,
    int studentUserId)
        {
            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            using SqlTransaction transaction =
                connection.BeginTransaction();

            try
            {
                // Check existing Pending / Approved request
                string checkQuery = @"
            SELECT COUNT(*)
            FROM ScheduleRequests
            WHERE StudentUserId = @StudentUserId
            AND RequestStatus IN ('Pending','Approved')
        ";

                using SqlCommand checkCommand =
                    new SqlCommand(
                        checkQuery,
                        connection,
                        transaction);

                checkCommand.Parameters.AddWithValue(
                    "@StudentUserId",
                    studentUserId);


                int existing =
                    (int)checkCommand.ExecuteScalar();


                if (existing > 0)
                {
                    return false;
                }



                // Get schedule name
                string scheduleNameQuery = @"
            SELECT ScheduleName
            FROM SavedSchedules
            WHERE SavedScheduleId = @SavedScheduleId
        ";


                string scheduleName = "";


                using (SqlCommand nameCommand =
                    new SqlCommand(
                        scheduleNameQuery,
                        connection,
                        transaction))
                {
                    nameCommand.Parameters.AddWithValue(
                        "@SavedScheduleId",
                        savedScheduleId);


                    scheduleName =
                        nameCommand.ExecuteScalar()
                        ?.ToString() ?? "";
                }



                // Insert request

                string insertQuery = @"
                                        INSERT INTO ScheduleRequests
                                        (
                                            StudentUserId,
                                            TermId,
                                            ScheduleName,
                                            SavedScheduleId
                                        )
                                        VALUES
                                        (
                                            @StudentUserId,
                                            @TermId,
                                            @ScheduleName,
                                            @SavedScheduleId
                                        )";


                using SqlCommand insertCommand =
                    new SqlCommand(
                        insertQuery,
                        connection,
                        transaction);


                insertCommand.Parameters.AddWithValue(
                    "@StudentUserId",
                    studentUserId);

                insertCommand.Parameters.AddWithValue(
                    "@ScheduleName",
                    scheduleName);

                insertCommand.Parameters.AddWithValue(
                    "@SavedScheduleId",
                    savedScheduleId);

                insertCommand.Parameters.AddWithValue(
                                "@TermId",
                                1
                            );


                insertCommand.ExecuteNonQuery();



                // Update saved schedule status

                string updateQuery = @"
            UPDATE SavedSchedules
            SET Status = 'Pending'
            WHERE SavedScheduleId = @SavedScheduleId
        ";


                using SqlCommand updateCommand =
                    new SqlCommand(
                        updateQuery,
                        connection,
                        transaction);


                updateCommand.Parameters.AddWithValue(
                    "@SavedScheduleId",
                    savedScheduleId);


                updateCommand.ExecuteNonQuery();



                transaction.Commit();

                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public static List<ScheduleRequestViewModel> GetAllScheduleRequests()
        {
            List<ScheduleRequestViewModel> requests =
                new List<ScheduleRequestViewModel>();

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            string query = @"
        SELECT
            SR.RequestId,
            SR.StudentUserId,
            U.FullName,
            SR.SavedScheduleId,
            SR.ScheduleName,
            SR.RequestStatus,
            SR.SubmittedAt,
            SR.AdminComment

        FROM ScheduleRequests SR

        INNER JOIN Users U
            ON SR.StudentUserId = U.UserId

        ORDER BY SR.SubmittedAt DESC
    ";


            using SqlCommand command =
                new SqlCommand(query, connection);


            using SqlDataReader reader =
                command.ExecuteReader();


            while (reader.Read())
            {
                requests.Add(
                    new ScheduleRequestViewModel
                    {
                        RequestId = reader.GetInt32(0),

                        StudentUserId = reader.GetInt32(1),

                        StudentName =
                            reader.GetString(2),

                        SavedScheduleId =
                            reader.GetInt32(3),

                        ScheduleName =
                            reader.GetString(4),

                        RequestStatus =
                            reader.GetString(5),

                        SubmittedAt =
                            reader.GetDateTime(6),

                        AdminComment =
                            reader.IsDBNull(7)
                            ? ""
                            : reader.GetString(7)
                    });
            }


            return requests;
        }

        public static List<ScheduleRequestViewModel> GetStudentScheduleRequests(
    int studentUserId)
        {
            List<ScheduleRequestViewModel> requests =
                new List<ScheduleRequestViewModel>();

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();


            string query = @"
        SELECT
            SR.RequestId,
            SR.StudentUserId,
            U.FullName,
            SR.SavedScheduleId,
            SR.ScheduleName,
            SR.RequestStatus,
            SR.SubmittedAt,
            SR.AdminComment

        FROM ScheduleRequests SR

        INNER JOIN Users U
            ON SR.StudentUserId = U.UserId

        WHERE SR.StudentUserId = @StudentUserId

        ORDER BY SR.SubmittedAt DESC
    ";


            using SqlCommand command =
                new SqlCommand(query, connection);


            command.Parameters.AddWithValue(
                "@StudentUserId",
                studentUserId);


            using SqlDataReader reader =
                command.ExecuteReader();


            while (reader.Read())
            {
                requests.Add(
                    new ScheduleRequestViewModel
                    {
                        RequestId = reader.GetInt32(0),

                        StudentUserId = reader.GetInt32(1),

                        StudentName =
                            reader.GetString(2),

                        SavedScheduleId =
                            reader.GetInt32(3),

                        ScheduleName =
                            reader.GetString(4),

                        RequestStatus =
                            reader.GetString(5),

                        SubmittedAt =
                            reader.GetDateTime(6),

                        AdminComment =
                            reader.IsDBNull(7)
                            ? ""
                            : reader.GetString(7)
                    });
            }


            return requests;
        }



        public static bool ApproveScheduleRequest(
    int requestId,
    int adminId)
        {
            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();


            using SqlTransaction transaction =
                connection.BeginTransaction();


            try
            {

                // Check section capacity before approval

                string capacityCheckQuery = @"
SELECT COUNT(*)
FROM SavedScheduleDetails SSD

INNER JOIN CourseOfferings CO
ON SSD.CourseId = CO.CourseId
AND SSD.Section = CO.Section

WHERE SSD.SavedScheduleId =
(
    SELECT SavedScheduleId
    FROM ScheduleRequests
    WHERE RequestId = @RequestId
)

AND ISNULL(CO.EnrolledCount,0) >= CO.Capacity
";


                using SqlCommand capacityCommand =
                    new SqlCommand(
                        capacityCheckQuery,
                        connection,
                        transaction);


                capacityCommand.Parameters.AddWithValue(
                    "@RequestId",
                    requestId);


                int fullSections =
                    (int)capacityCommand.ExecuteScalar();


                if (fullSections > 0)
                {
                    return false;
                }



                // Update request status

                string updateRequest = @"
UPDATE ScheduleRequests
SET
    RequestStatus='Approved',
    ReviewedAt=SYSUTCDATETIME(),
    ReviewedByUserId=@AdminId

WHERE RequestId=@RequestId
";


                using SqlCommand cmd =
                    new SqlCommand(
                        updateRequest,
                        connection,
                        transaction);


                cmd.Parameters.AddWithValue(
                    "@AdminId",
                    adminId);

                cmd.Parameters.AddWithValue(
                    "@RequestId",
                    requestId);


                cmd.ExecuteNonQuery();




                // Update saved schedule status

                string updateSchedule = @"
UPDATE SavedSchedules
SET Status='Approved'

WHERE SavedScheduleId =
(
    SELECT SavedScheduleId
    FROM ScheduleRequests
    WHERE RequestId=@RequestId
)
";


                using SqlCommand cmd2 =
                    new SqlCommand(
                        updateSchedule,
                        connection,
                        transaction);


                cmd2.Parameters.AddWithValue(
                    "@RequestId",
                    requestId);


                cmd2.ExecuteNonQuery();




                // Increase section enrolled count

                string updateEnrollment = @"
UPDATE CourseOfferings
SET EnrolledCount = ISNULL(EnrolledCount,0) + 1

WHERE OfferingId IN
(
    SELECT CO.OfferingId
    FROM SavedScheduleDetails SSD

    INNER JOIN CourseOfferings CO
    ON SSD.CourseId = CO.CourseId
    AND SSD.Section = CO.Section

    WHERE SSD.SavedScheduleId =
    (
        SELECT SavedScheduleId
        FROM ScheduleRequests
        WHERE RequestId = @RequestId
    )
)
";


                using SqlCommand cmd3 =
                    new SqlCommand(
                        updateEnrollment,
                        connection,
                        transaction);


                cmd3.Parameters.AddWithValue(
                    "@RequestId",
                    requestId);


                cmd3.ExecuteNonQuery();



                transaction.Commit();

                return true;

            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }




        public static bool RejectScheduleRequest(
            int requestId,
            int adminId,
            string comment)
        {
            using SqlConnection connection =
                DatabaseConnection.GetConnection();


            connection.Open();


            string query = @"
        UPDATE ScheduleRequests

        SET
            RequestStatus='Rejected',
            ReviewedAt=SYSUTCDATETIME(),
            ReviewedByUserId=@AdminId,
            AdminComment=@Comment

        WHERE RequestId=@RequestId
    ";


            using SqlCommand command =
                new SqlCommand(query, connection);


            command.Parameters.AddWithValue(
                "@AdminId",
                adminId);


            command.Parameters.AddWithValue(
                "@Comment",
                comment);


            command.Parameters.AddWithValue(
                "@RequestId",
                requestId);


            return command.ExecuteNonQuery() > 0;
        }

        public static List<SavedScheduleDetailViewModel> GetRequestCourses(
    int savedScheduleId)
        {
            List<SavedScheduleDetailViewModel> courses =
                new List<SavedScheduleDetailViewModel>();

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();


            string query = @"
                    SELECT 
    CourseTitle,
    Section,
    Day,
    StartTime,
    EndTime,
    Room
FROM
(
    SELECT DISTINCT
        C.CourseTitle,
        SSD.Section,
        SSD.Day,
        SSD.StartTime,
        SSD.EndTime,
        SSD.Room
    FROM SavedScheduleDetails SSD
    JOIN Courses C
    ON SSD.CourseId = C.CourseId
    WHERE SSD.SavedScheduleId = @SavedScheduleId
) AS Result

ORDER BY StartTime

    ";


            using SqlCommand command =
                new SqlCommand(query, connection);


            command.Parameters.AddWithValue(
                "@SavedScheduleId",
                savedScheduleId);


            using SqlDataReader reader =
                command.ExecuteReader();


            while (reader.Read())
            {
                courses.Add(
                    new SavedScheduleDetailViewModel
                    {
                        CourseTitle = reader.GetString(0),
                        Section = reader.GetString(1),
                        Day = reader.GetString(2),
                        StartTime = reader.GetTimeSpan(3),
                        EndTime = reader.GetTimeSpan(4),
                        Room = reader.GetString(5)
                    });
            }


            return courses;
        }



        private static string GenerateScheduleHash(
            GeneratedSchedule schedule)
        {
            string data = "";


            foreach (var offering in schedule.Offerings)
            {
                data += offering.CourseId;
                data += offering.Section;


                foreach (var meeting in offering.Meetings)
                {
                    data += meeting.MeetingDay;
                    data += meeting.StartTime;
                    data += meeting.EndTime;
                }
            }


            return data.GetHashCode().ToString();
        }
    }
}