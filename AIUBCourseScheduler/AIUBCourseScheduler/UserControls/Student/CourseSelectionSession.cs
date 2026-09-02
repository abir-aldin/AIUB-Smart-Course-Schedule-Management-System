using System.Collections.Generic;
using System.Linq;

namespace AIUBCourseScheduler.UserControls.Student
{
    internal static class CourseSelectionSession
    {
        // Student যে courses select করেছে সেগুলো রাখা হবে
        private static readonly List<SelectableCourse>
            selectedCourses =
                new List<SelectableCourse>();

        // অন্য page শুধু list পড়তে পারবে
        public static IReadOnlyList<SelectableCourse>
            SelectedCourses => selectedCourses;

        // Select Courses page থেকে selected courses save করবে
        public static void SaveSelectedCourses(
            IEnumerable<SelectableCourse> courses)
        {
            selectedCourses.Clear();

            selectedCourses.AddRange(
                courses.Where(
                    course => course.IsSelected
                )
            );
        }

        // Selected courses-এর total credits
        public static double TotalCredits =>
            selectedCourses.Sum(
                course => course.Credits
            );

        // প্রয়োজন হলে selection clear করবে
        public static void Clear()
        {
            selectedCourses.Clear();
        }
    }
}