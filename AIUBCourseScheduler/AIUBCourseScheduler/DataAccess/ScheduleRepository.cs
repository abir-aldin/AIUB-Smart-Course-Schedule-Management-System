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