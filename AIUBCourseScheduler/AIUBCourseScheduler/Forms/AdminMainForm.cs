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
        public AdminMainForm()
        {
            InitializeComponent();
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
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
            AdminProfileControl adminProfileControl = new AdminProfileControl();

            adminProfileControl.TopLevel = false;
            adminProfileControl.FormBorderStyle = FormBorderStyle.None;
            adminProfileControl.Dock = DockStyle.Fill;
            adminProfileControl.ForeColor = Color.Black;
            panel2.Controls.Clear();
            panel2.Controls.Add(adminProfileControl);
            adminProfileControl.Show();
        }
    }
}
