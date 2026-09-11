using AIUBCourseScheduler.Services;
using AIUBCourseScheduler.UserControls.Student;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AIUBCourseScheduler.Forms
{
    public partial class StudentMainForm : Form
    {

        public bool IsLoggingOut { get; private set; }
        public StudentMainForm()
        {
            InitializeComponent();

            FormClosing -= StudentMainForm_FormClosing;
            FormClosing += StudentMainForm_FormClosing;
        }

        private void StudentMainForm_Load(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            SetActiveButton(button2);
            SelectCoursesControl selectCoursesControl = new SelectCoursesControl();

            selectCoursesControl.TopLevel = false;
            selectCoursesControl.FormBorderStyle = FormBorderStyle.None;
            selectCoursesControl.Dock = DockStyle.Fill;
            selectCoursesControl.ForeColor = Color.Black;
            panel3.Controls.Clear();
            panel3.Controls.Add(selectCoursesControl);
            selectCoursesControl.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SetActiveButton(button4);
            MySchedulesControl myScheduleControl = new MySchedulesControl();

            myScheduleControl.TopLevel = false;
            myScheduleControl.FormBorderStyle = FormBorderStyle.None;
            myScheduleControl.Dock = DockStyle.Fill;
            myScheduleControl.ForeColor = Color.Black;
            panel3.Controls.Clear();
            panel3.Controls.Add(myScheduleControl);
            myScheduleControl.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SetActiveButton(button6);
            StudentProfileControl studentProfileControl = new StudentProfileControl();

            studentProfileControl.TopLevel = false;
            studentProfileControl.FormBorderStyle = FormBorderStyle.None;
            studentProfileControl.Dock = DockStyle.Fill;
            studentProfileControl.ForeColor = Color.Black;
            panel3.Controls.Clear();
            panel3.Controls.Add(studentProfileControl);
            studentProfileControl.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetActiveButton(button3);
            GenerateScheduleControl generateScheduleControl = new GenerateScheduleControl();

            generateScheduleControl.TopLevel = false;
            generateScheduleControl.FormBorderStyle = FormBorderStyle.None;
            generateScheduleControl.Dock = DockStyle.Fill;
            generateScheduleControl.ForeColor = Color.Black;
            panel3.Controls.Clear();
            panel3.Controls.Add(generateScheduleControl);
            generateScheduleControl.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SetActiveButton(button7);
            DialogResult result =
    MessageBox.Show(
        "Are you sure you want to log out?",
        "Confirm Logout",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );

            if (result == DialogResult.Yes)
            {
                IsLoggingOut = true;

                UserSession.Clear();

                Close();
            }

        }

        private void StudentMainForm_FormClosing(
    object? sender,
    FormClosingEventArgs e)
        {
            // Logout button থেকে form বন্ধ হলে confirmation লাগবে না
            if (IsLoggingOut)
            {
                return;
            }

            // শুধু X button দিয়ে বন্ধ করার সময় confirmation
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result =
                    MessageBox.Show(
                        "Are you sure you want to exit the application?",
                        "Confirm Exit",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetActiveButton(button1);
            StudentDashboardControl studentDashboardControl = new StudentDashboardControl();

            studentDashboardControl.TopLevel = false;
            studentDashboardControl.FormBorderStyle = FormBorderStyle.None;
            studentDashboardControl.Dock = DockStyle.Fill;
            studentDashboardControl.ForeColor = Color.Black;
            panel3.Controls.Clear();
            panel3.Controls.Add(studentDashboardControl);
            studentDashboardControl.Show();
        }

        private void SetActiveButton(Button selectedButton)
        {
            foreach (Control control in panel1.Controls)
            {
                if (control is Button button)
                {
                    // সব sidebar button normal হবে
                    button.BackColor = SystemColors.HotTrack;
                    button.ForeColor = Color.White;
                }
            }

            // বর্তমানে selected button highlighted হবে
            selectedButton.BackColor =
                Color.FromArgb(0, 51, 102);

            selectedButton.ForeColor = Color.White;
        }
    }
}
