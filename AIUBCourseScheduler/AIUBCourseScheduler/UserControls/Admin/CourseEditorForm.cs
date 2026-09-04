using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AIUBCourseScheduler.UserControls.Admin
{
    public partial class CourseEditorForm : Form
    {
        public CourseEditorForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //private void CourseEditorForm_Load(object sender, EventArgs e)
        //{
        //    comboBox1.Items.Add("Active");
        //    comboBox1.Items.Add("Inactive");

        //    comboBox1.SelectedIndex = -1;
        //}


        private void btnSaveCourse_Click(object sender, EventArgs e)
        {

            errorProvider1.Clear();

            bool isValid = true;


            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "Course Name is required.");
                isValid = false;
            }


            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "Department is required.");
                isValid = false;
            }


            if (comboBox1.SelectedIndex == -1)
            {
                errorProvider1.SetError(comboBox1, "Status is required.");
                isValid = false;
            }


            if (!isValid)
            {
                MessageBox.Show(
                    "Please fill in all required fields.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            MessageBox.Show(
                "Course saved successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

        }



      }
    } 
