using AIUBCourseScheduler.DataAccess;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AIUBCourseScheduler.UserControls.Admin
{
    public partial class AdminDashboardControl : UserControl
    {
        public AdminDashboardControl()
        {
            InitializeComponent();

            ConfigureRecentRequestsGrid();

            Load -= AdminDashboardControl_Load;
            Load += AdminDashboardControl_Load;
        }

        private void AdminDashboardControl_Load(
            object? sender,
            EventArgs e)
        {
            LoadDashboard();
        }

        private void ConfigureRecentRequestsGrid()
        {
            dgvRecentRequests.AutoGenerateColumns = true;
            dgvRecentRequests.AllowUserToAddRows = false;
            dgvRecentRequests.AllowUserToDeleteRows = false;
            dgvRecentRequests.AllowUserToResizeRows = false;
            dgvRecentRequests.ReadOnly = true;
            dgvRecentRequests.RowHeadersVisible = false;
            dgvRecentRequests.MultiSelect = false;
            dgvRecentRequests.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvRecentRequests.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvRecentRequests.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvRecentRequests.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvRecentRequests.CellFormatting -=
                dgvRecentRequests_CellFormatting;

            dgvRecentRequests.CellFormatting +=
                dgvRecentRequests_CellFormatting;
        }

        private void LoadDashboard()
        {
            try
            {
                using SqlConnection connection =
                    DatabaseConnection.GetConnection();

                connection.Open();

                LoadCounts(connection);
                LoadRecentRequests(connection);
            }
            catch (SqlException ex)
            {
                ShowZeroCounts();
                dgvRecentRequests.DataSource = null;

                MessageBox.Show(
                    "Could not load admin dashboard.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                ShowZeroCounts();
                dgvRecentRequests.DataSource = null;

                MessageBox.Show(
                    "Admin dashboard could not be loaded.\n\n" +
                    ex.Message,
                    "Dashboard Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LoadCounts(SqlConnection connection)
        {
            const string query = @"
                SELECT
                    (
                        SELECT COUNT(*)
                        FROM dbo.Users
                        WHERE UserRole = 'Student'
                    ) AS StudentCount,

                    (
                        SELECT COUNT(*)
                        FROM dbo.Courses
                    ) AS CourseCount,

                    (
                        SELECT COUNT(*)
                        FROM dbo.CourseOfferings
                    ) AS SectionCount,

                    (
                        SELECT COUNT(*)
                        FROM dbo.ScheduleRequests
                        WHERE RequestStatus = 'Pending'
                    ) AS PendingCount,

                    (
                        SELECT COUNT(*)
                        FROM dbo.ScheduleRequests
                        WHERE RequestStatus = 'Approved'
                    ) AS ApprovedCount,

                    (
                        SELECT COUNT(*)
                        FROM dbo.ScheduleRequests
                        WHERE RequestStatus = 'Rejected'
                    ) AS RejectedCount;";

            using SqlCommand command =
                new SqlCommand(query, connection);

            using SqlDataReader reader =
                command.ExecuteReader();

            if (!reader.Read())
            {
                ShowZeroCounts();
                return;
            }

            /*
             * Designer-এ card-এর visible count labels এগুলো:
             * label2  = Students
             * label7  = Courses
             * label6  = Sections
             * label5  = Pending
             * label4  = Approved
             * label8  = Rejected
             */
            label2.Text = reader.GetInt32(0).ToString();
            label7.Text = reader.GetInt32(1).ToString();
            label6.Text = reader.GetInt32(2).ToString();
            label5.Text = reader.GetInt32(3).ToString();
            label4.Text = reader.GetInt32(4).ToString();
            label8.Text = reader.GetInt32(5).ToString();
        }

        private void LoadRecentRequests(SqlConnection connection)
        {
            const string query = @"
                SELECT TOP (10)
                    U.FullName AS Student,
                    SR.ScheduleName,
                    SR.RequestStatus,
                    SR.SubmittedAt
                FROM dbo.ScheduleRequests AS SR
                INNER JOIN dbo.Users AS U
                    ON U.UserId = SR.StudentUserId
                ORDER BY SR.SubmittedAt DESC;";

            using SqlDataAdapter adapter =
                new SqlDataAdapter(query, connection);

            DataTable table = new DataTable();
            adapter.Fill(table);

            dgvRecentRequests.DataSource = null;
            dgvRecentRequests.DataSource = table;

            if (dgvRecentRequests.Columns["Student"] != null)
            {
                dgvRecentRequests.Columns["Student"].HeaderText =
                    "Student Name";
            }

            if (dgvRecentRequests.Columns["ScheduleName"] != null)
            {
                dgvRecentRequests.Columns["ScheduleName"].HeaderText =
                    "Schedule";
            }

            if (dgvRecentRequests.Columns["RequestStatus"] != null)
            {
                dgvRecentRequests.Columns["RequestStatus"].HeaderText =
                    "Status";
            }

            if (dgvRecentRequests.Columns["SubmittedAt"] != null)
            {
                dgvRecentRequests.Columns["SubmittedAt"].HeaderText =
                    "Submitted Date";

                dgvRecentRequests.Columns["SubmittedAt"]
                    .DefaultCellStyle.Format =
                    "dd MMM yyyy, h:mm tt";
            }

            dgvRecentRequests.ClearSelection();
        }

        private void dgvRecentRequests_CellFormatting(
            object? sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            DataGridViewColumn column =
                dgvRecentRequests.Columns[e.ColumnIndex];

            if (column.Name != "RequestStatus")
            {
                return;
            }

            string status = Convert.ToString(e.Value) ?? "";

            e.CellStyle.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            if (status.Equals(
                "Approved",
                StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.BackColor =
                    Color.FromArgb(225, 250, 235);

                e.CellStyle.ForeColor = Color.ForestGreen;
            }
            else if (status.Equals(
                "Rejected",
                StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.BackColor =
                    Color.FromArgb(255, 235, 235);

                e.CellStyle.ForeColor = Color.Firebrick;
            }
            else
            {
                e.CellStyle.BackColor =
                    Color.FromArgb(255, 248, 220);

                e.CellStyle.ForeColor = Color.DarkOrange;
            }
        }

        private void ShowZeroCounts()
        {
            label2.Text = "0";
            label7.Text = "0";
            label6.Text = "0";
            label5.Text = "0";
            label4.Text = "0";
            label8.Text = "0";
        }
    }
}
