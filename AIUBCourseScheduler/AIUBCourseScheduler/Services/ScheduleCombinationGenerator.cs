using AIUBCourseScheduler.Models;
using System.Collections.Generic;
using System.Linq;

namespace AIUBCourseScheduler.Services
{
    internal static class ScheduleCombinationGenerator
    {
        /*
         * প্রতিটি selected course থেকে একটি করে section নিয়ে
         * clash-free schedule combinations তৈরি করবে।
         */
        public static List<GeneratedSchedule>
            GenerateClashFreeSchedules(
                IEnumerable<ScheduleOffering> availableOfferings,
                IReadOnlyList<int> selectedCourseIds,
                int maximumResults)
        {
            List<GeneratedSchedule> generatedSchedules =
                new List<GeneratedSchedule>();

            // একই CourseId একাধিকবার থাকলে একবারই নেওয়া হবে
            List<int> uniqueCourseIds =
                selectedCourseIds
                    .Distinct()
                    .ToList();

            if (uniqueCourseIds.Count == 0 ||
                maximumResults <= 0)
            {
                return generatedSchedules;
            }

            /*
             * CourseId অনুযায়ী তার available sections
             * আলাদা group-এ রাখা হচ্ছে।
             */
            Dictionary<int, List<ScheduleOffering>>
                offeringsByCourse =
                    availableOfferings
                        .GroupBy(
                            offering => offering.CourseId
                        )
                        .ToDictionary(
                            group => group.Key,
                            group => group.ToList()
                        );

            /*
             * কোনো selected course-এর eligible section না থাকলে
             * complete schedule তৈরি করা সম্ভব নয়।
             */
            foreach (int courseId in uniqueCourseIds)
            {
                if (!offeringsByCourse.ContainsKey(courseId) ||
                    offeringsByCourse[courseId].Count == 0)
                {
                    return generatedSchedules;
                }
            }

            List<ScheduleOffering> currentCombination =
                new List<ScheduleOffering>();

            BuildCombinations(
                courseIndex: 0,
                courseIds: uniqueCourseIds,
                offeringsByCourse: offeringsByCourse,
                currentCombination: currentCombination,
                generatedSchedules: generatedSchedules,
                maximumResults: maximumResults
            );

            return generatedSchedules;
        }

        private static void BuildCombinations(
            int courseIndex,
            IReadOnlyList<int> courseIds,
            Dictionary<int, List<ScheduleOffering>>
                offeringsByCourse,
            List<ScheduleOffering> currentCombination,
            List<GeneratedSchedule> generatedSchedules,
            int maximumResults)
        {
            // প্রয়োজনীয় সংখ্যক result পাওয়া গেলে search বন্ধ হবে
            if (generatedSchedules.Count >= maximumResults)
            {
                return;
            }

            /*
             * সব selected course-এর জন্য একটি করে
             * section পাওয়া গেলে একটি schedule সম্পূর্ণ।
             */
            if (courseIndex == courseIds.Count)
            {
                GeneratedSchedule schedule =
                    new GeneratedSchedule
                    {
                        Offerings =
                            new List<ScheduleOffering>(
                                currentCombination
                            )
                    };

                generatedSchedules.Add(schedule);
                return;
            }

            int currentCourseId =
                courseIds[courseIndex];

            foreach (ScheduleOffering candidateOffering in
                offeringsByCourse[currentCourseId])
            {
                bool hasConflict = false;

                /*
                 * নতুন section-এর meeting time আগে select করা
                 * section-গুলোর সঙ্গে clash করে কি না দেখা হচ্ছে।
                 */
                foreach (ScheduleOffering selectedOffering in
                    currentCombination)
                {
                    if (ScheduleConflictChecker.HasConflict(
                        selectedOffering,
                        candidateOffering
                    ))
                    {
                        hasConflict = true;
                        break;
                    }
                }

                if (hasConflict)
                {
                    continue;
                }

                // Candidate section সাময়িকভাবে combination-এ যোগ হবে
                currentCombination.Add(candidateOffering);

                BuildCombinations(
                    courseIndex + 1,
                    courseIds,
                    offeringsByCourse,
                    currentCombination,
                    generatedSchedules,
                    maximumResults
                );

                /*
                 * অন্য section পরীক্ষা করার জন্য সর্বশেষ
                 * যোগ করা section সরিয়ে দেওয়া হচ্ছে।
                 */
                currentCombination.RemoveAt(
                    currentCombination.Count - 1
                );

                if (generatedSchedules.Count >= maximumResults)
                {
                    return;
                }
            }
        }
    }
}