using AIUBCourseScheduler.DataAccess;
using AIUBCourseScheduler.Forms;
using AIUBCourseScheduler.Models;
using AIUBCourseScheduler.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AIUBCourseScheduler.UserControls.Admin
{
    public partial class ScheduleRequestsControl : Form
    {
        private ScheduleRequestViewModel? selectedRequest;

        private List<ScheduleRequestViewModel> requests =
            new List<ScheduleRequestViewModel>();


        public ScheduleRequestsControl()
        {
            InitializeComponent();
        }


        private void ScheduleRequestsControl_Load(object sender, EventArgs e)
        {
            LoadRequests();

            button4.Enabled = false;
            button5.Enabled = false;
        }



        private void LoadRequests()
        {
            requests =
                ScheduleRepository.GetAllScheduleRequests();


            dgvRequests.Rows.Clear();


            foreach (var request in requests)
            {
                int row =
                    dgvRequests.Rows.Add();


                dgvRequests.Rows[row].Tag = request;


                dgvRequests.Rows[row]
                    .Cells["colRequestId"]
                    .Value =
                    request.RequestId;


                dgvRequests.Rows[row]
                    .Cells["colStudent"]
                    .Value =
                    request.StudentName;


                dgvRequests.Rows[row]
                    .Cells["colSubmittedDate"]
                    .Value =
                    request.SubmittedAt
                    .ToString("dd MMM yyyy");


                dgvRequests.Rows[row]
                    .Cells["colStatus"]
                    .Value =
                    request.RequestStatus;


                dgvRequests.Rows[row]
                    .Cells["colActions"]
                    .Value =
                    "View";
            }


            label10.Text =
                requests.Count(x =>
                x.RequestStatus == "Pending")
                .ToString();


            label6.Text =
                requests.Count(x =>
                x.RequestStatus == "Approved")
                .ToString();


            label8.Text =
                requests.Count(x =>
                x.RequestStatus == "Rejected")
                .ToString();
        }



        private void dgvRequests_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


            selectedRequest =
                dgvRequests.Rows[e.RowIndex]
                .Tag as ScheduleRequestViewModel;


            if (selectedRequest == null)
                return;


            UpdateButtonState();


            dataGridView1.Rows.Clear();


            var courses =
                ScheduleRepository
                .GetRequestCourses(
                    selectedRequest.SavedScheduleId
                );


            courses =
                courses
                .GroupBy(x => new
                {
                    x.CourseTitle,
                    x.Section
                })
                .Select(x => x.First())
                .ToList();


            foreach (var course in courses)
            {
                int row =
                    dataGridView1.Rows.Add();


                dataGridView1.Rows[row]
                    .Cells["colCourseTitle"]
                    .Value =
                    course.CourseTitle;


                dataGridView1.Rows[row]
                    .Cells["colSection"]
                    .Value =
                    course.Section;
            }
        }

        private void UpdateButtonState()
        {
            if (selectedRequest == null)
            {
                button4.Enabled = false;
                button5.Enabled = false;
                return;
            }


            if (selectedRequest.RequestStatus == "Pending")
            {
                button4.Enabled = true;
                button5.Enabled = true;
            }
            else
            {
                button4.Enabled = false;
                button5.Enabled = false;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedRequest == null)
            {
                MessageBox.Show(
                    "Select a request first");
                return;
            }


            AdminSchedulePreviewForm preview =
                new AdminSchedulePreviewForm(
                    selectedRequest.SavedScheduleId
                );


            preview.ShowDialog();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            if (selectedRequest == null)
            {
                MessageBox.Show(
                    "Select a request first");
                return;
            }


            bool success =
                ScheduleRepository
                .ApproveScheduleRequest(
                    selectedRequest.RequestId,
                    UserSession.UserId
                );


            if (success)
            {
                MessageBox.Show(
                    "Schedule approved successfully."
                );


                LoadRequests();


                selectedRequest = null;


                dataGridView1.Rows.Clear();


                UpdateButtonState();
            }
            else
            {
                MessageBox.Show(
                    "Cannot approve. One or more sections are full."
                );
            }
        }



        private void button5_Click(object sender, EventArgs e)
        {
            if (selectedRequest == null)
            {
                MessageBox.Show(
                    "Select a request first");
                return;
            }


            string comment =
                Microsoft.VisualBasic.Interaction.InputBox(
                    "Enter rejection reason:",
                    "Reject Schedule",
                    ""
                );


            bool success =
                ScheduleRepository
                .RejectScheduleRequest(
                    selectedRequest.RequestId,
                    UserSession.UserId,
                    comment
                );


            if (success)
            {
                MessageBox.Show(
                    "Schedule rejected successfully."
                );


                LoadRequests();


                selectedRequest = null;


                dataGridView1.Rows.Clear();


                UpdateButtonState();
            }
            else
            {
                MessageBox.Show(
                    "Rejection failed."
                );
            }
        }



        private void label8_Click(object sender, EventArgs e)
        {

        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}