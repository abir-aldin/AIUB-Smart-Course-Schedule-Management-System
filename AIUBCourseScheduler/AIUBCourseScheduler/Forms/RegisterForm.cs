using AIUBCourseScheduler.DataAccess;
using AIUBCourseScheduler.Services;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIUBCourseScheduler.Forms
{
    public partial class RegisterForm : Form
    {
        private int count = 0;
        private int count2 = 0;

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void label1_Click(
            object sender,
            EventArgs e)
        {
        }

        // Password show/hide
        private void button2_Click(
            object sender,
            EventArgs e)
        {
            count++;

            textBox4.UseSystemPasswordChar =
                count % 2 == 0;
        }

        // Confirm password show/hide
        private void button3_Click(
            object sender,
            EventArgs e)
        {
            count2++;

            textBox5.UseSystemPasswordChar =
                count2 % 2 == 0;
        }

        // Sign In link
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        // Create Account button
        private async void button1_Click(
            object sender,
            EventArgs e)
        {
            string fullName =
                textBox1.Text.Trim();

            string studentId =
                textBox2.Text.Trim();

            string email =
                textBox3.Text.Trim().ToLowerInvariant();

            string password =
                textBox4.Text;

            string confirmPassword =
                textBox5.Text;

            // Empty field validation
            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(studentId) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show(
                    "Please fill in all fields.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // Email format validation
            if (!IsValidEmail(email))
            {
                MessageBox.Show(
                    "Please enter a valid email address.",
                    "Invalid Email",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                textBox3.Focus();
                return;
            }

            // Password length validation
            if (password.Length < 8)
            {
                MessageBox.Show(
                    "Password must contain at least 8 characters.",
                    "Weak Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                textBox4.Focus();
                return;
            }

            // Password matching validation
            if (password != confirmPassword)
            {
                MessageBox.Show(
                    "Password and confirm password do not match.",
                    "Password Mismatch",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                textBox5.Focus();
                return;
            }

            string originalButtonText =
                button1.Text;

            try
            {
                button1.Enabled = false;
                button1.Text = "Checking...";

                // Email অথবা Student ID আগে থেকেই আছে কি না
                bool alreadyRegistered =
                    await UserAlreadyExistsAsync(
                        email,
                        studentId
                    );

                if (alreadyRegistered)
                {
                    MessageBox.Show(
                        "This email or Student ID is already registered.",
                        "Account Already Exists",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                button1.Text = "Sending OTP...";

                // OTP তৈরি, Database-এ save এবং Email-এ send
                await OtpService
                    .SendRegistrationOtpAsync(email);

                // OTP Verification form open
                using OtpVerificationForm otpForm =
                    new OtpVerificationForm(
                        email,
                        OtpPurpose.Registration
                    );

                DialogResult otpResult =
                    otpForm.ShowDialog(this);

                // OTP verify না হলে account তৈরি হবে না
                if (otpResult != DialogResult.OK)
                {
                    return;
                }

                button1.Text = "Creating Account...";

                // OTP চলাকালীন অন্যভাবে account তৈরি হয়েছে কি না
                // আবার check করা হচ্ছে
                alreadyRegistered =
                    await UserAlreadyExistsAsync(
                        email,
                        studentId
                    );

                if (alreadyRegistered)
                {
                    MessageBox.Show(
                        "This email or Student ID is already registered.",
                        "Account Already Exists",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // OTP verify হওয়ার পর account insert
                await CreateUserAsync(
                    fullName,
                    studentId,
                    email,
                    password
                );

                MessageBox.Show(
                    "Your account has been created successfully!",
                    "Registration Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database error:\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Registration could not be completed.\n\n" +
                    ex.Message,
                    "Registration Error",
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
            UserAlreadyExistsAsync(
                string email,
                string studentId)
        {
            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            await connection.OpenAsync();

            string query = @"
                SELECT COUNT(1)
                FROM dbo.Users
                WHERE Email = @Email
                   OR StudentId = @StudentId;";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters
                .Add(
                    "@Email",
                    SqlDbType.NVarChar,
                    255)
                .Value = email;

            command.Parameters
                .Add(
                    "@StudentId",
                    SqlDbType.NVarChar,
                    50)
                .Value = studentId;

            int userCount =
                Convert.ToInt32(
                    await command.ExecuteScalarAsync()
                );

            return userCount > 0;
        }

        private static async Task CreateUserAsync(
            string fullName,
            string studentId,
            string email,
            string password)
        {
            string passwordHash =
                PasswordHelper.HashPassword(password);

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            await connection.OpenAsync();

            string query = @"
                INSERT INTO dbo.Users
                (
                    FullName,
                    StudentId,
                    Email,
                    PasswordHash,
                    UserRole,
                    IsActive,
                    CreatedAt
                )
                VALUES
                (
                    @FullName,
                    @StudentId,
                    @Email,
                    @PasswordHash,
                    'Student',
                    1,
                    SYSDATETIME()
                );";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters
                .Add(
                    "@FullName",
                    SqlDbType.NVarChar,
                    150)
                .Value = fullName;

            command.Parameters
                .Add(
                    "@StudentId",
                    SqlDbType.NVarChar,
                    50)
                .Value = studentId;

            command.Parameters
                .Add(
                    "@Email",
                    SqlDbType.NVarChar,
                    255)
                .Value = email;

            command.Parameters
                .Add(
                    "@PasswordHash",
                    SqlDbType.NVarChar,
                    255)
                .Value = passwordHash;

            await command.ExecuteNonQueryAsync();
        }

        private static bool IsValidEmail(
            string email)
        {
            try
            {
                MailAddress emailAddress =
                    new MailAddress(email);

                return emailAddress.Address.Equals(
                    email,
                    StringComparison.OrdinalIgnoreCase
                );
            }
            catch
            {
                return false;
            }
        }
    }
}