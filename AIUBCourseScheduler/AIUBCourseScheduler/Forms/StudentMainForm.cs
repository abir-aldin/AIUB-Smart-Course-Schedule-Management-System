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
        public StudentMainForm()
        {
            InitializeComponent();
        }

        private void StudentMainForm_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            RequestStatusControl requestStatusControl = new RequestStatusControl();

            requestStatusControl.TopLevel = false;
            requestStatusControl.FormBorderStyle = FormBorderStyle.None;
            requestStatusControl.Dock = DockStyle.Fill;
            requestStatusControl.ForeColor = Color.Black;
            panel3.Controls.Clear();
            panel3.Controls.Add(requestStatusControl);
            requestStatusControl.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
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

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
