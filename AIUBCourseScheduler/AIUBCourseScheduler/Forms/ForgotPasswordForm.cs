using AIUBCourseScheduler.DataAccess;
using AIUBCourseScheduler.Services;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AIUBCourseScheduler.Forms
{
    public partial class ForgotPasswordForm : Form
    {
        public ForgotPasswordForm()
        {
            InitializeComponent();
            AcceptButton = button1;
        }

        private async void button1_Click(
            object sender,
            EventArgs e)
        {
            string email =
                textBox1.Text.Trim().ToLowerInvariant();

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show(
                    "Please enter your registered email.",
                    "Email Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                textBox1.Focus();
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show(
                    "Please enter a valid email address.",
                    "Invalid Email",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                textBox1.Focus();
                return;
            }

            string originalButtonText = button1.Text;

            try
            {
                button1.Enabled = false;
                button1.Text = "CHECKING...";

                bool accountExists =
                    await ActiveAccountExistsAsync(email);

                if (!accountExists)
                {
                    MessageBox.Show(
                        "No active account was found with this email.",
                        "Account Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                button1.Text = "SENDING OTP...";

                await OtpService
                    .SendForgotPasswordOtpAsync(email);

                using OtpVerificationForm otpForm =
                    new OtpVerificationForm(
                        email,
                        OtpPurpose.ForgotPassword
                    );

                DialogResult otpResult =
                    otpForm.ShowDialog(this);

                if (otpResult != DialogResult.OK)
                {
                    return;
                }

                Hide();

                using ResetPasswordForm resetForm =
                    new ResetPasswordForm(email);

                DialogResult resetResult =
                    resetForm.ShowDialog();

                if (resetResult == DialogResult.OK)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                Show();
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
                    "Password reset OTP could not be sent.\n\n" +
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

        private static async Task<bool>
            ActiveAccountExistsAsync(string email)
        {
            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            await connection.OpenAsync();

            string query = @"
                SELECT COUNT(1)
                FROM dbo.Users
                WHERE Email = @Email
                  AND IsActive = 1;";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters
                .Add("@Email", SqlDbType.NVarChar, 255)
                .Value = email;

            int count = Convert.ToInt32(
                await command.ExecuteScalarAsync()
            );

            return count > 0;
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                MailAddress address =
                    new MailAddress(email);

                return address.Address.Equals(
                    email,
                    StringComparison.OrdinalIgnoreCase
                );
            }
            catch
            {
                return false;
            }
        }

        private void linkLabel1_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}