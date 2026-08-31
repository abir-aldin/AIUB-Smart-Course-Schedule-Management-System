using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace AIUBCourseScheduler.Services
{
    public static class EmailService
    {
        public static async Task SendOtpAsync(
            string receiverEmail,
            string otp)
        {
            string? senderEmail =
                Environment.GetEnvironmentVariable(
                    "AIUB_EMAIL_ADDRESS");

            string? appPassword =
                Environment.GetEnvironmentVariable(
                    "AIUB_EMAIL_APP_PASSWORD");

            if (string.IsNullOrWhiteSpace(senderEmail) ||
                string.IsNullOrWhiteSpace(appPassword))
            {
                throw new InvalidOperationException(
                    "Sender email configuration was not found."
                );
            }

            MimeMessage message = new MimeMessage();

            message.From.Add(
                new MailboxAddress(
                    "AIUB Smart Course Scheduler",
                    senderEmail
                )
            );

            message.To.Add(
                MailboxAddress.Parse(receiverEmail)
            );

            message.Subject =
                "Your Email Verification Code";

            message.Body = new TextPart("html")
            {
                Text = $"""
                    <h2>AIUB Smart Course Scheduler</h2>

                    <p>Your verification code is:</p>

                    <h1 style="letter-spacing: 5px;">
                        {otp}
                    </h1>

                    <p>This OTP will expire in 5 minutes.</p>

                    <p>
                        If you did not request this code,
                        please ignore this email.
                    </p>
                    """
            };

            using SmtpClient client = new SmtpClient();

            await client.ConnectAsync(
                "smtp.gmail.com",
                587,
                SecureSocketOptions.StartTls
            );

            await client.AuthenticateAsync(
                senderEmail,
                appPassword
            );

            await client.SendAsync(message);

            await client.DisconnectAsync(true);
        }
    }
}