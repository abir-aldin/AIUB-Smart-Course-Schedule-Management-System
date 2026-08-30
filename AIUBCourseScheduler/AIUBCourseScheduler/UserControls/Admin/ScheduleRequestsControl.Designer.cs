namespace AIUBCourseScheduler.UserControls.Admin
{
    partial class ScheduleRequestsControl
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
            label1 = new Label();
            label2 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            textBox4 = new TextBox();
            button1 = new Button();
            button4 = new Button();
            button5 = new Button();
            panel1 = new Panel();
            label3 = new Label();
            panel2 = new Panel();
            label4 = new Label();
            panel3 = new Panel();
            label11 = new Label();
            dgvRequests = new DataGridView();
            colRequestId = new DataGridViewTextBoxColumn();
            colStudent = new DataGridViewTextBoxColumn();
            colSubmittedDate = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colActions = new DataGridViewButtonColumn();
            groupBox1 = new GroupBox();
            dataGridView1 = new DataGridView();
            colCourseCode = new DataGridViewTextBoxColumn();
            colCourseTitle = new DataGridViewTextBoxColumn();
            colSection = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Navy;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(179, 28);
            label1.TabIndex = 0;
            label1.Text = "Schedule Request";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlDark;
            label2.Location = new Point(12, 37);
            label2.Name = "label2";
            label2.Size = new Size(372, 20);
            label2.TabIndex = 1;
            label2.Text = "Review and manage student schedule change requests.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ControlLightLight;
            label5.ForeColor = SystemColors.ButtonShadow;
            label5.Location = new Point(96, 63);
            label5.Name = "label5";
            label5.Size = new Size(134, 20);
            label5.TabIndex = 10;
            label5.Text = "Approved requests";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ControlLightLight;
            label6.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.LimeGreen;
            label6.Location = new Point(127, 28);
            label6.Name = "label6";
            label6.Size = new Size(33, 38);
            label6.TabIndex = 11;
            label6.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = SystemColors.ControlLightLight;
            label7.ForeColor = SystemColors.ButtonShadow;
            label7.Location = new Point(88, 63);
            label7.Name = "label7";
            label7.Size = new Size(126, 20);
            label7.TabIndex = 12;
            label7.Text = "Rejected requests";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = SystemColors.ControlLightLight;
            label8.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Red;
            label8.Location = new Point(117, 25);
            label8.Name = "label8";
            label8.Size = new Size(33, 38);
            label8.TabIndex = 13;
            label8.Text = "0";
            label8.Click += label8_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = SystemColors.ControlLightLight;
            label9.ForeColor = SystemColors.ButtonShadow;
            label9.Location = new Point(57, 63);
            label9.Name = "label9";
            label9.Size = new Size(186, 20);
            label9.TabIndex = 17;
            label9.Text = "Request awaiting approval";
            label9.TextAlign = ContentAlignment.BottomCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = SystemColors.ControlLightLight;
            label10.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Orange;
            label10.Location = new Point(105, 25);
            label10.Name = "label10";
            label10.Size = new Size(33, 38);
            label10.TabIndex = 18;
            label10.Text = "0";
            // 
            // textBox4
            // 
            textBox4.ForeColor = SystemColors.ActiveCaptionText;
            textBox4.Location = new Point(31, 205);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Search by student name or request ID...";
            textBox4.Size = new Size(354, 32);
            textBox4.TabIndex = 20;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.DarkBlue;
            button1.Location = new Point(96, 650);
            button1.Name = "button1";
            button1.Size = new Size(190, 52);
            button1.TabIndex = 22;
            button1.Text = "View Schedule";
            button1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.Green;
            button4.Location = new Point(392, 650);
            button4.Name = "button4";
            button4.Size = new Size(190, 52);
            button4.TabIndex = 26;
            button4.Text = "Approve";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.Crimson;
            button5.Location = new Point(699, 650);
            button5.Name = "button5";
            button5.Size = new Size(190, 52);
            button5.TabIndex = 28;
            button5.Text = "Reject";
            button5.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Location = new Point(31, 74);
            panel1.Name = "panel1";
            panel1.Size = new Size(266, 96);
            panel1.TabIndex = 31;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Navy;
            label3.Location = new Point(88, 3);
            label3.Name = "label3";
            label3.Size = new Size(72, 23);
            label3.TabIndex = 32;
            label3.Text = "Pending";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLightLight;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(350, 74);
            panel2.Name = "panel2";
            panel2.Size = new Size(262, 96);
            panel2.TabIndex = 33;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Navy;
            label4.Location = new Point(96, 3);
            label4.Name = "label4";
            label4.Size = new Size(94, 25);
            label4.TabIndex = 34;
            label4.Text = "Approved";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLightLight;
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label7);
            panel3.Location = new Point(664, 74);
            panel3.Name = "panel3";
            panel3.Size = new Size(261, 96);
            panel3.TabIndex = 35;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.Navy;
            label11.Location = new Point(98, 5);
            label11.Name = "label11";
            label11.Size = new Size(76, 23);
            label11.TabIndex = 36;
            label11.Text = "Rejected";
            // 
            // dgvRequests
            // 
            dgvRequests.AllowUserToAddRows = false;
            dgvRequests.BackgroundColor = SystemColors.ButtonFace;
            dgvRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequests.Columns.AddRange(new DataGridViewColumn[] { colRequestId, colStudent, colSubmittedDate, colStatus, colActions });
            dgvRequests.Location = new Point(88, 259);
            dgvRequests.Name = "dgvRequests";
            dgvRequests.ReadOnly = true;
            dgvRequests.RowHeadersVisible = false;
            dgvRequests.RowHeadersWidth = 51;
            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.Size = new Size(750, 152);
            dgvRequests.TabIndex = 36;
            dgvRequests.CellContentClick += dgvRequests_CellContentClick;
            // 
            // colRequestId
            // 
            colRequestId.HeaderText = "Request ID";
            colRequestId.MinimumWidth = 6;
            colRequestId.Name = "colRequestId";
            colRequestId.ReadOnly = true;
            colRequestId.Width = 150;
            // 
            // colStudent
            // 
            colStudent.HeaderText = "Student";
            colStudent.MinimumWidth = 6;
            colStudent.Name = "colStudent";
            colStudent.ReadOnly = true;
            colStudent.Width = 150;
            // 
            // colSubmittedDate
            // 
            colSubmittedDate.HeaderText = "Submitted Date";
            colSubmittedDate.MinimumWidth = 6;
            colSubmittedDate.Name = "colSubmittedDate";
            colSubmittedDate.ReadOnly = true;
            colSubmittedDate.Width = 150;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            colStatus.Width = 150;
            // 
            // colActions
            // 
            colActions.HeaderText = "Actions";
            colActions.MinimumWidth = 6;
            colActions.Name = "colActions";
            colActions.ReadOnly = true;
            colActions.Width = 150;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ControlLightLight;
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.MidnightBlue;
            groupBox1.Location = new Point(96, 430);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(611, 195);
            groupBox1.TabIndex = 38;
            groupBox1.TabStop = false;
            groupBox1.Text = "Selected Course";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ButtonFace;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colCourseCode, colCourseTitle, colSection });
            dataGridView1.Location = new Point(13, 40);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(591, 127);
            dataGridView1.TabIndex = 0;
            // 
            // colCourseCode
            // 
            colCourseCode.HeaderText = "Course Code";
            colCourseCode.MinimumWidth = 6;
            colCourseCode.Name = "colCourseCode";
            colCourseCode.ReadOnly = true;
            // 
            // colCourseTitle
            // 
            colCourseTitle.HeaderText = "Course Title";
            colCourseTitle.MinimumWidth = 6;
            colCourseTitle.Name = "colCourseTitle";
            colCourseTitle.ReadOnly = true;
            // 
            // colSection
            // 
            colSection.HeaderText = "Section";
            colSection.MinimumWidth = 6;
            colSection.Name = "colSection";
            colSection.ReadOnly = true;
            // 
            // ScheduleRequestsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(963, 737);
            Controls.Add(groupBox1);
            Controls.Add(dgvRequests);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ScheduleRequestsControl";
            Text = "ScheduleRequestsControl";
            Load += ScheduleRequestsControl_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox textBox4;
        private Button button1;
        private Button button4;
        private Button button5;
        private Panel panel1;
        private Label label3;
        private Panel panel2;
        private Label label4;
        private Panel panel3;
        private Label label11;
        private DataGridView dgvRequests;
        private GroupBox groupBox1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colCourseCode;
        private DataGridViewTextBoxColumn colCourseTitle;
        private DataGridViewTextBoxColumn colSection;
        private DataGridViewTextBoxColumn colRequestId;
        private DataGridViewTextBoxColumn colStudent;
        private DataGridViewTextBoxColumn colSubmittedDate;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewButtonColumn colActions;
    }
}