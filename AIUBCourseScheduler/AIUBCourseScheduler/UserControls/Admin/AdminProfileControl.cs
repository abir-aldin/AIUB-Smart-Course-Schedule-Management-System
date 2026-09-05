using AIUBCourseScheduler.DataAccess;
using AIUBCourseScheduler.Forms;
using AIUBCourseScheduler.Services;
using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace AIUBCourseScheduler.UserControls.Admin
{
    public partial class AdminProfileControl : Form
    {

        public AdminProfileControl()
        {
            InitializeComponent();

            LoadProfile();

            DisableEditing();

            button2.Click += button2_Click;
            button1.Click += button1_Click;
            button3.Click += button3_Click;
            button4.Click += button4_Click;
        }



        private void LoadProfile()
        {
            using SqlConnection connection =
                DatabaseConnection.GetConnection();


            connection.Open();


            string query = @"
                SELECT 
                    FullName,
                    Email,
                    UserRole

                FROM Users

                WHERE UserId=@UserId
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

                textBox1.Text =
                    UserSession.UserId.ToString();


                textBox2.Text =
                    reader["FullName"].ToString();


                textBox3.Text =
                    reader["Email"].ToString();


                textBox4.Text =
                    reader["UserRole"].ToString();


                // Fixed values

                textBox5.Text =
                    "Administration";


                textBox6.Text =
                    "N/A";



                // Summary section

                label10.Text =
                    reader["UserRole"].ToString();


                label12.Text =
                    "System Administrator";
            }
        }





        private void button2_Click(object sender, EventArgs e)
        {
            // Enable only editable field

            textBox2.ReadOnly = false;   // Full Name editable

            // Keep these locked
            textBox1.ReadOnly = true;    // Admin ID
            textBox3.ReadOnly = true;    // Email
            textBox4.ReadOnly = true;    // Role
            textBox5.ReadOnly = true;    // Department
            textBox6.ReadOnly = true;    // Phone


            button1.Enabled = true;     // Save Changes
            button3.Enabled = true;     // Cancel


            textBox2.Focus();
        }





        private void button1_Click(object sender, EventArgs e)
        {
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
                textBox2.Text.Trim()
            );


            command.Parameters.AddWithValue(
                "@UserId",
                UserSession.UserId
            );


            int result =
                command.ExecuteNonQuery();


            if (result > 0)
            {
                MessageBox.Show(
                    "Profile updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                DisableEditing();

                LoadProfile();
            }
            else
            {
                MessageBox.Show(
                    "Update failed.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }





        private void button3_Click(object sender, EventArgs e)
        {
            DisableEditing();

            LoadProfile();

            MessageBox.Show(
                "Changes cancelled.",
                "Cancelled",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }





        private void button4_Click(object sender, EventArgs e)
        {
            ChangePasswordForm form =
            new ChangePasswordForm();

            form.ShowDialog();
        }





        private void EnableEditing()
        {
            textBox2.ReadOnly = false;

            button1.Enabled = true;
            button3.Enabled = true;
        }





        private void DisableEditing()
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;


            button1.Enabled = false;
            button3.Enabled = false;
        }






        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

    }
}