using System.Collections.Generic;

namespace AIUBCourseScheduler.Models
{
    public class ScheduleOffering
    {
        // CourseOfferings table-এর primary key
        public int OfferingId { get; set; }

        // Offering কোন course-এর
        public int CourseId { get; set; }

        public string CourseCode { get; set; } = "N/A";

        public string CourseName { get; set; } = "";

        // যেমন: A, B, C
        public string Section { get; set; } = "";

        // Theory অথবা Lab
        public string OfferingType { get; set; } = "";

        public int Capacity { get; set; }

        public int EnrolledCount { get; set; }

        // বর্তমানে section-এ কতটি seat available
        public int AvailableSeats =>
            Capacity - EnrolledCount;

        // এই section-এর day, time ও room information
        public List<ScheduleMeeting> Meetings { get; set; } =
            new List<ScheduleMeeting>();
    }
}