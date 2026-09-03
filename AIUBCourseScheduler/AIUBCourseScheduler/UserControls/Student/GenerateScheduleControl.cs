using AIUBCourseScheduler.DataAccess;
using AIUBCourseScheduler.Models;
using AIUBCourseScheduler.Services;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AIUBCourseScheduler.UserControls.Student
{
    public partial class GenerateScheduleControl : Form
    {
        // সর্বশেষ তৈরি হওয়া schedules এখানে রাখা হবে
        private List<GeneratedSchedule> generatedSchedules =
            new List<GeneratedSchedule>();

        public GenerateScheduleControl()
        {
            InitializeComponent();

            /*
             * Selected courses panel-এর settings।
             * Course বেশি হলে vertical scrollbar আসবে।
             */
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = false;

            flowLayoutPanel1.FlowDirection =
                FlowDirection.TopDown;

            flowLayoutPanel1.Height = 110;

            ConfigurePreferenceControls();

            /*
             * Schedule generate হওয়ার আগে Designer-এর
             * sample tabs দেখানো হবে না।
             */
            tabControl1.TabPages.Clear();
            tabControl1.Visible = false;

            // Schedule তৈরি না হওয়া পর্যন্ত Save disabled থাকবে
            button2.Enabled = false;
        }

        private void ConfigurePreferenceControls()
        {
            // Minimum available seats
            numericUpDown1.Minimum = 4;
            numericUpDown1.Maximum = 40;
            numericUpDown1.Value = 4;

            // Maximum available seats
            numericUpDown2.Minimum = 4;
            numericUpDown2.Maximum = 40;
            numericUpDown2.Value = 40;

            // কয়টি alternative schedule দেখাবে
            numericUpDown3.Minimum = 1;
            numericUpDown3.Maximum = 10;
            numericUpDown3.Value = 3;
        }

        private void ShowSelectedCourses()
        {
            flowLayoutPanel1.Controls.Clear();

            int selectedCourseCount =
                CourseSelectionSession
                    .SelectedCourses.Count;

            double totalCredits =
                CourseSelectionSession.TotalCredits;

            label3.Text =
                $"Selected Courses ({selectedCourseCount})" +
                $"   |   Total Credits: {totalCredits:0.#}";

            label3.AutoSize = false;
            label3.Width = 510;
            label3.Height = 28;

            label3.TextAlign =
                ContentAlignment.MiddleLeft;

            label3.Margin =
                new Padding(5, 3, 5, 3);

            flowLayoutPanel1.Controls.Add(label3);

            if (selectedCourseCount == 0)
            {
                Label noCourseLabel = new Label
                {
                    AutoSize = true,

                    MaximumSize =
                        new Size(510, 0),

                    Text =
                        "No courses selected. " +
                        "Please return to Select Courses " +
                        "and save your selected courses.",

                    ForeColor = Color.Firebrick,

                    Font = new Font(
                        "Segoe UI",
                        9F,
                        FontStyle.Regular
                    ),

                    Padding =
                        new Padding(8, 5, 8, 5),

                    Margin =
                        new Padding(5, 5, 5, 5)
                };

                flowLayoutPanel1.Controls.Add(
                    noCourseLabel
                );

                button1.Enabled = false;
                button2.Enabled = false;

                return;
            }

            foreach (SelectableCourse course in
                CourseSelectionSession.SelectedCourses)
            {
                string courseIdentity =
                    course.CourseCode == "N/A"
                        ? course.CourseName
                        : course.CourseCode +
                          " - " +
                          course.CourseName;

                Label courseLabel = new Label
                {
                    AutoSize = true,

                    MaximumSize =
                        new Size(510, 0),

                    Text =
                        $"{courseIdentity} " +
                        $"({course.Credits:0.#} cr)",

                    BackColor =
                        Color.FromArgb(
                            225,
                            238,
                            255
                        ),

                    ForeColor =
                        Color.FromArgb(
                            10,
                            45,
                            95
                        ),

                    Font = new Font(
                        "Segoe UI",
                        8.5F,
                        FontStyle.Bold
                    ),

                    Padding =
                        new Padding(8, 5, 8, 5),

                    Margin =
                        new Padding(5, 3, 5, 3)
                };

                flowLayoutPanel1.Controls.Add(
                    courseLabel
                );
            }

            button1.Enabled = true;
        }

        private void ClearSchedulePreview()
        {
            tabControl1.TabPages.Clear();
            tabControl1.Visible = false;

            button2.Enabled = false;
        }

        private void ShowGeneratedSchedules()
        {
            tabControl1.TabPages.Clear();

            for (int index = 0;
                 index < generatedSchedules.Count;
                 index++)
            {
                GeneratedSchedule schedule =
                    generatedSchedules[index];

                TabPage scheduleTab =
                    new TabPage
                    {
                        Text =
                            $"Schedule {index + 1}",

                        Padding =
                            new Padding(3),

                        BackColor =
                            Color.White
                    };

                DataGridView scheduleGrid =
                    CreateScheduleGrid();

                FillScheduleGrid(
                    scheduleGrid,
                    schedule
                );

                scheduleTab.Controls.Add(
                    scheduleGrid
                );

                tabControl1.TabPages.Add(
                    scheduleTab
                );
            }

            tabControl1.Visible =
                generatedSchedules.Count > 0;

            if (tabControl1.TabPages.Count > 0)
            {
                tabControl1.SelectedIndex = 0;
            }
        }

        private static DataGridView CreateScheduleGrid()
        {
            DataGridView grid =
                new DataGridView
                {
                    Dock = DockStyle.Fill,

                    AutoGenerateColumns = false,

                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    AllowUserToResizeRows = false,

                    ReadOnly = true,
                    RowHeadersVisible = false,

                    MultiSelect = false,

                    SelectionMode =
                        DataGridViewSelectionMode.CellSelect,

                    BackgroundColor = Color.White,

                    BorderStyle =
                        BorderStyle.FixedSingle,

                    AutoSizeRowsMode =
                        DataGridViewAutoSizeRowsMode.AllCells,

                    ColumnHeadersHeight = 60,

                    ColumnHeadersHeightSizeMode =
                        DataGridViewColumnHeadersHeightSizeMode
                            .DisableResizing,

                    /*
                     * Time slot বেশি হলে horizontal
                     * scrollbar আসবে।
                     */
                    ScrollBars = ScrollBars.Both
                };

            grid.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    8.5F,
                    FontStyle.Regular
                );

            grid.DefaultCellStyle.WrapMode =
                DataGridViewTriState.True;

            grid.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            grid.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    8.5F,
                    FontStyle.Bold
                );

            grid.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            grid.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(225, 238, 255);

            grid.EnableHeadersVisualStyles = false;

            /*
             * Transposed schedule-এ প্রথম column হবে Day।
             * Time columns পরে dynamically তৈরি হবে।
             */
            DataGridViewTextBoxColumn dayColumn =
                new DataGridViewTextBoxColumn
                {
                    Name = "DayColumn",
                    HeaderText = "Day",

                    Width = 110,
                    MinimumWidth = 110,

                    Frozen = true,

                    SortMode =
                        DataGridViewColumnSortMode.NotSortable
                };

            dayColumn.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    8.5F,
                    FontStyle.Bold
                );

            dayColumn.DefaultCellStyle.BackColor =
                Color.FromArgb(225, 238, 255);

            grid.Columns.Add(dayColumn);

            return grid;
        }

        private static void FillScheduleGrid(
            DataGridView grid,
            GeneratedSchedule schedule)
        {
            /*
             * Schedule-এর সব unique class time বের করা হচ্ছে।
             * প্রতিটি unique time একটি column হবে।
             */
            List<(
                TimeSpan StartTime,
                TimeSpan EndTime)> timeSlots =
                    schedule.Offerings
                        .SelectMany(
                            offering =>
                                offering.Meetings
                        )
                        .Select(
                            meeting =>
                                (
                                    StartTime:
                                        meeting.StartTime,

                                    EndTime:
                                        meeting.EndTime
                                )
                        )
                        .Distinct()
                        .OrderBy(
                            slot => slot.StartTime
                        )
                        .ThenBy(
                            slot => slot.EndTime
                        )
                        .ToList();

            /*
             * প্রতিটি time slot কোন column-এ আছে
             * সেটি এখানে রাখা হবে।
             */
            Dictionary<
                (TimeSpan StartTime, TimeSpan EndTime),
                int> timeColumnIndexes =
                    new Dictionary<
                        (
                            TimeSpan StartTime,
                            TimeSpan EndTime
                        ),
                        int>();

            for (int index = 0;
                 index < timeSlots.Count;
                 index++)
            {
                var timeSlot =
                    timeSlots[index];

                DataGridViewTextBoxColumn timeColumn =
                    new DataGridViewTextBoxColumn
                    {
                        Name =
                            $"TimeSlotColumn{index + 1}",

                        HeaderText =
                            FormatTime(
                                timeSlot.StartTime
                            ) +
                            " - " +
                            FormatTime(
                                timeSlot.EndTime
                            ),

                        Width = 165,
                        MinimumWidth = 145,

                        AutoSizeMode =
                            DataGridViewAutoSizeColumnMode.None,

                        SortMode =
                            DataGridViewColumnSortMode.NotSortable
                    };

                grid.Columns.Add(timeColumn);

                timeColumnIndexes.Add(
                    timeSlot,
                    grid.Columns.Count - 1
                );
            }

            /*
             * Transposed schedule-এ প্রতিটি day
             * একটি row হবে।
             */
            string[] days =
            {
                "Sunday",
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday"
            };

            Dictionary<string, int> dayRowIndexes =
                new Dictionary<string, int>(
                    StringComparer.OrdinalIgnoreCase
                );

            foreach (string day in days)
            {
                int rowIndex =
                    grid.Rows.Add(day);

                grid.Rows[rowIndex].MinimumHeight = 75;

                dayRowIndexes.Add(
                    day,
                    rowIndex
                );
            }

            /*
             * প্রত্যেক meeting তার day row এবং
             * time column অনুযায়ী grid-এ বসানো হবে।
             */
            foreach (ScheduleOffering offering in
                schedule.Offerings)
            {
                string courseIdentity =
                    offering.CourseCode == "N/A"
                        ? offering.CourseName
                        : offering.CourseCode;

                foreach (ScheduleMeeting meeting in
                    offering.Meetings)
                {
                    string meetingDay =
                        meeting.MeetingDay.Trim();

                    if (!dayRowIndexes.TryGetValue(
                        meetingDay,
                        out int dayRowIndex))
                    {
                        continue;
                    }

                    var meetingSlot =
                        (
                            StartTime:
                                meeting.StartTime,

                            EndTime:
                                meeting.EndTime
                        );

                    if (!timeColumnIndexes.TryGetValue(
                        meetingSlot,
                        out int timeColumnIndex))
                    {
                        continue;
                    }

                    string classInformation =
                        $"{courseIdentity}\n" +
                        $"Section: {offering.Section}\n" +
                        $"Room: {meeting.Room}";

                    DataGridViewCell targetCell =
                        grid.Rows[dayRowIndex]
                            .Cells[timeColumnIndex];

                    /*
                     * একই cell-এ কোনো information থাকলে
                     * নতুন information নিচে যোগ হবে।
                     */
                    string existingInformation =
                        Convert.ToString(
                            targetCell.Value
                        ) ?? "";

                    targetCell.Value =
                        string.IsNullOrWhiteSpace(
                            existingInformation
                        )
                            ? classInformation
                            : existingInformation +
                              "\n----------------\n" +
                              classInformation;
                }
            }

            grid.ClearSelection();
        }

        private static string FormatTime(
            TimeSpan time)
        {
            return DateTime.Today
                .Add(time)
                .ToString("h:mm tt");
        }

        private void numericUpDown1_ValueChanged(
            object sender,
            EventArgs e)
        {
            if (numericUpDown1.Value >
                numericUpDown2.Value)
            {
                numericUpDown2.Value =
                    numericUpDown1.Value;
            }
        }

        private void GenerateScheduleControl_Load(
            object sender,
            EventArgs e)
        {
            ShowSelectedCourses();
        }

        private async void button1_Click(
            object sender,
            EventArgs e)
        {
            if (CourseSelectionSession
                    .SelectedCourses.Count == 0)
            {
                MessageBox.Show(
                    "Please select and save courses first.",
                    "No Courses Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            int minimumAvailableSeats =
                (int)numericUpDown1.Value;

            int maximumAvailableSeats =
                (int)numericUpDown2.Value;

            int requestedScheduleCount =
                (int)numericUpDown3.Value;

            if (minimumAvailableSeats >
                maximumAvailableSeats)
            {
                MessageBox.Show(
                    "Minimum available seats cannot be " +
                    "greater than maximum available seats.",
                    "Invalid Preference",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string originalButtonText =
                button1.Text;

            try
            {
                button1.Enabled = false;
                button1.Text = "Generating...";

                generatedSchedules.Clear();
                ClearSchedulePreview();

                List<int> selectedCourseIds =
                    CourseSelectionSession
                        .SelectedCourses
                        .Select(
                            course => course.CourseId
                        )
                        .Distinct()
                        .ToList();

                List<ScheduleOffering> availableOfferings =
                    await ScheduleGenerationService
                        .LoadAvailableOfferingsAsync(
                            selectedCourseIds,
                            minimumAvailableSeats,
                            maximumAvailableSeats
                        );

                HashSet<int> availableCourseIds =
                    availableOfferings
                        .Select(
                            offering =>
                                offering.CourseId
                        )
                        .ToHashSet();

                List<string> unavailableCourses =
                    CourseSelectionSession
                        .SelectedCourses
                        .Where(
                            course =>
                                !availableCourseIds.Contains(
                                    course.CourseId
                                )
                        )
                        .Select(
                            course =>
                                course.CourseCode == "N/A"
                                    ? course.CourseName
                                    : course.CourseCode +
                                      " - " +
                                      course.CourseName
                        )
                        .ToList();

                if (unavailableCourses.Count > 0)
                {
                    MessageBox.Show(
                        "The following courses do not have " +
                        "eligible sections:\n\n" +
                        string.Join(
                            Environment.NewLine,
                            unavailableCourses
                        ),
                        "Sections Not Available",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                List<GeneratedSchedule> candidates =
                    ScheduleCombinationGenerator
                        .GenerateClashFreeSchedules(
                            availableOfferings,
                            selectedCourseIds,
                            maximumResults: 2000
                        );

                if (candidates.Count == 0)
                {
                    MessageBox.Show(
                        "No clash-free schedule could be created " +
                        "for the selected courses.",
                        "No Schedule Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    return;
                }

                List<GeneratedSchedule> rankedSchedules =
                    SchedulePreferenceService
                        .RankSchedules(
                            candidates,

                            avoidEarlyClasses:
                                checkBox1.Checked,

                            avoidThursday:
                                checkBox2.Checked,

                            avoidLargeGaps:
                                checkBox3.Checked
                        );

                /*
                 * Preference অনুযায়ী ranked schedules থেকে
                 * যতটা সম্ভব আলাদা sections-এর schedules নেওয়া হবে।
                 */
                generatedSchedules =
                    ScheduleDiversityService
                        .SelectDiverseSchedules(
                            rankedSchedules,
                            requestedScheduleCount
                        );

                // Generated schedules TabControl-এ দেখানো হচ্ছে
                ShowGeneratedSchedules();

                button2.Enabled =
                    generatedSchedules.Count > 0;

                MessageBox.Show(
                    $"{generatedSchedules.Count} clash-free " +
                    "schedule(s) generated successfully.",
                    "Generation Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Could not load course sections from " +
                    "the database.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Schedule generation failed.\n\n" +
                    ex.Message,
                    "Generation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                button1.Text =
                    originalButtonText;

                button1.Enabled =
                    CourseSelectionSession
                        .SelectedCourses.Count > 0;
            }
        }

        private void checkBox1_CheckedChanged(
            object sender,
            EventArgs e)
        {

        }

        private void tabPage1_Click(
            object sender,
            EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (generatedSchedules == null ||
        generatedSchedules.Count == 0)
            {
                MessageBox.Show(
                    "No generated schedule available to save.",
                    "Nothing to Save",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            try
            {
                bool saved =
                    ScheduleRepository
                        .SaveGeneratedSchedules(
                            generatedSchedules,
                            UserSession.UserId
                        );


                if (saved)
                {
                    MessageBox.Show(
                        "All generated schedules saved successfully.",
                        "Save Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    button2.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not save schedules.\n\n" +
                    ex.Message,
                    "Save Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}