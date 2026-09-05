using AIUBCourseScheduler.DataAccess;
using AIUBCourseScheduler.Services;
using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace AIUBCourseScheduler.Forms
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }



        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxCurrent.Text))
            {
                MessageBox.Show(
                    "Enter current password."
                );
                return;
            }


            if (string.IsNullOrWhiteSpace(textBoxNew.Text))
            {
                MessageBox.Show(
                    "Enter new password."
                );
                return;
            }


            if (textBoxNew.Text != textBoxConfirm.Text)
            {
                MessageBox.Show(
                    "New password and confirm password do not match."
                );
                return;
            }



            using SqlConnection connection =
                DatabaseConnection.GetConnection();


            connection.Open();



            // Get old password hash

            string getPasswordQuery = @"
                SELECT PasswordHash
                FROM Users
                WHERE UserId = @UserId
            ";



            using SqlCommand getCommand =
                new SqlCommand(
                    getPasswordQuery,
                    connection
                );


            getCommand.Parameters.AddWithValue(
                "@UserId",
                UserSession.UserId
            );



            string oldHash =
                getCommand.ExecuteScalar()
                ?.ToString();



            if (oldHash == null)
            {
                MessageBox.Show(
                    "User not found."
                );

                return;
            }



            // Verify current password

            bool isValid =
                PasswordHelper.VerifyPassword(
                    textBoxCurrent.Text,
                    oldHash
                );



            if (!isValid)
            {
                MessageBox.Show(
                    "Current password is incorrect."
                );

                return;
            }



            // Hash new password

            string newHash =
                PasswordHelper.HashPassword(
                    textBoxNew.Text
                );



            // Update password

            string updateQuery = @"
                UPDATE Users

                SET PasswordHash = @PasswordHash

                WHERE UserId = @UserId
            ";



            using SqlCommand updateCommand =
                new SqlCommand(
                    updateQuery,
                    connection
                );


            updateCommand.Parameters.AddWithValue(
                "@PasswordHash",
                newHash
            );


            updateCommand.Parameters.AddWithValue(
                "@UserId",
                UserSession.UserId
            );



            int result =
                updateCommand.ExecuteNonQuery();



            if (result > 0)
            {
                MessageBox.Show(
                    "Password changed successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );


                Close();
            }
            else
            {
                MessageBox.Show(
                    "Password update failed."
                );
            }
        }




        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}