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
    public partial class StudentDashboardControl : Form
    {
        private const string StatusTextColumnName =
            "DashboardStatusColumn";

        private const string AdminCommentColumnName =
            "AdminCommentColumn";

        public StudentDashboardControl()
        {
            InitializeComponent();
            ConfigureDashboardGrid();
        }

        private void ConfigureDashboardGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView1.DefaultCellStyle.WrapMode =
                DataGridViewTriState.True;

            dataGridView1.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            scheduleColumn.HeaderText = "Schedule";
            scheduleColumn.SortMode =
                DataGridViewColumnSortMode.NotSortable;

            CreatedDateColumn.HeaderText = "Submitted Date";
            CreatedDateColumn.SortMode =
                DataGridViewColumnSortMode.NotSortable;

            /*
             * Designer-এর StatusColumn একটি Button column।
             * Dashboard-এ status শুধু text হিসেবে দেখানো হবে,
             * তাই runtime-এ সেটি TextBox column দিয়ে বদলানো হচ্ছে।
             */
            if (dataGridView1.Columns.Contains(StatusColumn))
            {
                dataGridView1.Columns.Remove(StatusColumn);
            }

            DataGridViewTextBoxColumn statusTextColumn =
                new DataGridViewTextBoxColumn
                {
                    Name = StatusTextColumnName,
                    HeaderText = "Status",
                    FillWeight = 75,
                    SortMode =
                        DataGridViewColumnSortMode.NotSortable
                };

            DataGridViewTextBoxColumn adminCommentColumn =
                new DataGridViewTextBoxColumn
                {
                    Name = AdminCommentColumnName,
                    HeaderText = "Admin Comment",
                    FillWeight = 120,
                    SortMode =
                        DataGridViewColumnSortMode.NotSortable
                };

            dataGridView1.Columns.Add(statusTextColumn);
            dataGridView1.Columns.Add(adminCommentColumn);
            dataGridView1.ClearSelection();
        }

        private void StudentDashboardControl_Load(
            object sender,
            EventArgs e)
        {
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            if (!UserSession.IsLoggedIn)
            {
                ShowEmptyDashboard();
                return;
            }

            try
            {
                List<SavedScheduleViewModel> savedSchedules =
                    ScheduleRepository.GetStudentSavedSchedules(
                        UserSession.UserId
                    );

                List<ScheduleRequestViewModel> requests =
                    ScheduleRepository.GetStudentScheduleRequests(
                        UserSession.UserId
                    );

                label1.Text = string.IsNullOrWhiteSpace(
                    UserSession.FullName
                )
                    ? "Welcome to Your Dashboard"
                    : $"Welcome, {UserSession.FullName}";

                label9.Text =
                    CourseSelectionSession.SelectedCourses.Count
                        .ToString();

                label10.Text = savedSchedules.Count.ToString();

                label13.Text = requests.Count(request =>
                    string.Equals(
                        request.RequestStatus,
                        "Pending",
                        StringComparison.OrdinalIgnoreCase
                    )
                ).ToString();

                label14.Text = requests.Count(request =>
                    string.Equals(
                        request.RequestStatus,
                        "Approved",
                        StringComparison.OrdinalIgnoreCase
                    )
                ).ToString();

                label5.Text = "Saved\r\nSchedules";

                ShowRecentRequests(requests);
            }
            catch (SqlException ex)
            {
                ShowEmptyDashboard();

                MessageBox.Show(
                    "Could not load dashboard information.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                ShowEmptyDashboard();

                MessageBox.Show(
                    "Dashboard could not be loaded.\n\n" +
                    ex.Message,
                    "Dashboard Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ShowRecentRequests(
            IEnumerable<ScheduleRequestViewModel> requests)
        {
            dataGridView1.Rows.Clear();

            foreach (ScheduleRequestViewModel request in requests.Take(5))
            {
                int rowIndex = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[rowIndex];

                row.Cells["scheduleColumn"].Value =
                    request.ScheduleName;

                row.Cells["CreatedDateColumn"].Value =
                    request.SubmittedAt.ToString("dd MMM yyyy");

                DataGridViewCell statusCell =
                    row.Cells[StatusTextColumnName];

                statusCell.Value = request.RequestStatus;

                row.Cells[AdminCommentColumnName].Value =
                    string.IsNullOrWhiteSpace(request.AdminComment)
                        ? "-"
                        : request.AdminComment;

                ApplyStatusStyle(statusCell, request.RequestStatus);
            }

            dataGridView1.ClearSelection();
        }

        private static void ApplyStatusStyle(
            DataGridViewCell statusCell,
            string status)
        {
            statusCell.Style.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            if (string.Equals(
                status,
                "Approved",
                StringComparison.OrdinalIgnoreCase))
            {
                statusCell.Style.BackColor =
                    Color.FromArgb(220, 245, 225);

                statusCell.Style.ForeColor = Color.ForestGreen;
            }
            else if (string.Equals(
                status,
                "Rejected",
                StringComparison.OrdinalIgnoreCase))
            {
                statusCell.Style.BackColor =
                    Color.FromArgb(255, 225, 225);

                statusCell.Style.ForeColor = Color.Firebrick;
            }
            else
            {
                statusCell.Style.BackColor =
                    Color.FromArgb(255, 241, 204);

                statusCell.Style.ForeColor = Color.DarkOrange;
            }
        }

        private void ShowEmptyDashboard()
        {
            label9.Text = "0";
            label10.Text = "0";
            label13.Text = "0";
            label14.Text = "0";

            dataGridView1.Rows.Clear();
            dataGridView1.ClearSelection();
        }

        private void panel3_Paint(
            object sender,
            PaintEventArgs e)
        {

        }

        private void label5_Click(
            object sender,
            EventArgs e)
        {

        }

        private void label19_Click(
            object sender,
            EventArgs e)
        {

        }
    }
}
