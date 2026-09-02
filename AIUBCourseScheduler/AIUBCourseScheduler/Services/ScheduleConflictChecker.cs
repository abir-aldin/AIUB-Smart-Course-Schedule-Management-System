using AIUBCourseScheduler.Models;
using System;

namespace AIUBCourseScheduler.Services
{
    internal static class ScheduleConflictChecker
    {
        /*
         * দুটি section/offering-এর কোনো class time
         * একে অপরের সঙ্গে clash করে কি না পরীক্ষা করবে।
         */
        public static bool HasConflict(
            ScheduleOffering firstOffering,
            ScheduleOffering secondOffering)
        {
            foreach (ScheduleMeeting firstMeeting in
                firstOffering.Meetings)
            {
                foreach (ScheduleMeeting secondMeeting in
                    secondOffering.Meetings)
                {
                    // Meeting day আলাদা হলে clash হবে না
                    bool sameDay =
                        string.Equals(
                            firstMeeting.MeetingDay,
                            secondMeeting.MeetingDay,
                            StringComparison.OrdinalIgnoreCase
                        );

                    if (!sameDay)
                    {
                        continue;
                    }

                    /*
                     * Time clash-এর নিয়ম:
                     *
                     * First class শুরু হবে second class শেষ হওয়ার আগে
                     * এবং second class শুরু হবে first class শেষ হওয়ার আগে।
                     */
                    bool timeOverlaps =
                        firstMeeting.StartTime <
                            secondMeeting.EndTime
                        &&
                        secondMeeting.StartTime <
                            firstMeeting.EndTime;

                    if (timeOverlaps)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}