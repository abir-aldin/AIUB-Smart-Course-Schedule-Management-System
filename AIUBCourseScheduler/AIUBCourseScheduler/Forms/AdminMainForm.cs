using AIUBCourseScheduler.Services;
using AIUBCourseScheduler.UserControls.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AIUBCourseScheduler.Forms
{
    public partial class AdminMainForm : Form
    {

        public bool IsLoggingOut { get; private set; }
        public AdminMainForm()
        {
            InitializeComponent();
            FormClosing += AdminMainForm_FormClosing;

        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetActiveButton(button1);

            AdminDashboardControl dashboardControl = new AdminDashboardControl();

            dashboardControl.TopLevel = false;
            dashboardControl.FormBorderStyle = FormBorderStyle.None;
            dashboardControl.Dock = DockStyle.Fill;
            dashboardControl.ForeColor = Color.Black;

            panel2.Controls.Clear();
            panel2.Controls.Add(dashboardControl);

            dashboardControl.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetActiveButton(button2);
            ImportExcelControl IE = new ImportExcelControl();

            IE.TopLevel = false;
            IE.FormBorderStyle = FormBorderStyle.None;
            IE.Dock = DockStyle.Fill;
            IE.ForeColor = Color.Black;
            panel2.Controls.Clear();
            panel2.Controls.Add(IE);
            IE.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetActiveButton(button3);
            CoursesControl coursesControl = new CoursesControl();

            coursesControl.TopLevel = false;
            coursesControl.FormBorderStyle = FormBorderStyle.None;
            coursesControl.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(coursesControl);
            coursesControl.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SetActiveButton(button4);
            SectionsControl sectionsControl = new SectionsControl();

            sectionsControl.TopLevel = false;
            sectionsControl.FormBorderStyle = FormBorderStyle.None;
            sectionsControl.Dock = DockStyle.Fill;
            sectionsControl.ForeColor = Color.Black;
            panel2.Controls.Clear();
            panel2.Controls.Add(sectionsControl);
            sectionsControl.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SetActiveButton(button5);
            ScheduleRequestsControl scheduleRequestsControl = new ScheduleRequestsControl();

            scheduleRequestsControl.TopLevel = false;
            scheduleRequestsControl.FormBorderStyle = FormBorderStyle.None;
            scheduleRequestsControl.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(scheduleRequestsControl);
            scheduleRequestsControl.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SetActiveButton(button7);
            AdminProfileControl adminProfileControl = new AdminProfileControl();

            adminProfileControl.TopLevel = false;
            adminProfileControl.FormBorderStyle = FormBorderStyle.None;
            adminProfileControl.Dock = DockStyle.Fill;
            adminProfileControl.ForeColor = Color.Black;
            panel2.Controls.Clear();
            panel2.Controls.Add(adminProfileControl);
            adminProfileControl.Show();
        }

        private void SetActiveButton(Button selectedButton)
        {
            foreach (Control control in panel1.Controls)
            {
                if (control is Button button)
                {
                    // সব button-এর normal color
                    button.BackColor = SystemColors.HotTrack;
                    button.ForeColor = Color.White;
                }
            }

            // বর্তমানে selected button-এর color
            selectedButton.BackColor =
                Color.FromArgb(0, 51, 102);

            selectedButton.ForeColor = Color.White;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SetActiveButton(button6);

            UsersControl usersControl = new UsersControl();

            usersControl.TopLevel = false;
            usersControl.FormBorderStyle = FormBorderStyle.None;
            usersControl.Dock = DockStyle.Fill;
            usersControl.ForeColor = Color.Black;

            panel2.Controls.Clear();
            panel2.Controls.Add(usersControl);

            usersControl.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                    "Are you sure you want to log out?",
                    "Confirm Logout",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                IsLoggingOut = true;
                UserSession.Clear();
                Close();
            }
        }

        private void AdminMainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            // Logout button থেকে Close হলে আবার confirmation লাগবে না
            if (IsLoggingOut)
            {
                return;
            }

            // শুধু X button দিয়ে বন্ধ করার সময় confirmation
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show(
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
    }
}
