using AIUBCourseScheduler.DataAccess;
using AIUBCourseScheduler.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AIUBCourseScheduler.Services
{
    internal static class ScheduleGenerationService
    {
        /*
         * Selected course IDs অনুযায়ী eligible sections এবং
         * তাদের meeting day, time ও room database থেকে load করবে।
         */
        public static async Task<List<ScheduleOffering>>
            LoadAvailableOfferingsAsync(
                IReadOnlyList<int> selectedCourseIds,
                int minimumAvailableSeats,
                int maximumAvailableSeats)
        {
            List<ScheduleOffering> offerings =
                new List<ScheduleOffering>();

            // কোনো course selected না থাকলে database query দরকার নেই
            if (selectedCourseIds.Count == 0)
            {
                return offerings;
            }

            /*
             * প্রতিটি selected CourseId-এর জন্য আলাদা
             * SQL parameter তৈরি করা হচ্ছে।
             */
            string courseParameters =
                string.Join(
                    ", ",
                    selectedCourseIds.Select(
                        (courseId, index) =>
                            $"@CourseId{index}"
                    )
                );

            string query = $@"
                SELECT
                    CO.OfferingId,
                    CO.CourseId,
                    C.CourseCode,
                    C.CourseTitle,
                    CO.Section,
                    CO.OfferingType,
                    ISNULL(CO.Capacity, 0) AS Capacity,
                    ISNULL(CO.EnrolledCount, 0) AS EnrolledCount,

                    CM.MeetingId,
                    CM.MeetingDay,
                    CM.StartTime,
                    CM.EndTime,
                    CM.Room

                FROM dbo.CourseOfferings AS CO

                INNER JOIN dbo.Courses AS C
                    ON C.CourseId = CO.CourseId

                LEFT JOIN dbo.ClassMeetings AS CM
                    ON CM.OfferingId = CO.OfferingId

                WHERE CO.CourseId IN ({courseParameters})
                  AND C.IsActive = 1
                  AND CO.IsActive = 1

                  AND
                  (
                      ISNULL(CO.Capacity, 0) -
                      ISNULL(CO.EnrolledCount, 0)
                  )
                  BETWEEN @MinimumSeats AND @MaximumSeats

                ORDER BY
                    C.CourseTitle,
                    CO.Section,
                    CM.MeetingId;";

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            await connection.OpenAsync();

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.CommandTimeout = 120;

            // Selected CourseId parameters যোগ করা হচ্ছে
            for (int index = 0;
                 index < selectedCourseIds.Count;
                 index++)
            {
                command.Parameters.Add(
                    $"@CourseId{index}",
                    SqlDbType.Int
                ).Value = selectedCourseIds[index];
            }

            command.Parameters.Add(
                "@MinimumSeats",
                SqlDbType.Int
            ).Value = minimumAvailableSeats;

            command.Parameters.Add(
                "@MaximumSeats",
                SqlDbType.Int
            ).Value = maximumAvailableSeats;

            using SqlDataReader reader =
                await command.ExecuteReaderAsync();

            /*
             * একই offering-এর একাধিক meeting থাকতে পারে।
             * OfferingId ব্যবহার করে meeting-গুলো একই
             * ScheduleOffering object-এর মধ্যে রাখা হবে।
             */
            Dictionary<int, ScheduleOffering> offeringDictionary =
                new Dictionary<int, ScheduleOffering>();

            while (await reader.ReadAsync())
            {
                int offeringId =
                    reader.GetInt32(0);

                if (!offeringDictionary.TryGetValue(
                    offeringId,
                    out ScheduleOffering? offering))
                {
                    offering = new ScheduleOffering
                    {
                        OfferingId = offeringId,

                        CourseId =
                            reader.GetInt32(1),

                        CourseCode =
                            reader.IsDBNull(2)
                                ? "N/A"
                                : reader.GetString(2),

                        CourseName =
                            reader.GetString(3),

                        Section =
                            reader.IsDBNull(4)
                                ? "N/A"
                                : reader.GetString(4),

                        OfferingType =
                            reader.IsDBNull(5)
                                ? "N/A"
                                : reader.GetString(5),

                        Capacity =
                            reader.GetInt32(6),

                        EnrolledCount =
                            reader.GetInt32(7)
                    };

                    offeringDictionary.Add(
                        offeringId,
                        offering
                    );

                    offerings.Add(offering);
                }

                /*
                 * MeetingId null হলে এই offering-এর
                 * কোনো class meeting পাওয়া যায়নি।
                 */
                if (!reader.IsDBNull(8))
                {
                    ScheduleMeeting meeting =
                        new ScheduleMeeting
                        {
                            MeetingId =
                                reader.GetInt32(8),

                            OfferingId =
                                offeringId,

                            MeetingDay =
                                reader.IsDBNull(9)
                                    ? ""
                                    : reader.GetString(9),

                            StartTime =
                                reader.GetTimeSpan(10),

                            EndTime =
                                reader.GetTimeSpan(11),

                            Room =
                                reader.IsDBNull(12)
                                    ? "N/A"
                                    : reader.GetString(12)
                        };

                    offering.Meetings.Add(meeting);
                }
            }

            return offerings;
        }
    }
}