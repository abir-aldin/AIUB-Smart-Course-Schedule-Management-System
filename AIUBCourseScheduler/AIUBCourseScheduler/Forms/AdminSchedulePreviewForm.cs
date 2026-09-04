using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AIUBCourseScheduler.DataAccess;
using AIUBCourseScheduler.Models;

namespace AIUBCourseScheduler.Forms
{
    public partial class AdminSchedulePreviewForm : Form
    {
        private int savedScheduleId;

        public AdminSchedulePreviewForm(int savedScheduleId)
        {
            InitializeComponent();

            this.savedScheduleId = savedScheduleId;

            LoadSchedulePreview();
        }


        private void LoadSchedulePreview()
        {
            List<SavedScheduleDetailViewModel> details =
                ScheduleRepository.GetScheduleDetails(savedScheduleId);


            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();


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



            DataGridViewTextBoxColumn dayColumn =
                new DataGridViewTextBoxColumn();

            dayColumn.HeaderText = "Day";
            dayColumn.Name = "Day";

            dataGridView1.Columns.Add(dayColumn);



            foreach (string time in timeSlots)
            {
                DataGridViewTextBoxColumn column =
                    new DataGridViewTextBoxColumn();

                column.HeaderText = time;
                column.Name = time;

                dataGridView1.Columns.Add(column);
            }



            string[] days =
            {
        "Sunday",
        "Monday",
        "Tuesday",
        "Wednesday",
        "Thursday"
    };


            foreach (string day in days)
            {
                int row = dataGridView1.Rows.Add();

                dataGridView1.Rows[row]
                    .Cells["Day"]
                    .Value = day;
            }



            foreach (var item in details)
            {
                string time =
                    $"{DateTime.Today.Add(item.StartTime):hh:mm tt}-{DateTime.Today.Add(item.EndTime):hh:mm tt}";


                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Day"].Value?.ToString() == item.Day)
                    {
                        row.Cells[time].Value =
                            $"{item.CourseTitle}\nSection: {item.Section}\nRoom: {item.Room}";

                        break;
                    }
                }
            }


            FormatGrid();
        }



        private void FormatGrid()
        {
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.AllCells;


            dataGridView1.DefaultCellStyle.WrapMode =
                DataGridViewTriState.True;


            dataGridView1.RowTemplate.Height = 60;


            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);


            dataGridView1.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;


            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;


            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.ReadOnly = true;

            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode =
    DataGridViewTriState.True;


            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = 140;
            }
        }
        



        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}