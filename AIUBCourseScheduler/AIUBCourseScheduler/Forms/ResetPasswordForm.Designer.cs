using System.Drawing;
using System.Windows.Forms;

namespace AIUBCourseScheduler.Forms
{
    partial class ResetPasswordForm
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer? components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetPasswordForm));
            headerPanel = new Panel();
            subtitleLabel = new Label();
            titleLabel = new Label();
            accountLabel = new Label();
            emailValueLabel = new Label();
            newPasswordLabel = new Label();
            textBox1 = new TextBox();
            button2 = new Button();
            confirmPasswordLabel = new Label();
            textBox2 = new TextBox();
            button3 = new Button();
            ruleLabel = new Label();
            button1 = new Button();
            linkLabel1 = new LinkLabel();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.RoyalBlue;
            headerPanel.Controls.Add(subtitleLabel);
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(560, 115);
            headerPanel.TabIndex = 0;
            // 
            // subtitleLabel
            // 
            subtitleLabel.AutoSize = true;
            subtitleLabel.Font = new Font("Segoe UI", 10F);
            subtitleLabel.ForeColor = Color.WhiteSmoke;
            subtitleLabel.Location = new Point(142, 72);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(240, 23);
            subtitleLabel.TabIndex = 0;
            subtitleLabel.Text = "Create a new secure password";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(140, 19);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(274, 47);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Reset Password";
            // 
            // accountLabel
            // 
            accountLabel.AutoSize = true;
            accountLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            accountLabel.Location = new Point(65, 142);
            accountLabel.Name = "accountLabel";
            accountLabel.Size = new Size(71, 20);
            accountLabel.TabIndex = 11;
            accountLabel.Text = "Account:";
            // 
            // emailValueLabel
            // 
            emailValueLabel.AutoEllipsis = true;
            emailValueLabel.ForeColor = Color.RoyalBlue;
            emailValueLabel.Location = new Point(140, 142);
            emailValueLabel.Name = "emailValueLabel";
            emailValueLabel.Size = new Size(355, 23);
            emailValueLabel.TabIndex = 10;
            emailValueLabel.Text = "example@gmail.com";
            // 
            // newPasswordLabel
            // 
            newPasswordLabel.AutoSize = true;
            newPasswordLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            newPasswordLabel.Location = new Point(65, 188);
            newPasswordLabel.Name = "newPasswordLabel";
            newPasswordLabel.Size = new Size(126, 23);
            newPasswordLabel.TabIndex = 9;
            newPasswordLabel.Text = "New Password";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.Location = new Point(65, 218);
            textBox1.MaxLength = 100;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(375, 34);
            textBox1.TabIndex = 1;
            textBox1.UseSystemPasswordChar = true;
            // 
            // button2
            // 
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Segoe UI", 9F);
            button2.Location = new Point(436, 218);
            button2.Name = "button2";
            button2.Size = new Size(36, 34);
            button2.TabIndex = 2;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // confirmPasswordLabel
            // 
            confirmPasswordLabel.AutoSize = true;
            confirmPasswordLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            confirmPasswordLabel.Location = new Point(65, 278);
            confirmPasswordLabel.Name = "confirmPasswordLabel";
            confirmPasswordLabel.Size = new Size(156, 23);
            confirmPasswordLabel.TabIndex = 8;
            confirmPasswordLabel.Text = "Confirm Password";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 12F);
            textBox2.Location = new Point(65, 308);
            textBox2.MaxLength = 100;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(375, 34);
            textBox2.TabIndex = 3;
            textBox2.UseSystemPasswordChar = true;
            // 
            // button3
            // 
            button3.BackgroundImage = (Image)resources.GetObject("button3.BackgroundImage");
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3.Cursor = Cursors.Hand;
            button3.Font = new Font("Segoe UI", 9F);
            button3.Location = new Point(436, 308);
            button3.Name = "button3";
            button3.Size = new Size(36, 34);
            button3.TabIndex = 4;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ruleLabel
            // 
            ruleLabel.AutoSize = true;
            ruleLabel.ForeColor = Color.Gray;
            ruleLabel.Location = new Point(65, 356);
            ruleLabel.Name = "ruleLabel";
            ruleLabel.Size = new Size(297, 20);
            ruleLabel.TabIndex = 7;
            ruleLabel.Text = "Password must contain at least 8 characters.";
            // 
            // button1
            // 
            button1.BackColor = Color.RoyalBlue;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(65, 398);
            button1.Name = "button1";
            button1.Size = new Size(430, 55);
            button1.TabIndex = 5;
            button1.Text = "RESET PASSWORD";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 10F);
            linkLabel1.LinkColor = Color.RoyalBlue;
            linkLabel1.Location = new Point(251, 474);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(61, 23);
            linkLabel1.TabIndex = 6;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Cancel";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // ResetPasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(560, 520);
            Controls.Add(linkLabel1);
            Controls.Add(button1);
            Controls.Add(ruleLabel);
            Controls.Add(button3);
            Controls.Add(textBox2);
            Controls.Add(confirmPasswordLabel);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(newPasswordLabel);
            Controls.Add(emailValueLabel);
            Controls.Add(accountLabel);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ResetPasswordForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reset Password";
            Load += ResetPasswordForm_Load;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel headerPanel;
        private Label titleLabel;
        private Label subtitleLabel;
        private Label accountLabel;
        private Label emailValueLabel;
        private Label newPasswordLabel;
        private TextBox textBox1;
        private Button button2;
        private Label confirmPasswordLabel;
        private TextBox textBox2;
        private Button button3;
        private Label ruleLabel;
        private Button button1;
        private LinkLabel linkLabel1;


    }
}