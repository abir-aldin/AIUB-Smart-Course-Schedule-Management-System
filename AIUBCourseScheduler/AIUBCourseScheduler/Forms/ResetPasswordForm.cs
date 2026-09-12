using AIUBCourseScheduler.DataAccess;
using AIUBCourseScheduler.Services;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AIUBCourseScheduler.Forms
{
    public partial class ResetPasswordForm : Form
    {
        private readonly string receiverEmail;

        public ResetPasswordForm()
            : this("example@gmail.com")
        {
        }

        public ResetPasswordForm(string email)
        {
            InitializeComponent();

            receiverEmail =
                email.Trim().ToLowerInvariant();

            emailValueLabel.Text = receiverEmail;
            AcceptButton = button1;
        }

        private async void button1_Click(
            object sender,
            EventArgs e)
        {
            string newPassword = textBox1.Text;
            string confirmPassword = textBox2.Text;

            if (string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show(
                    "Please enter and confirm your new password.",
                    "Password Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (newPassword.Length < 8)
            {
                MessageBox.Show(
                    "Password must contain at least 8 characters.",
                    "Weak Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                textBox1.Focus();
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show(
                    "New password and confirm password do not match.",
                    "Password Mismatch",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                textBox2.Clear();
                textBox2.Focus();
                return;
            }

            string originalButtonText = button1.Text;

            try
            {
                button1.Enabled = false;
                button1.Text = "UPDATING...";

                string passwordHash =
                    PasswordHelper.HashPassword(newPassword);

                using SqlConnection connection =
                    DatabaseConnection.GetConnection();

                await connection.OpenAsync();

                string query = @"
                    UPDATE dbo.Users
                    SET PasswordHash = @PasswordHash
                    WHERE Email = @Email
                      AND IsActive = 1;";

                using SqlCommand command =
                    new SqlCommand(query, connection);

                command.Parameters
                    .Add(
                        "@PasswordHash",
                        SqlDbType.NVarChar,
                        255)
                    .Value = passwordHash;

                command.Parameters
                    .Add(
                        "@Email",
                        SqlDbType.NVarChar,
                        255)
                    .Value = receiverEmail;

                int affectedRows =
                    await command.ExecuteNonQueryAsync();

                if (affectedRows == 0)
                {
                    MessageBox.Show(
                        "The account could not be found.",
                        "Reset Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                MessageBox.Show(
                    "Your password has been reset successfully. You can now sign in with the new password.",
                    "Password Reset Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database error:\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Password could not be reset.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                if (!IsDisposed)
                {
                    button1.Enabled = true;
                    button1.Text = originalButtonText;
                }
            }
        }

        private void button2_Click(
            object sender,
            EventArgs e)
        {
            textBox1.UseSystemPasswordChar =
                !textBox1.UseSystemPasswordChar;
        }

        private void button3_Click(
            object sender,
            EventArgs e)
        {
            textBox2.UseSystemPasswordChar =
                !textBox2.UseSystemPasswordChar;
        }

        private void linkLabel1_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ResetPasswordForm_Load(object sender, EventArgs e)
        {

        }
    }
}