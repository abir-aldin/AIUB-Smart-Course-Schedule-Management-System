using System;
using System.Collections.Generic;
using System.Text;

namespace AIUBCourseScheduler.Models
{
    public class ScheduleRequestViewModel
    {
        public int RequestId { get; set; }

        public int StudentUserId { get; set; }

        public string StudentName { get; set; } = "";

        public int SavedScheduleId { get; set; }

        public string ScheduleName { get; set; } = "";

        public string RequestStatus { get; set; } = "";

        public DateTime SubmittedAt { get; set; }

        public string? AdminComment { get; set; }
    }
}