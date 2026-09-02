using System.Collections.Generic;

namespace AIUBCourseScheduler.Models
{
    internal class GeneratedSchedule
    {
        /*
         * একটি generated schedule-এর মধ্যে
         * প্রতিটি selected course-এর একটি করে
         * suitable section/offering থাকবে।
         */
        public List<ScheduleOffering> Offerings { get; set; } =
            new List<ScheduleOffering>();

        /*
         * User-এর preference যত ভালোভাবে match করবে,
         * schedule-এর score তত বেশি হবে।
         */
        public int PreferenceScore { get; set; }
    }
}