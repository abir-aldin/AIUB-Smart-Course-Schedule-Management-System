using AIUBCourseScheduler.DataAccess;
using AIUBCourseScheduler.Services;
using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace AIUBCourseScheduler.UserControls.Student
{
    public partial class StudentProfileControl : Form
    {

        public StudentProfileControl()
        {
            InitializeComponent();

            LoadProfile();

            DisableEditing();
        }



        private void LoadProfile()
        {
            using SqlConnection connection =
                DatabaseConnection.GetConnection();


            connection.Open();


            string query = @"
                SELECT 
                    FullName,
                    StudentId,
                    Email

                FROM Users

                WHERE UserId = @UserId
            ";


            using SqlCommand command =
                new SqlCommand(query, connection);


            command.Parameters.AddWithValue(
                "@UserId",
                UserSession.UserId
            );


            using SqlDataReader reader =
                command.ExecuteReader();


            if (reader.Read())
            {
                // Profile display

                label3.Text =
                    reader["FullName"].ToString();

                label6.Text =
                    reader["StudentId"].ToString();

                label14.Text =
                    reader["Email"].ToString();



                // Fixed values (Option 2)

                label8.Text =
                    "Computer Science";


                label10.Text =
                    "BSc in Computer Science";


                label12.Text =
                    "1st Semester";



                // Edit fields

                textBox1.Text =
                    reader["StudentId"].ToString();

                textBox2.Text =
                    reader["FullName"].ToString();

                textBox3.Text =
                    reader["Email"].ToString();


                comboBox1.Text =
                    "Computer Science";

                comboBox2.Text =
                    "BSc in Computer Science";

                comboBox3.Text =
                    "1st Semester";
            }
        }




        private void button1_Click_1(object sender, EventArgs e)
        {
            // Edit button

            EnableEditing();
        }





        private void button4_Click(object sender, EventArgs e)
        {
            // Save button


            using SqlConnection connection =
                DatabaseConnection.GetConnection();


            connection.Open();


            string query = @"
                UPDATE Users

                SET FullName = @FullName

                WHERE UserId = @UserId
            ";


            using SqlCommand command =
                new SqlCommand(query, connection);


            command.Parameters.AddWithValue(
                "@FullName",
                textBox2.Text
            );


            command.Parameters.AddWithValue(
                "@UserId",
                UserSession.UserId
            );


            command.ExecuteNonQuery();



            MessageBox.Show(
                "Profile updated successfully."
            );


            DisableEditing();

            LoadProfile();
        }





        private void button3_Click(object sender, EventArgs e)
        {
            DisableEditing();

            LoadProfile();
        }





        private void EnableEditing()
        {
            textBox2.ReadOnly = false;

            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;


            button4.Enabled = true;
            button3.Enabled = true;
        }





        private void DisableEditing()
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;


            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;


            button4.Enabled = false;
            button3.Enabled = false;
        }





        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void label6_Click(object sender, EventArgs e)
        {

        }


        private void label20_Click(object sender, EventArgs e)
        {

        }

    }
}