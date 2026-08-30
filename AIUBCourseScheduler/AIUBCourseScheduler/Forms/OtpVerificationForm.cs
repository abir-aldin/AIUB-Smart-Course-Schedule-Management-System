using AIUBCourseScheduler.Services;
using System;
using System.Windows.Forms;

namespace AIUBCourseScheduler.Forms
{
    public partial class OtpVerificationForm : Form
    {
        private readonly string receiverEmail;
        private readonly OtpPurpose otpPurpose;

        private int remainingSeconds = 300;

        // Visual Studio Designer-এর জন্য
        public OtpVerificationForm()
            : this(
                  "example@gmail.com",
                  OtpPurpose.Registration)
        {
        }

        // Application থেকে form open করার জন্য
        public OtpVerificationForm(
            string email,
            OtpPurpose purpose =
                OtpPurpose.Registration)
        {
            InitializeComponent();

            receiverEmail = email;
            otpPurpose = purpose;

            emailLabel.Text = MaskEmail(receiverEmail);

            UpdateTimerLabel();

            button1.Enabled = true;
            linkLabel1.Enabled = false;

            timer1.Start();
        }

        // Verify OTP button
        private async void button1_Click(
            object sender,
            EventArgs e)
        {
            string enteredOtp =
                textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(enteredOtp))
            {
                MessageBox.Show(
                    "Please enter the OTP.",
                    "OTP Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                textBox1.Focus();
                return;
            }

            if (enteredOtp.Length != 6 ||
                !int.TryParse(enteredOtp, out _))
            {
                MessageBox.Show(
                    "OTP must contain exactly 6 digits.",
                    "Invalid OTP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                textBox1.Focus();
                return;
            }

            try
            {
                button1.Enabled = false;
                button1.Text = "Verifying...";

                OtpVerificationResult result =
                    await OtpService.VerifyOtpAsync(
                        receiverEmail,
                        enteredOtp,
                        otpPurpose
                    );

                switch (result)
                {
                    case OtpVerificationResult.Success:
                        timer1.Stop();

                        MessageBox.Show(
                            "Email verified successfully!",
                            "Verification Successful",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        DialogResult = DialogResult.OK;
                        Close();
                        break;

                    case OtpVerificationResult.Invalid:
                        MessageBox.Show(
                            "The OTP you entered is incorrect.",
                            "Incorrect OTP",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        textBox1.Clear();
                        textBox1.Focus();
                        button1.Enabled = true;
                        break;

                    case OtpVerificationResult.Expired:
                        timer1.Stop();
                        remainingSeconds = 0;

                        timerLabel.Text =
                            "OTP has expired";

                        MessageBox.Show(
                            "This OTP has expired. Please request a new OTP.",
                            "OTP Expired",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        linkLabel1.Enabled = true;
                        break;

                    case OtpVerificationResult
                        .TooManyAttempts:

                        timer1.Stop();

                        timerLabel.Text =
                            "OTP has been locked";

                        MessageBox.Show(
                            "Too many incorrect attempts. Please request a new OTP.",
                            "OTP Locked",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        linkLabel1.Enabled = true;
                        break;

                    case OtpVerificationResult.NotFound:
                        timer1.Stop();

                        timerLabel.Text =
                            "No active OTP found";

                        MessageBox.Show(
                            "No active OTP was found. Please request a new OTP.",
                            "OTP Not Found",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        linkLabel1.Enabled = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "OTP verification failed.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                button1.Enabled =
                    remainingSeconds > 0;
            }
            finally
            {
                button1.Text = "VERIFY OTP";
            }
        }

        // Resend OTP link
        private async void linkLabel1_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                linkLabel1.Enabled = false;
                button1.Enabled = false;

                linkLabel1.Text = "Sending...";

                await OtpService.SendOtpAsync(
                    receiverEmail,
                    otpPurpose
                );

                remainingSeconds = 300;

                textBox1.Clear();
                textBox1.Focus();

                UpdateTimerLabel();

                button1.Enabled = true;
                timer1.Start();

                MessageBox.Show(
                    "A new OTP has been sent to your email.",
                    "OTP Sent",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                linkLabel1.Enabled = true;

                MessageBox.Show(
                    "OTP could not be sent.\n\n" +
                    ex.Message,
                    "Email Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                linkLabel1.Text = "Resend OTP";
            }
        }

        // Back link
        private void linkLabel2_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            timer1.Stop();

            DialogResult = DialogResult.Cancel;
            Close();
        }

        // Countdown timer
        private void timer1_Tick(
            object sender,
            EventArgs e)
        {
            if (remainingSeconds > 0)
            {
                remainingSeconds--;
                UpdateTimerLabel();
            }

            if (remainingSeconds <= 0)
            {
                timer1.Stop();

                timerLabel.Text =
                    "OTP has expired";

                button1.Enabled = false;
                linkLabel1.Enabled = true;
            }
        }

        // OTP textbox-এ শুধু number লেখা যাবে
        private void textBox1_KeyPress(
            object sender,
            KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void UpdateTimerLabel()
        {
            int minutes = remainingSeconds / 60;
            int seconds = remainingSeconds % 60;

            timerLabel.Text =
                $"OTP expires in {minutes:00}:{seconds:00}";
        }

        private static string MaskEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) ||
                !email.Contains("@"))
            {
                return email;
            }

            string[] emailParts =
                email.Split('@');

            string username = emailParts[0];
            string domain = emailParts[1];

            if (username.Length <= 2)
            {
                return username[0] +
                       "***@" +
                       domain;
            }

            string visiblePart =
                username.Substring(0, 2);

            return visiblePart +
                   new string(
                       '*',
                       Math.Max(3, username.Length - 2)
                   ) +
                   "@" +
                   domain;
        }
    }
}