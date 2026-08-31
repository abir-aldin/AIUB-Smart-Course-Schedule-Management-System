using AIUBCourseScheduler.DataAccess;
using AIUBCourseScheduler.Services;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AIUBCourseScheduler.Forms
{
    public partial class LoginForm : Form
    {
        private const string IdentifierPlaceholder = "Enter your email ID";

        private const string PasswordPlaceholder = "Enter your password";

        public LoginForm()
        {
            InitializeComponent();
            ConfigureLoginControls();
            LoadRememberedIdentifier();
        }

        private void ConfigureLoginControls()
        {
            AcceptButton = button1;

            button2.Click -= button2_Click;
            button2.Click += button2_Click;

            textBox1.Enter -= textBox1_Enter;
            textBox1.Enter += textBox1_Enter;

            textBox1.Leave -= textBox1_Leave;
            textBox1.Leave += textBox1_Leave;

            textBox2.Enter -= textBox2_Enter;
            textBox2.Enter += textBox2_Enter;

            textBox2.Leave -= textBox2_Leave;
            textBox2.Leave += textBox2_Leave;

            linkLabel1.LinkClicked -=
                linkLabel1_LinkClicked;

            linkLabel1.LinkClicked +=
                linkLabel1_LinkClicked;

            linkLabel1.LinkColor =
                Color.RoyalBlue;

            if (textBox1.Text == IdentifierPlaceholder)
            {
                textBox1.ForeColor = Color.Gray;
            }

            if (textBox2.Text == PasswordPlaceholder)
            {
                textBox2.ForeColor = Color.Gray;
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void label1_Click(
            object sender,
            EventArgs e)
        {
        }

        private void label7_Click(
            object sender,
            EventArgs e)
        {
        }

        // SIGN IN button
        private async void button1_Click(
            object sender,
            EventArgs e)
        {
            string identifier =
                textBox1.Text.Trim();

            string password =
                textBox2.Text;

            if (identifier == IdentifierPlaceholder)
            {
                identifier = string.Empty;
            }

            if (password == PasswordPlaceholder)
            {
                password = string.Empty;
            }

            if (string.IsNullOrWhiteSpace(identifier) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Please enter your Email or Student ID and Password.",
                    "Login Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string originalButtonText =
                button1.Text;

            try
            {
                button1.Enabled = false;
                button1.Text = "SIGNING IN...";

                using SqlConnection connection =
                    DatabaseConnection.GetConnection();

                await connection.OpenAsync();

                string query = @"
                    SELECT TOP (1)
                        UserId,
                        FullName,
                        StudentId,
                        Email,
                        PasswordHash,
                        UserRole,
                        IsActive
                    FROM dbo.Users
                    WHERE Email = @Identifier
                       OR StudentId = @Identifier;";

                using SqlCommand command =
                    new SqlCommand(query, connection);

                command.Parameters
                    .Add(
                        "@Identifier",
                        SqlDbType.NVarChar,
                        255)
                    .Value = identifier;

                using SqlDataReader reader =
                    await command.ExecuteReaderAsync();

                if (!await reader.ReadAsync())
                {
                    MessageBox.Show(
                        "Invalid Email, Student ID, or Password.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                int userId = reader.GetInt32(0);

                string fullName =
                    reader.GetString(1);

                string studentId = reader.IsDBNull(2)? string.Empty : reader.GetString(2);

                string email = reader.GetString(3);

                string passwordHash = reader.GetString(4);

                string userRole = reader.GetString(5);

                bool isActive = reader.GetBoolean(6);

                await reader.CloseAsync();

                bool passwordIsCorrect =
                    PasswordHelper.VerifyPassword(
                        password,
                        passwordHash
                    );

                if (!passwordIsCorrect)
                {
                    MessageBox.Show(
                        "Invalid Email, Student ID, or Password.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    textBox2.Clear();
                    textBox2.Focus();

                    return;
                }

                if (!isActive)
                {
                    MessageBox.Show(
                        "Your account is currently inactive. Please contact the administrator.",
                        "Account Inactive",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                if (checkBox1.Checked)
                {
                    RememberMeService.SaveIdentifier(
                        identifier
                    );
                }
                else
                {
                    RememberMeService.Clear();
                }

                UserSession.Start(
                    userId,
                    fullName,
                    studentId,
                    email,
                    userRole
                );

                Form destinationForm;

                if (userRole.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    destinationForm = new AdminMainForm();
                }
                else if (userRole.Equals("Student", StringComparison.OrdinalIgnoreCase))
                {
                    destinationForm = new StudentMainForm();
                }
                else
                {
                    UserSession.Clear();

                    MessageBox.Show(
                        "This account has an invalid user role.",
                        "Login Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                destinationForm.FormClosed += DestinationForm_FormClosed;
                Hide();
                destinationForm.Show();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error:\n\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login could not be completed.\n\n" + ex.Message, "Login Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                if(!IsDisposed && Visible)
                {
                    button1.Enabled = true;
                    button1.Text = originalButtonText;
                }
            }
        }

        // Password show/hide button
        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == PasswordPlaceholder || string.IsNullOrEmpty(textBox2.Text))
            {
                return;
            }

            textBox2.UseSystemPasswordChar = !textBox2.UseSystemPasswordChar;
        }

        // Create Account link
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();

            using RegisterForm registerForm = new RegisterForm();

            registerForm.ShowDialog();

            if(!IsDisposed)
            {
                Show();
            }
        }

        // Forgot Password—পরের ধাপে implement হবে
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using ForgotPasswordForm forgotForm = new ForgotPasswordForm();
            forgotForm.ShowDialog(this);
        }

        private void DestinationForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            UserSession.Clear();

            if (sender is AdminMainForm adminForm &&
                adminForm.IsLoggingOut)
            {
                button1.Enabled = true;

                textBox2.UseSystemPasswordChar = false;
                textBox2.Text = PasswordPlaceholder;
                textBox2.ForeColor = Color.Gray;

                if (!checkBox1.Checked)
                {
                    textBox1.Text = IdentifierPlaceholder;
                    textBox1.ForeColor = Color.Gray;
                }

                Show();
                Activate();
                return;
            }

            // X button দিয়ে Admin form বন্ধ করলে app বন্ধ হবে
            Close();
        }

        private void textBox1_Enter(
            object sender,
            EventArgs e)
        {
            if (textBox1.Text == IdentifierPlaceholder)
            {
                textBox1.Clear();
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text =
                    IdentifierPlaceholder;

                textBox1.ForeColor =
                    Color.Gray;
            }
        }

        private void textBox2_Enter(
            object sender,
            EventArgs e)
        {
            if (textBox2.Text == PasswordPlaceholder)
            {
                textBox2.Clear();
                textBox2.ForeColor = Color.Black;
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_Leave(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.UseSystemPasswordChar = false;

                textBox2.Text =
                    PasswordPlaceholder;

                textBox2.ForeColor =
                    Color.Gray;
            }
        }

        private void LoadRememberedIdentifier()
        {
            string rememberedIdentifier =
                RememberMeService.LoadIdentifier();

            if (!string.IsNullOrWhiteSpace(
                rememberedIdentifier))
            {
                textBox1.Text =
                    rememberedIdentifier;

                textBox1.ForeColor =
                    Color.Black;

                checkBox1.Checked = true;
            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}