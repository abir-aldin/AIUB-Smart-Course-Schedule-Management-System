using AIUBCourseScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AIUBCourseScheduler.Services
{
    internal static class SchedulePreferenceService
    {
        /*
         * User-এর selected preferences অনুযায়ী প্রতিটি
         * schedule-এর score calculate করে best schedule
         * প্রথমে রাখবে।
         */
        public static List<GeneratedSchedule> RankSchedules(
            IEnumerable<GeneratedSchedule> schedules,
            bool avoidEarlyClasses,
            bool avoidThursday,
            bool avoidLargeGaps)
        {
            List<GeneratedSchedule> rankedSchedules =
                schedules.ToList();

            foreach (GeneratedSchedule schedule in
                rankedSchedules)
            {
                schedule.PreferenceScore =
                    CalculatePreferenceScore(
                        schedule,
                        avoidEarlyClasses,
                        avoidThursday,
                        avoidLargeGaps
                    );
            }

            return rankedSchedules
                .OrderByDescending(
                    schedule =>
                        schedule.PreferenceScore
                )
                .ToList();
        }

        private static int CalculatePreferenceScore(
            GeneratedSchedule schedule,
            bool avoidEarlyClasses,
            bool avoidThursday,
            bool avoidLargeGaps)
        {
            // বেশি score মানে preference-এর সঙ্গে ভালো match
            int score = 10000;

            List<ScheduleMeeting> allMeetings =
                schedule.Offerings
                    .SelectMany(
                        offering => offering.Meetings
                    )
                    .ToList();

            if (avoidEarlyClasses)
            {
                if (avoidEarlyClasses)
                {
                    // সকাল ঠিক ৮টায় শুরু হওয়া class avoid করা হবে
                    TimeSpan eightAm =
                        new TimeSpan(8, 0, 0);

                    foreach (ScheduleMeeting meeting in
                        allMeetings)
                    {
                        if (meeting.StartTime == eightAm)
                        {
                            score -= 500;
                        }
                    }
                }
            }

            if (avoidThursday)
            {
                foreach (ScheduleMeeting meeting in
                    allMeetings)
                {
                    if (string.Equals(
                        meeting.MeetingDay,
                        "Thursday",
                        StringComparison.OrdinalIgnoreCase
                    ))
                    {
                        score -= 300;
                    }
                }
            }

            if (avoidLargeGaps)
            {
                /*
                 * একই দিনের meetings একসঙ্গে group করা হচ্ছে।
                 */
                var meetingsByDay =
                    allMeetings.GroupBy(
                        meeting => meeting.MeetingDay,
                        StringComparer.OrdinalIgnoreCase
                    );

                foreach (var dayGroup in meetingsByDay)
                {
                    List<ScheduleMeeting> orderedMeetings =
                        dayGroup
                            .OrderBy(
                                meeting =>
                                    meeting.StartTime
                            )
                            .ToList();

                    for (int index = 0;
                         index < orderedMeetings.Count - 1;
                         index++)
                    {
                        ScheduleMeeting currentMeeting =
                            orderedMeetings[index];

                        ScheduleMeeting nextMeeting =
                            orderedMeetings[index + 1];

                        TimeSpan gap =
                            nextMeeting.StartTime -
                            currentMeeting.EndTime;

                        /*
                         * দুই class-এর মাঝখানে ১ ঘণ্টার বেশি
                         * gap থাকলে অতিরিক্ত সময় অনুযায়ী
                         * schedule-এর score কমবে।
                         */
                        if (gap > TimeSpan.FromHours(1))
                        {
                            int extraGapMinutes =
                                (int)(
                                    gap -
                                    TimeSpan.FromHours(1)
                                ).TotalMinutes;

                            score -= extraGapMinutes;
                        }
                    }
                }
            }

            return score;
        }
    }
}