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