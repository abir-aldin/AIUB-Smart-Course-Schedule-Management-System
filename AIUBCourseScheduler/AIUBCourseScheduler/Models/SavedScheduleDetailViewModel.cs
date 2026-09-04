using System;
using System.Collections.Generic;
using System.Text;

namespace AIUBCourseScheduler.Models
{
    public class SavedScheduleDetailViewModel
    {
        public string CourseCode { get; set; } = "";

        public string CourseTitle { get; set; } = "";

        public string Section { get; set; } = "";

        public string Day { get; set; } = "";

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public string Room { get; set; } = "";
    }
}