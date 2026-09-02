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

                    ColumnHeadersHeight = 42,

                    ColumnHeadersHeightSizeMode =
                        DataGridViewColumnHeadersHeightSizeMode
                            .DisableResizing
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

            grid.Columns.Add(
                CreateScheduleColumn(
                    "TimeColumn",
                    "Time",
                    isTimeColumn: true
                )
            );

            grid.Columns.Add(
                CreateScheduleColumn(
                    "Sunday",
                    "Sunday"
                )
            );

            grid.Columns.Add(
                CreateScheduleColumn(
                    "Monday",
                    "Monday"
                )
            );

            grid.Columns.Add(
                CreateScheduleColumn(
                    "Tuesday",
                    "Tuesday"
                )
            );

            grid.Columns.Add(
                CreateScheduleColumn(
                    "Wednesday",
                    "Wednesday"
                )
            );

            grid.Columns.Add(
                CreateScheduleColumn(
                    "Thursday",
                    "Thursday"
                )
            );

            return grid;
        }

        private static DataGridViewTextBoxColumn
            CreateScheduleColumn(
                string columnName,
                string headerText,
                bool isTimeColumn = false)
        {
            DataGridViewTextBoxColumn column =
                new DataGridViewTextBoxColumn
                {
                    Name = columnName,
                    HeaderText = headerText,

                    SortMode =
                        DataGridViewColumnSortMode
                            .NotSortable
                };

            if (isTimeColumn)
            {
                column.Width = 125;

                column.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.None;
            }
            else
            {
                column.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;

                column.FillWeight = 100;
            }

            return column;
        }

        private static void FillScheduleGrid(
            DataGridView grid,
            GeneratedSchedule schedule)
        {
            /*
             * Schedule-এর সব unique class time বের করা হচ্ছে।
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

            Dictionary<
                (TimeSpan StartTime, TimeSpan EndTime),
                int> rowIndexes =
                    new Dictionary<
                        (
                            TimeSpan StartTime,
                            TimeSpan EndTime
                        ),
                        int>();

            foreach (var timeSlot in timeSlots)
            {
                int rowIndex =
                    grid.Rows.Add(
                        FormatTime(timeSlot.StartTime) +
                        " - " +
                        FormatTime(timeSlot.EndTime)
                    );

                rowIndexes.Add(
                    timeSlot,
                    rowIndex
                );
            }

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
                    var meetingSlot =
                        (
                            StartTime:
                                meeting.StartTime,

                            EndTime:
                                meeting.EndTime
                        );

                    if (!rowIndexes.TryGetValue(
                        meetingSlot,
                        out int rowIndex))
                    {
                        continue;
                    }

                    int dayColumnIndex =
                        GetDayColumnIndex(
                            meeting.MeetingDay
                        );

                    if (dayColumnIndex < 0)
                    {
                        continue;
                    }

                    string classInformation =
                        $"{courseIdentity}\n" +
                        $"Section: {offering.Section}\n" +
                        $"Room: {meeting.Room}";

                    grid.Rows[rowIndex]
                        .Cells[dayColumnIndex]
                        .Value = classInformation;
                }
            }

            grid.ClearSelection();
        }

        private static int GetDayColumnIndex(
            string meetingDay)
        {
            switch (
                meetingDay
                    .Trim()
                    .ToLowerInvariant())
            {
                case "sunday":
                    return 1;

                case "monday":
                    return 2;

                case "tuesday":
                    return 3;

                case "wednesday":
                    return 4;

                case "thursday":
                    return 5;

                default:
                    return -1;
            }
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

                generatedSchedules =
                    rankedSchedules
                        .Take(requestedScheduleCount)
                        .ToList();

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
    }
}