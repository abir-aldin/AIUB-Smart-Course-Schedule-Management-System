using System.Drawing;
using System.Windows.Forms;

namespace AIUBCourseScheduler.Forms
{
    partial class ForgotPasswordForm
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer? components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /// 




        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            headerPanel = new Panel();
            subtitleLabel = new Label();
            titleLabel = new Label();
            emailLabel = new Label();
            textBox1 = new TextBox();
            instructionLabel = new Label();
            button1 = new Button();
            linkLabel1 = new LinkLabel();
            headerPanel.SuspendLayout();
            SuspendLayout();

            // headerPanel
            headerPanel.BackColor = Color.RoyalBlue;
            headerPanel.Controls.Add(subtitleLabel);
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(560, 115);
            headerPanel.TabIndex = 0;

            // titleLabel
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font(
                "Segoe UI",
                21F,
                FontStyle.Bold
            );
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(137, 20);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(286, 47);
            titleLabel.Text = "Forgot Password";

            // subtitleLabel
            subtitleLabel.AutoSize = true;
            subtitleLabel.Font = new Font(
                "Segoe UI",
                10F
            );
            subtitleLabel.ForeColor = Color.WhiteSmoke;
            subtitleLabel.Location = new Point(136, 72);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(289, 23);
            subtitleLabel.Text =
                "We will send a verification code";

            // emailLabel
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold
            );
            emailLabel.Location = new Point(65, 157);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(145, 23);
            emailLabel.Text = "Registered Email";

            // textBox1
            textBox1.Font = new Font(
                "Segoe UI",
                12F
            );
            textBox1.Location = new Point(65, 188);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText =
                "Enter your registered email";
            textBox1.Size = new Size(430, 34);
            textBox1.TabIndex = 1;

            // instructionLabel
            instructionLabel.Font = new Font(
                "Segoe UI",
                9F
            );
            instructionLabel.ForeColor = Color.Gray;
            instructionLabel.Location = new Point(65, 235);
            instructionLabel.Name = "instructionLabel";
            instructionLabel.Size = new Size(430, 48);
            instructionLabel.Text =
                "A 6-digit OTP will be sent to this email. The OTP will remain valid for 5 minutes.";

            // button1
            button1.BackColor = Color.RoyalBlue;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font(
                "Segoe UI",
                11F,
                FontStyle.Bold
            );
            button1.ForeColor = Color.White;
            button1.Location = new Point(65, 298);
            button1.Name = "button1";
            button1.Size = new Size(430, 55);
            button1.TabIndex = 2;
            button1.Text = "SEND OTP";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;

            // linkLabel1
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font(
                "Segoe UI",
                10F
            );
            linkLabel1.LinkColor = Color.RoyalBlue;
            linkLabel1.Location = new Point(215, 377);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(130, 23);
            linkLabel1.TabIndex = 3;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Back to Sign In";
            linkLabel1.LinkClicked +=
                linkLabel1_LinkClicked;

            // ForgotPasswordForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(560, 430);
            Controls.Add(linkLabel1);
            Controls.Add(button1);
            Controls.Add(instructionLabel);
            Controls.Add(textBox1);
            Controls.Add(emailLabel);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ForgotPasswordForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Forgot Password";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel headerPanel;
        private Label titleLabel;
        private Label subtitleLabel;
        private Label emailLabel;
        private TextBox textBox1;
        private Label instructionLabel;
        private Button button1;
        private LinkLabel linkLabel1;

        #endregion
    }
}