using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AIUBCourseScheduler.UserControls.Admin
{
    public partial class CoursesControl : Form
    {
        List<Course> courses = new List<Course>();
        public CoursesControl()
        {
            InitializeComponent();


        }


        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search course code or name")
            {
                textBox1.Clear();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Search course code or name";
            }
        }
        private void LoadCourses()
        {
            courses.Clear();

            courses.Add(new Course
            {
                CourseCode = "CSE 311",
                CourseName = "Data Structures",
                Credits = 3.0,
                Department = "Computer Science & Engineering",
                Status = "Active"
            });

            courses.Add(new Course
            {
                CourseCode = "CSE 313",
                CourseName = "Object Oriented Programming",
                Credits = 3.0,
                Department = "Computer Science & Engineering",
                Status = "Active"
            });

            courses.Add(new Course
            {
                CourseCode = "MAT 221",
                CourseName = "Calculus II",
                Credits = 3.0,
                Department = "Mathematics",
                Status = "Active"
            });

            courses.Add(new Course
            {
                CourseCode = "PHY 205",
                CourseName = "Physics II",
                Credits = 3.0,
                Department = "Physics",
                Status = "Active"
            });

            courses.Add(new Course
            {
                CourseCode = "ENG 201",
                CourseName = "Technical Writing",
                Credits = 3.0,
                Department = "English",
                Status = "Active"
            });

            courses.Add(new Course
            {
                CourseCode = "CSE 101",
                CourseName = "Introduction to Computing",
                Credits = 3.0,
                Department = "Computer Science & Engineering",
                Status = "Inactive"
            });

            courses.Add(new Course
            {
                CourseCode = "EEE 201",
                CourseName = "Circuit Analysis",
                Credits = 3.0,
                Department = "Electrical & Electronic Engineering",
                Status = "Active"
            });

            courses.Add(new Course
            {
                CourseCode = "BUS 101",
                CourseName = "Introduction to Business",
                Credits = 3.0,
                Department = "Business Administration",
                Status = "Inactive"
            });

            courses.Add(new Course
            {
                CourseCode = "MAT 121",
                CourseName = "Calculus I",
                Credits = 3.0,
                Department = "Mathematics",
                Status = "Inactive"
            });

            courses.Add(new Course
            {
                CourseCode = "CHE 105",
                CourseName = "Chemistry I",
                Credits = 3.0,
                Department = "Chemistry",
                Status = "Active"
            });
        }
        private void ShowCourses()
        {
            dgvCourses.DataSource = null;
            dgvCourses.DataSource = courses;
        }

        private void CoursesControl_Load(object sender, EventArgs e)
        {
            LoadCourses();
            ShowCourses();
        }
        private void dgvCourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvCourses.Columns[e.ColumnIndex].Name == "EditColumn")
            {
                MessageBox.Show("Edit button working");
            }
            else if (dgvCourses.Columns[e.ColumnIndex].Name == "DeleteColumn")
            {
                MessageBox.Show("Delete button working");
            }
        }



    }
    }
    



