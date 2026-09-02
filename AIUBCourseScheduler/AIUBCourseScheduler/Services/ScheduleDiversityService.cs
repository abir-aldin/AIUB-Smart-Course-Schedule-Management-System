using AIUBCourseScheduler.Models;
using System.Collections.Generic;
using System.Linq;

namespace AIUBCourseScheduler.Services
{
    internal static class ScheduleDiversityService
    {
        /*
         * Ranked schedules থেকে এমন alternatives নির্বাচন করবে
         * যেগুলোর sections একে অপরের থেকে যতটা সম্ভব আলাদা।
         */
        public static List<GeneratedSchedule>
            SelectDiverseSchedules(
                IEnumerable<GeneratedSchedule> rankedSchedules,
                int requestedCount)
        {
            List<GeneratedSchedule> remainingSchedules =
                rankedSchedules.ToList();

            List<GeneratedSchedule> selectedSchedules =
                new List<GeneratedSchedule>();

            if (remainingSchedules.Count == 0 ||
                requestedCount <= 0)
            {
                return selectedSchedules;
            }

            /*
             * Preference ranking অনুযায়ী প্রথম schedule-টি
             * best schedule হিসেবে নেওয়া হবে।
             */
            GeneratedSchedule firstSchedule =
                remainingSchedules[0];

            selectedSchedules.Add(firstSchedule);
            remainingSchedules.RemoveAt(0);

            while (selectedSchedules.Count < requestedCount &&
                   remainingSchedules.Count > 0)
            {
                /*
                 * আগে নেওয়া schedules-এর তুলনায় যেটির
                 * section সবচেয়ে বেশি আলাদা, সেটি নেওয়া হবে।
                 */
                GeneratedSchedule nextSchedule =
                    remainingSchedules
                        .OrderByDescending(
                            candidate =>
                                GetMinimumDifference(
                                    candidate,
                                    selectedSchedules
                                )
                        )
                        .ThenByDescending(
                            candidate =>
                                candidate.PreferenceScore
                        )
                        .First();

                selectedSchedules.Add(nextSchedule);
                remainingSchedules.Remove(nextSchedule);
            }

            return selectedSchedules;
        }

        private static int GetMinimumDifference(
            GeneratedSchedule candidate,
            IEnumerable<GeneratedSchedule> selectedSchedules)
        {
            /*
             * Candidate schedule-এর সবচেয়ে কাছের schedule-এর
             * সঙ্গেও কতটি section আলাদা, সেটি বের করা হবে।
             */
            return selectedSchedules
                .Select(
                    selected =>
                        CountDifferentSections(
                            candidate,
                            selected
                        )
                )
                .Min();
        }

        private static int CountDifferentSections(
            GeneratedSchedule firstSchedule,
            GeneratedSchedule secondSchedule)
        {
            Dictionary<int, int> secondOfferingIds =
                secondSchedule.Offerings
                    .ToDictionary(
                        offering => offering.CourseId,
                        offering => offering.OfferingId
                    );

            int differenceCount = 0;

            foreach (ScheduleOffering offering in
                firstSchedule.Offerings)
            {
                bool sameOfferingExists =
                    secondOfferingIds.TryGetValue(
                        offering.CourseId,
                        out int secondOfferingId
                    )
                    &&
                    secondOfferingId ==
                        offering.OfferingId;

                if (!sameOfferingExists)
                {
                    differenceCount++;
                }
            }

            return differenceCount;
        }
    }
}