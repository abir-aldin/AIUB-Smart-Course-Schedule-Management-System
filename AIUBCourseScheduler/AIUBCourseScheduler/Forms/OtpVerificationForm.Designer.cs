// FILE: OtpVerificationForm.Designer.cs

using System.Drawing;
using System.Windows.Forms;

namespace AIUBCourseScheduler.Forms
{
    partial class OtpVerificationForm
    {
        private System.ComponentModel.IContainer? components = null;

        private Panel headerPanel = null!;
        private Label iconLabel = null!;

        private Panel contentPanel = null!;
        private Label titleLabel = null!;
        private Label instructionLabel = null!;
        private Label emailLabel = null!;
        private Label otpTitleLabel = null!;

        private TextBox textBox1 = null!;
        private Label timerLabel = null!;
        private Button button1 = null!;

        private Label resendTextLabel = null!;
        private LinkLabel linkLabel1 = null!;
        private LinkLabel linkLabel2 = null!;

        private System.Windows.Forms.Timer timer1 = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components =
                new System.ComponentModel.Container();

            headerPanel = new Panel();
            iconLabel = new Label();

            contentPanel = new Panel();
            titleLabel = new Label();
            instructionLabel = new Label();
            emailLabel = new Label();
            otpTitleLabel = new Label();

            textBox1 = new TextBox();
            timerLabel = new Label();
            button1 = new Button();

            resendTextLabel = new Label();
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();

            timer1 =
                new System.Windows.Forms.Timer(components);

            headerPanel.SuspendLayout();
            contentPanel.SuspendLayout();
            SuspendLayout();

            // ---------------------------------
            // headerPanel
            // ---------------------------------
            headerPanel.BackColor =
                Color.FromArgb(13, 110, 202);

            headerPanel.Controls.Add(iconLabel);
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(600, 130);
            headerPanel.TabIndex = 0;

            // ---------------------------------
            // iconLabel
            // ---------------------------------
            iconLabel.Font = new Font(
                "Segoe UI Symbol",
                54F,
                FontStyle.Regular
            );

            iconLabel.ForeColor = Color.White;
            iconLabel.Location = new Point(245, 15);
            iconLabel.Name = "iconLabel";
            iconLabel.Size = new Size(110, 100);
            iconLabel.TabIndex = 0;
            iconLabel.Text = "✉";

            iconLabel.TextAlign =
                ContentAlignment.MiddleCenter;

            // ---------------------------------
            // contentPanel
            // ---------------------------------
            contentPanel.BackColor = Color.White;
            contentPanel.BorderStyle =
                BorderStyle.FixedSingle;

            contentPanel.Controls.Add(titleLabel);
            contentPanel.Controls.Add(instructionLabel);
            contentPanel.Controls.Add(emailLabel);
            contentPanel.Controls.Add(otpTitleLabel);
            contentPanel.Controls.Add(textBox1);
            contentPanel.Controls.Add(timerLabel);
            contentPanel.Controls.Add(button1);
            contentPanel.Controls.Add(resendTextLabel);
            contentPanel.Controls.Add(linkLabel1);

            contentPanel.Location = new Point(40, 150);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(520, 340);
            contentPanel.TabIndex = 1;

            // ---------------------------------
            // titleLabel
            // ---------------------------------
            titleLabel.Font = new Font(
                "Segoe UI",
                22F,
                FontStyle.Bold
            );

            titleLabel.ForeColor =
                Color.FromArgb(10, 35, 85);

            titleLabel.Location = new Point(20, 20);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(480, 45);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Verify Your Email";

            titleLabel.TextAlign =
                ContentAlignment.MiddleCenter;

            // ---------------------------------
            // instructionLabel
            // ---------------------------------
            instructionLabel.Font = new Font(
                "Segoe UI",
                10.5F,
                FontStyle.Regular
            );

            instructionLabel.ForeColor =
                Color.FromArgb(65, 65, 65);

            instructionLabel.Location =
                new Point(20, 68);

            instructionLabel.Name =
                "instructionLabel";

            instructionLabel.Size =
                new Size(480, 25);

            instructionLabel.TabIndex = 1;

            instructionLabel.Text =
                "We sent a 6-digit verification code to";

            instructionLabel.TextAlign =
                ContentAlignment.MiddleCenter;

            // ---------------------------------
            // emailLabel
            // ---------------------------------
            emailLabel.Font = new Font(
                "Segoe UI",
                11F,
                FontStyle.Bold
            );

            emailLabel.ForeColor =
                Color.FromArgb(10, 35, 85);

            emailLabel.Location = new Point(20, 94);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(480, 25);
            emailLabel.TabIndex = 2;
            emailLabel.Text = "ab***@gmail.com";

            emailLabel.TextAlign =
                ContentAlignment.MiddleCenter;

            // ---------------------------------
            // otpTitleLabel
            // ---------------------------------
            otpTitleLabel.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold
            );

            otpTitleLabel.ForeColor =
                Color.FromArgb(30, 30, 30);

