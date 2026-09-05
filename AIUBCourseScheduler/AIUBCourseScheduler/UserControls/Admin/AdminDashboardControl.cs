using AIUBCourseScheduler.DataAccess;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace AIUBCourseScheduler.UserControls.Admin
{
    public partial class AdminDashboardControl : UserControl
    {

        public AdminDashboardControl()
        {
            InitializeComponent();

            LoadDashboard();
        }



        private void LoadDashboard()
        {
            LoadCounts();

            LoadRecentRequests();
        }



        private void LoadCounts()
        {
            using SqlConnection connection =
                DatabaseConnection.GetConnection();


            connection.Open();



            // Students Count

            lblStudentsCount.Text =
                GetCount(
                    connection,
                    "SELECT COUNT(*) FROM Users WHERE UserRole='Student'"
                ).ToString();



            // Courses Count

            lblCoursesCount.Text =
                GetCount(
                    connection,
                    "SELECT COUNT(*) FROM Courses"
                ).ToString();



            // Sections Count

            lblSectionsCount.Text =
                GetCount(
                    connection,
                    "SELECT COUNT(*) FROM CourseOfferings"
                ).ToString();



            // Pending

            lblPendingCount.Text =
                GetCount(
                    connection,
                    @"SELECT COUNT(*)
                      FROM ScheduleRequests
                      WHERE RequestStatus='Pending'"
                ).ToString();



            // Approved

            lblApprovedCount.Text =
                GetCount(
                    connection,
                    @"SELECT COUNT(*)
                      FROM ScheduleRequests
                      WHERE RequestStatus='Approved'"
                ).ToString();



            // Rejected

            lblRejectedCount.Text =
                GetCount(
                    connection,
                    @"SELECT COUNT(*)
                      FROM ScheduleRequests
                      WHERE RequestStatus='Rejected'"
                ).ToString();
        }




        private int GetCount(
            SqlConnection connection,
            string query)
        {
            using SqlCommand command =
                new SqlCommand(
                    query,
                    connection);


            return Convert.ToInt32(
                command.ExecuteScalar()
            );
        }




        private void LoadRecentRequests()
        {

            using SqlConnection connection =
                DatabaseConnection.GetConnection();


            connection.Open();



            string query = @"
SELECT TOP 10

    U.FullName AS Student,

    SR.ScheduleName,

    SR.RequestStatus,

    SR.SubmittedAt


FROM ScheduleRequests SR


INNER JOIN Users U

ON SR.StudentUserId = U.UserId


ORDER BY SR.SubmittedAt DESC
";



            using SqlDataAdapter adapter =
                new SqlDataAdapter(
                    query,
                    connection);



            DataTable table =
                new DataTable();



            adapter.Fill(table);



            dgvRecentRequests.DataSource =
                table;



            dgvRecentRequests.Columns["SubmittedAt"]
                .HeaderText =
                "Submitted Date";


            dgvRecentRequests.Columns["Student"]
                .HeaderText =
                "Student Name";


            dgvRecentRequests.Columns["ScheduleName"]
                .HeaderText =
                "Schedule";


            dgvRecentRequests.Columns["RequestStatus"]
                .HeaderText =
                "Status";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}