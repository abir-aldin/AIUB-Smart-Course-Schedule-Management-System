using System;
using System.Collections.Generic;
using System.Text;

namespace AIUBCourseScheduler.Models
{
    public class SavedScheduleViewModel
    {
        public int SavedScheduleId { get; set; }

        public string ScheduleName { get; set; } = "";

        public string Status { get; set; } = "";

        public DateTime CreatedAt { get; set; }

        public int CourseCount { get; set; }
    }
}
