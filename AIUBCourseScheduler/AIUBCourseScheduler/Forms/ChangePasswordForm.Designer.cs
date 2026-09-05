namespace AIUBCourseScheduler.Forms
{
    partial class ChangePasswordForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.TextBox textBoxCurrent;
        private System.Windows.Forms.TextBox textBoxNew;
        private System.Windows.Forms.TextBox textBoxConfirm;

        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Button buttonCancel;

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBoxCurrent = new TextBox();
            textBoxNew = new TextBox();
            textBoxConfirm = new TextBox();
            buttonChange = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            label1.Location = new Point(135, 32);
            label1.Name = "label1";
            label1.Size = new Size(258, 40);
            label1.TabIndex = 0;
            label1.Text = "Change Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(103, 107);
            label2.Name = "label2";
            label2.Size = new Size(163, 28);
            label2.TabIndex = 1;
            label2.Text = "Current Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(103, 177);
            label3.Name = "label3";
            label3.Size = new Size(137, 28);
            label3.TabIndex = 2;
            label3.Text = "New Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(103, 247);
            label4.Name = "label4";
            label4.Size = new Size(168, 28);
            label4.TabIndex = 3;
            label4.Text = "Confirm Password";
            // 
            // textBoxCurrent
            // 
            textBoxCurrent.Font = new Font("Segoe UI", 12F);
            textBoxCurrent.Location = new Point(289, 107);
            textBoxCurrent.Name = "textBoxCurrent";
            textBoxCurrent.PasswordChar = '*';
            textBoxCurrent.Size = new Size(175, 34);
            textBoxCurrent.TabIndex = 4;
            // 
            // textBoxNew
            // 
            textBoxNew.Font = new Font("Segoe UI", 12F);
            textBoxNew.Location = new Point(289, 177);
            textBoxNew.Name = "textBoxNew";
            textBoxNew.PasswordChar = '*';
            textBoxNew.Size = new Size(175, 34);
            textBoxNew.TabIndex = 5;
            // 
            // textBoxConfirm
            // 
            textBoxConfirm.Font = new Font("Segoe UI", 12F);
            textBoxConfirm.Location = new Point(289, 247);
            textBoxConfirm.Name = "textBoxConfirm";
            textBoxConfirm.PasswordChar = '*';
            textBoxConfirm.Size = new Size(175, 34);
            textBoxConfirm.TabIndex = 6;
            // 
            // buttonChange
            // 
            buttonChange.BackColor = SystemColors.InactiveCaption;
            buttonChange.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonChange.Location = new Point(103, 314);
            buttonChange.Name = "buttonChange";
            buttonChange.Size = new Size(149, 45);
            buttonChange.TabIndex = 7;
            buttonChange.Text = "Change Password";
            buttonChange.UseVisualStyleBackColor = false;
            buttonChange.Click += buttonChange_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.Red;
            buttonCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonCancel.ForeColor = SystemColors.ButtonHighlight;
            buttonCancel.Location = new Point(367, 320);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(109, 39);
            buttonCancel.TabIndex = 8;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // ChangePasswordForm
            // 
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(600, 420);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(textBoxCurrent);
            Controls.Add(textBoxNew);
            Controls.Add(textBoxConfirm);
            Controls.Add(buttonChange);
            Controls.Add(buttonCancel);
            Name = "ChangePasswordForm";
            Text = "Change Password";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
