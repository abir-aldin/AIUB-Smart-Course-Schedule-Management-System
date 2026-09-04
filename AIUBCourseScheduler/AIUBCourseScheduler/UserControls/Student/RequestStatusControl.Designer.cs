namespace AIUBCourseScheduler.UserControls.Student
{
    partial class RequestStatusControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestStatusControl));
            label1 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            label13 = new Label();
            label8 = new Label();
            label4 = new Label();
            panel3 = new Panel();
            pictureBox3 = new PictureBox();
            label14 = new Label();
            label9 = new Label();
            label5 = new Label();
            label10 = new Label();
            label6 = new Label();
            label7 = new Label();
            panel5 = new Panel();
            pictureBox1 = new PictureBox();
            panel4 = new Panel();
            panel1 = new Panel();
            panel6 = new Panel();
            dataGridView1 = new DataGridView();
            colRequestID = new DataGridViewTextBoxColumn();
            colSchedule = new DataGridViewTextBoxColumn();
            ColSubmittedDate = new DataGridViewTextBoxColumn();
            ColStatus = new DataGridViewTextBoxColumn();
            colAdminComment = new DataGridViewTextBoxColumn();
            colAction = new DataGridViewButtonColumn();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(1, 9);
            label1.Name = "label1";
            label1.Size = new Size(210, 38);
            label1.TabIndex = 0;
            label1.Text = "Request Status";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(1, 47);
            label2.Name = "label2";
            label2.Size = new Size(332, 23);
            label2.TabIndex = 1;
            label2.Text = "Track the status of your schedule requests";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HighlightText;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(341, 73);
            panel2.Name = "panel2";
            panel2.Size = new Size(280, 120);
            panel2.TabIndex = 3;
            panel2.Paint += panel2_Paint;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(27, 31);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(72, 58);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // label13
            // 
            label13.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.DarkSlateBlue;
            label13.Location = new Point(120, 28);
            label13.Name = "label13";
            label13.Size = new Size(51, 61);
            label13.TabIndex = 11;
            label13.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(52, 89);
            label8.Name = "label8";
            label8.Size = new Size(155, 23);
            label8.TabIndex = 10;
            label8.Text = "Requests approved";
            label8.Click += label8_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(97, 5);
            label4.Name = "label4";
            label4.Size = new Size(85, 23);
            label4.TabIndex = 9;
            label4.Text = "Approved";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.HighlightText;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(label14);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label5);
            panel3.Location = new Point(658, 73);
            panel3.Name = "panel3";
            panel3.Size = new Size(293, 120);
            panel3.TabIndex = 4;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(29, 26);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(81, 60);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // label14
            // 
            label14.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.Red;
            label14.Location = new Point(125, 28);
            label14.Name = "label14";
            label14.Size = new Size(44, 55);
            label14.TabIndex = 11;
            label14.Text = "0";
            label14.Click += label14_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(63, 89);
            label9.Name = "label9";
            label9.Size = new Size(186, 23);
            label9.TabIndex = 10;
            label9.Text = "Requests not approved";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(114, 0);
            label5.Name = "label5";
            label5.Size = new Size(76, 23);
            label5.TabIndex = 9;
            label5.Text = "Rejected";
            // 
            // label10
            // 
            label10.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.FromArgb(255, 128, 0);
            label10.Location = new Point(126, 26);
            label10.Name = "label10";
            label10.Size = new Size(54, 63);
            label10.TabIndex = 7;
            label10.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(108, 3);
            label6.Name = "label6";
            label6.Size = new Size(72, 23);
            label6.TabIndex = 8;
            label6.Text = "Pending";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(51, 89);
            label7.Name = "label7";
            label7.Size = new Size(196, 23);
            label7.TabIndex = 9;
            label7.Text = "Requests awating review";
            label7.Click += label7_Click;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.HighlightText;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(pictureBox1);
            panel5.Controls.Add(label7);
            panel5.Controls.Add(label6);
            panel5.Controls.Add(label10);
            panel5.Location = new Point(12, 73);
            panel5.Name = "panel5";
            panel5.Size = new Size(285, 120);
            panel5.TabIndex = 9;
            panel5.Paint += panel5_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(20, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(82, 57);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.DarkSlateBlue;
            panel4.Location = new Point(341, 189);
            panel4.Name = "panel4";
            panel4.Size = new Size(280, 5);
            panel4.TabIndex = 11;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.Location = new Point(658, 189);
            panel1.Name = "panel1";
            panel1.Size = new Size(293, 5);
            panel1.TabIndex = 12;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(255, 128, 0);
            panel6.Location = new Point(13, 189);
            panel6.Name = "panel6";
            panel6.Size = new Size(285, 5);
            panel6.TabIndex = 13;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colRequestID, colSchedule, ColSubmittedDate, ColStatus, colAdminComment, colAction });
            dataGridView1.Location = new Point(12, 222);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(939, 424);
            dataGridView1.TabIndex = 14;
            // 
            // colRequestID
            // 
            colRequestID.HeaderText = "Request ID";
            colRequestID.MinimumWidth = 6;
            colRequestID.Name = "colRequestID";
            colRequestID.Width = 156;
            // 
            // colSchedule
            // 
            colSchedule.HeaderText = "Schedule";
            colSchedule.MinimumWidth = 6;
            colSchedule.Name = "colSchedule";
            colSchedule.Width = 156;
            // 
            // ColSubmittedDate
            // 
            ColSubmittedDate.HeaderText = "Submitted Date";
            ColSubmittedDate.MinimumWidth = 6;
            ColSubmittedDate.Name = "ColSubmittedDate";
            ColSubmittedDate.Width = 156;
            // 
            // ColStatus
            // 
            ColStatus.HeaderText = "Status";
            ColStatus.MinimumWidth = 6;
            ColStatus.Name = "ColStatus";
            ColStatus.Width = 156;
            // 
            // colAdminComment
            // 
            colAdminComment.HeaderText = "Admin Comment";
            colAdminComment.MinimumWidth = 6;
            colAdminComment.Name = "colAdminComment";
            colAdminComment.Width = 156;
            // 
            // colAction
            // 
            colAction.HeaderText = "Action";
            colAction.MinimumWidth = 6;
            colAction.Name = "colAction";
            colAction.Width = 156;
            // 
            // RequestStatusControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(963, 737);
            Controls.Add(dataGridView1);
            Controls.Add(panel6);
            Controls.Add(panel1);
            Controls.Add(panel4);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "RequestStatusControl";
            Text = "RequestStatusControl";
            Load += ScheduleRequestsControl_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Panel panel2;
        private Panel panel3;
        private Label label4;
        private Label label5;
        private Label label8;
        private Label label9;
        private Label label13;
        private Label label14;
        private Label label10;
        private Label label6;
        private Label label7;
        private Panel panel5;
        private Panel panel4;
        private Panel panel1;
        private Panel panel6;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colRequestID;
        private DataGridViewTextBoxColumn colSchedule;
        private DataGridViewTextBoxColumn ColSubmittedDate;
        private DataGridViewTextBoxColumn ColStatus;
        private DataGridViewTextBoxColumn colAdminComment;
        private DataGridViewButtonColumn colAction;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
    }
}