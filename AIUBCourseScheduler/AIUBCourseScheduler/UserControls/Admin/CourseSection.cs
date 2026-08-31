namespace AIUBCourseScheduler.UserControls.Admin
{
    // একটি course offering/section-এর তথ্য রাখবে
    public class CourseSection
    {
        // Database-এর CourseOfferings table-এর primary key
        public int OfferingId { get; set; }

        public string SectionName { get; set; } = "";

        public string CourseName { get; set; } = "";

        public string DayTime { get; set; } = "";

        public string Room { get; set; } = "";

        public int Capacity { get; set; }

        public int EnrolledCount { get; set; }

        public string SectionType { get; set; } = "";

        public string Status { get; set; } = "";

        public int AvailableSeats => Capacity - EnrolledCount;
    }
}