using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AIUBCourseScheduler.DataAccess;
using AIUBCourseScheduler.Services;
using AIUBCourseScheduler.Models;

namespace AIUBCourseScheduler.UserControls.Student
{
    public partial class MySchedulesControl : Form
    {
        public MySchedulesControl()
        {
            InitializeComponent();
            LoadSavedSchedules();
            dataGridView1.CellContentClick +=
        dataGridView1_CellContentClick;
        }

        private void LoadSavedSchedules()
        {
            List<SavedScheduleViewModel> schedules =
                ScheduleRepository
                    .GetStudentSavedSchedules(
                        UserSession.UserId
                    );


            dataGridView1.Rows.Clear();


            foreach (SavedScheduleViewModel schedule in schedules)
            {
                int rowIndex =
                    dataGridView1.Rows.Add();

                dataGridView1.Rows[rowIndex].Tag =
    schedule.SavedScheduleId;


                dataGridView1.Rows[rowIndex]
                    .Cells["Schedule"]
                    .Value =
                        schedule.ScheduleName;


                dataGridView1.Rows[rowIndex]
                    .Cells["CreatedDate"]
                    .Value =
                        schedule.CreatedAt
                            .ToString("dd MMM yyyy");


                dataGridView1.Rows[rowIndex]
                    .Cells["Courses"]
                    .Value =
                        schedule.CourseCount;


                dataGridView1.Rows[rowIndex]
                    .Cells["Dataview"]
                    .Value =
                        "View";

                dataGridView1.Rows[rowIndex]
    .Cells["Action2"]
    .Value =
        "Delete";
            }
        }

        private void dataGridView1_CellContentClick(
    object sender,
    DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


            if (e.ColumnIndex ==
               dataGridView1.Columns["Dataview"].Index)
            {

                int savedScheduleId =
                    Convert.ToInt32(
                        dataGridView1.Rows[e.RowIndex]
                        .Tag
                    );


                LoadSchedulePreview(savedScheduleId);
            }

            else if (e.ColumnIndex ==
    dataGridView1.Columns["Action2"].Index)
            {
                int savedScheduleId =
                    Convert.ToInt32(
                        dataGridView1.Rows[e.RowIndex]
                        .Tag
                    );


                DialogResult result =
                    MessageBox.Show(
                        "Are you sure you want to delete this schedule?",
                        "Delete Schedule",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );


                if (result == DialogResult.Yes)
                {
                    bool deleted =
                        ScheduleRepository
                            .DeleteSavedSchedule(savedScheduleId);


                    if (deleted)
                    {
                        MessageBox.Show(
                            "Schedule deleted successfully.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );


                        LoadSavedSchedules();

                        dataGridView2.Columns.Clear();
                        dataGridView2.Rows.Clear();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Only Draft schedules can be deleted.",
                            "Cannot Delete",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                }
            }
        }

        private void LoadSchedulePreview(int savedScheduleId)
        {
            List<SavedScheduleDetailViewModel> details =
                ScheduleRepository.GetScheduleDetails(savedScheduleId);


            dataGridView2.Columns.Clear();
            dataGridView2.Rows.Clear();


            // Collect unique time slots
            List<string> timeSlots =
                                  details
                                    .GroupBy(x => new
                                    {
                                        x.StartTime,
                                        x.EndTime
                                    })
                                   .OrderBy(g => g.Key.StartTime)
                                     .Select(g =>
                                         $"{DateTime.Today.Add(g.Key.StartTime):hh:mm tt}-{DateTime.Today.Add(g.Key.EndTime):hh:mm tt}"
                                       )
                                      .ToList();



            // First column = Day
            DataGridViewTextBoxColumn dayColumn =
                new DataGridViewTextBoxColumn();

            dayColumn.HeaderText = "Day";
            dayColumn.Name = "Day";

            dataGridView2.Columns.Add(dayColumn);



            // Add time columns
            foreach (string time in timeSlots)
            {
                DataGridViewTextBoxColumn column =
                    new DataGridViewTextBoxColumn();

                column.HeaderText = time;
                column.Name = time;

                dataGridView2.Columns.Add(column);
            }



            string[] days =
            {
        "Sunday",
        "Monday",
        "Tuesday",
        "Wednesday",
        "Thursday"
    };



            // Create rows
            foreach (string day in days)
            {
                int row =
                    dataGridView2.Rows.Add();

                dataGridView2.Rows[row]
                    .Cells["Day"]
                    .Value = day;
            }



            // Fill courses
            foreach (var item in details)
            {
                string time =
    $"{DateTime.Today.Add(item.StartTime):hh:mm tt}-{DateTime.Today.Add(item.EndTime):hh:mm tt}";


                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Cells["Day"].Value?.ToString()
                        == item.Day)
                    {

                        row.Cells[time].Value =
                            $"{item.CourseTitle}\nSection: {item.Section}\nRoom: {item.Room}";

                        break;
                    }
                }
            }

            FormatScheduleGrid();

        }
        private void FormatScheduleGrid()
        {
            dataGridView2.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView2.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.AllCells;


            dataGridView2.DefaultCellStyle.WrapMode =
                DataGridViewTriState.True;


            dataGridView2.RowTemplate.Height = 60;


            dataGridView2.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);


            dataGridView2.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;


            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;


            dataGridView2.AllowUserToAddRows = false;

            dataGridView2.ReadOnly = true;

            dataGridView2.ColumnHeadersDefaultCellStyle.WrapMode =
    DataGridViewTriState.True;


            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                column.Width = 140;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select a schedule first.");
                return;
            }


            int savedScheduleId =
                Convert.ToInt32(
                    dataGridView1.CurrentRow.Tag
                );


            DialogResult result =
                MessageBox.Show(
                    "Submit this schedule for approval?",
                    "Confirm Submission",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );


            if (result != DialogResult.Yes)
                return;



            bool success =
                ScheduleRepository
                .SubmitScheduleForApproval(
                    savedScheduleId,
                    UserSession.UserId
                );


            if (success)
            {
                MessageBox.Show(
                    "Schedule submitted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadSavedSchedules();
            }
            else
            {
                MessageBox.Show(
                    "You already have a pending or approved request.",
                    "Cannot Submit",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }
    }
}
