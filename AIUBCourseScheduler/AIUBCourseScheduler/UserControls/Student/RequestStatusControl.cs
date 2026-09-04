using AIUBCourseScheduler.DataAccess;
using AIUBCourseScheduler.DataAccess;
using AIUBCourseScheduler.Models;
using AIUBCourseScheduler.Models;
using AIUBCourseScheduler.Services;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AIUBCourseScheduler.UserControls.Student
{
    public partial class RequestStatusControl : Form
    {
        public RequestStatusControl()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private List<ScheduleRequestViewModel> requests =
    new List<ScheduleRequestViewModel>();


        private void ScheduleRequestsControl_Load(object sender, EventArgs e)
        {
            LoadRequests();
        }



        private void LoadRequests()
        {
            requests =
    ScheduleRepository
    .GetStudentScheduleRequests(
        UserSession.UserId
    );


            dataGridView1.Rows.Clear();


            int pending = 0;
            int approved = 0;
            int rejected = 0;


            foreach (var request in requests)
            {
                int row =
                    dataGridView1.Rows.Add();


                dataGridView1.Rows[row]
                    .Cells["colRequestID"]
                    .Value =
                    request.RequestId;


                dataGridView1.Rows[row]
                    .Cells["colSchedule"]
                    .Value =
                    request.ScheduleName;


                dataGridView1.Rows[row]
                    .Cells["ColSubmittedDate"]
                    .Value =
                    request.SubmittedAt
                    .ToString("dd MMM yyyy");


                dataGridView1.Rows[row]
                    .Cells["ColStatus"]
                    .Value =
                    request.RequestStatus;


                dataGridView1.Rows[row]
                    .Cells["colAdminComment"]
                    .Value =
                    request.AdminComment ?? "";


                dataGridView1.Rows[row]
                    .Cells["colAction"]
                    .Value =
                    "View";


                dataGridView1.Rows[row]
                    .Tag =
                    request;


                if (request.RequestStatus == "Pending")
                {
                    pending++;
                }
                else if (request.RequestStatus == "Approved")
                {
                    approved++;
                }
                else if (request.RequestStatus == "Rejected")
                {
                    rejected++;
                }
            }


            label10.Text = pending.ToString();

            label13.Text = approved.ToString();

            label14.Text = rejected.ToString();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