            otpTitleLabel.Location =
                new Point(50, 130);

            otpTitleLabel.Name = "otpTitleLabel";
            otpTitleLabel.Size = new Size(420, 25);
            otpTitleLabel.TabIndex = 3;

            otpTitleLabel.Text =
                "Enter Verification Code";

            // ---------------------------------
            // textBox1
            // ---------------------------------
            textBox1.AutoSize = false;

            textBox1.BorderStyle =
                BorderStyle.FixedSingle;

            textBox1.Font = new Font(
                "Segoe UI",
                20F,
                FontStyle.Bold
            );

            textBox1.Location = new Point(50, 158);
            textBox1.MaxLength = 6;
            textBox1.Name = "textBox1";

            textBox1.PlaceholderText =
                "Enter 6-digit code";

            textBox1.Size = new Size(420, 50);
            textBox1.TabIndex = 0;

            textBox1.TextAlign =
                HorizontalAlignment.Center;

            textBox1.KeyPress +=
                textBox1_KeyPress;

            // ---------------------------------
            // timerLabel
            // ---------------------------------
            timerLabel.ForeColor = Color.DimGray;
            timerLabel.Location = new Point(50, 212);
            timerLabel.Name = "timerLabel";
            timerLabel.Size = new Size(420, 25);
            timerLabel.TabIndex = 4;

            timerLabel.Text =
                "Code expires in 05:00";

            timerLabel.TextAlign =
                ContentAlignment.MiddleCenter;

            // ---------------------------------
            // button1
            // ---------------------------------
            button1.BackColor =
                Color.FromArgb(13, 110, 202);

            button1.Cursor = Cursors.Hand;

            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;

            button1.Font = new Font(
                "Segoe UI",
                11F,
                FontStyle.Bold
            );

            button1.ForeColor = Color.White;
            button1.Location = new Point(50, 242);
            button1.Name = "button1";
            button1.Size = new Size(420, 48);
            button1.TabIndex = 1;
            button1.Text = "VERIFY OTP";

            button1.UseVisualStyleBackColor =
                false;

            button1.Click += button1_Click;

            // ---------------------------------
            // resendTextLabel
            // ---------------------------------
            resendTextLabel.ForeColor =
                Color.FromArgb(50, 50, 50);

            resendTextLabel.Location =
                new Point(90, 300);

            resendTextLabel.Name =
                "resendTextLabel";

            resendTextLabel.Size =
                new Size(200, 25);

            resendTextLabel.TabIndex = 5;

            resendTextLabel.Text =
                "Didn't receive the code?";

            resendTextLabel.TextAlign =
                ContentAlignment.MiddleRight;

            // ---------------------------------
            // linkLabel1
            // ---------------------------------
            linkLabel1.ActiveLinkColor =
                Color.FromArgb(8, 75, 145);

            linkLabel1.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Underline
            );

            linkLabel1.LinkColor =
                Color.FromArgb(13, 110, 202);

            linkLabel1.Location =
                new Point(295, 300);

            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(120, 25);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Resend OTP";

            linkLabel1.TextAlign =
                ContentAlignment.MiddleLeft;

            linkLabel1.LinkClicked +=
                linkLabel1_LinkClicked;

            // ---------------------------------
            // linkLabel2
            // ---------------------------------
            linkLabel2.ActiveLinkColor =
                Color.FromArgb(8, 75, 145);

            linkLabel2.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Underline
            );

            linkLabel2.LinkColor =
                Color.FromArgb(13, 110, 202);

            linkLabel2.Location =
                new Point(190, 510);

            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(220, 30);
            linkLabel2.TabIndex = 2;
            linkLabel2.TabStop = true;

            linkLabel2.Text =
                "Back to Registration";

            linkLabel2.TextAlign =
                ContentAlignment.MiddleCenter;

            linkLabel2.LinkClicked +=
                linkLabel2_LinkClicked;

            // ---------------------------------
            // timer1
            // ---------------------------------
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;

            // ---------------------------------
            // OtpVerificationForm
            // ---------------------------------
            AcceptButton = button1;

            AutoScaleDimensions =
                new SizeF(96F, 96F);

            AutoScaleMode = AutoScaleMode.Dpi;

            BackColor =
                Color.FromArgb(244, 247, 250);

            ClientSize = new Size(600, 570);

            Controls.Add(linkLabel2);
            Controls.Add(contentPanel);
            Controls.Add(headerPanel);

            Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Regular
            );

            FormBorderStyle =
                FormBorderStyle.FixedDialog;

            MaximizeBox = false;
            MinimizeBox = false;

            Name = "OtpVerificationForm";
            ShowInTaskbar = false;

            StartPosition =
                FormStartPosition.CenterParent;

            Text =
                "AIUB Smart Course Scheduler - Email Verification";

            headerPanel.ResumeLayout(false);

            contentPanel.ResumeLayout(false);
            contentPanel.PerformLayout();

            ResumeLayout(false);
        }

        #endregion
    }
}