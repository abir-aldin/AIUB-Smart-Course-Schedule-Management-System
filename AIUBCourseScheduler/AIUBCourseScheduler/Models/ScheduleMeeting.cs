using System;

namespace AIUBCourseScheduler.Models
{
    public class ScheduleMeeting
    {
        // ClassMeetings table-এর primary key
        public int MeetingId { get; set; }

        // Meeting কোন course offering/section-এর
        public int OfferingId { get; set; }

        // যেমন: Sunday, Monday
        public string MeetingDay { get; set; } = "";

        // Class শুরু হওয়ার সময়
        public TimeSpan StartTime { get; set; }

        // Class শেষ হওয়ার সময়
        public TimeSpan EndTime { get; set; }

        // Class room
        public string Room { get; set; } = "N/A";
    }
}