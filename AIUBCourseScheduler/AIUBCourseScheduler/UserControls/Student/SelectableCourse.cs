using System;
using System.Collections.Generic;
using System.Text;

namespace AIUBCourseScheduler.UserControls.Student
{
    internal class SelectableCourse
    {
        // Checkbox-এর selected অবস্থার জন্য
        public bool IsSelected { get; set; }

        // Database-এর CourseId
        public int CourseId { get; set; }

        // Excel-এ code না থাকলে N/A দেখানো হবে
        public string CourseCode { get; set; } = "N/A";

        public string CourseName { get; set; } = "";

        // Theory course 3 এবং Lab course 1 credit
        public double Credits { get; set; }

        // ৩টির বেশি seat আছে—এমন section-এর সংখ্যা
        public int AvailableSections { get; set; }
    }
}
