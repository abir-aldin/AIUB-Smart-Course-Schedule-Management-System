namespace AIUBCourseScheduler.UserControls.Student
{
    partial class MySchedulesControl
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
            button1 = new Button();
            dataGridView1 = new DataGridView();
            Schedule = new DataGridViewTextBoxColumn();
            CreatedDate = new DataGridViewTextBoxColumn();
            Courses = new DataGridViewTextBoxColumn();
            Dataview = new DataGridViewButtonColumn();
            Action2 = new DataGridViewButtonColumn();
            panel1 = new Panel();
            dataGridView2 = new DataGridView();
            Time = new DataGridViewTextBoxColumn();
            Sunday = new DataGridViewTextBoxColumn();
            Monday = new DataGridViewTextBoxColumn();
            Tuesday = new DataGridViewTextBoxColumn();
            Wednesday = new DataGridViewTextBoxColumn();
            Thursday = new DataGridViewTextBoxColumn();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.Navy;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(192, 37);
            label1.TabIndex = 0;
            label1.Text = "My Schedules";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(216, 236);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.MenuHighlight;
            button1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(417, 681);
            button1.Name = "button1";
            button1.Size = new Size(146, 44);
            button1.TabIndex = 2;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Schedule, CreatedDate, Courses, Dataview, Action2 });
            dataGridView1.Location = new Point(160, 61);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(678, 183);
            dataGridView1.TabIndex = 3;
            // 
            // Schedule
            // 
            Schedule.HeaderText = "Schedule";
            Schedule.MinimumWidth = 6;
            Schedule.Name = "Schedule";
            Schedule.Width = 125;
            // 
            // CreatedDate
            // 
            CreatedDate.HeaderText = "Created Date";
            CreatedDate.MinimumWidth = 6;
            CreatedDate.Name = "CreatedDate";
            CreatedDate.Width = 125;
            // 
            // Courses
            // 
            Courses.HeaderText = "Courses";
            Courses.MinimumWidth = 6;
            Courses.Name = "Courses";
            Courses.Width = 125;
            // 
            // Dataview
            // 
            Dataview.HeaderText = "Actions";
            Dataview.MinimumWidth = 6;
            Dataview.Name = "Dataview";
            Dataview.Width = 125;
            // 
            // Action2
            // 
            Action2.HeaderText = "Actions";
            Action2.MinimumWidth = 6;
            Action2.Name = "Action2";
            Action2.Width = 125;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(dataGridView2);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(54, 259);
            panel1.Name = "panel1";
            panel1.Size = new Size(871, 416);
            panel1.TabIndex = 4;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { Time, Sunday, Monday, Tuesday, Wednesday, Thursday });
            dataGridView2.Location = new Point(3, 26);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(865, 387);
            dataGridView2.TabIndex = 1;
            // 
            // Time
            // 
            Time.HeaderText = "Time";
            Time.MinimumWidth = 6;
            Time.Name = "Time";
            Time.Width = 125;
            // 
            // Sunday
            // 
            Sunday.HeaderText = "Sunday";
            Sunday.MinimumWidth = 6;
            Sunday.Name = "Sunday";
            Sunday.Width = 125;
            // 
            // Monday
            // 
            Monday.HeaderText = "Monday";
            Monday.MinimumWidth = 6;
            Monday.Name = "Monday";
            Monday.Width = 125;
            // 
            // Tuesday
            // 
            Tuesday.HeaderText = "Tuesday";
            Tuesday.MinimumWidth = 6;
            Tuesday.Name = "Tuesday";
            Tuesday.Width = 125;
            // 
            // Wednesday
            // 
            Wednesday.HeaderText = "Wednesday";
            Wednesday.MinimumWidth = 6;
            Wednesday.Name = "Wednesday";
            Wednesday.Width = 125;
            // 
            // Thursday
            // 
            Thursday.HeaderText = "Thursday";
            Thursday.MinimumWidth = 6;
            Thursday.Name = "Thursday";
            Thursday.Width = 125;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(309, 23);
            label3.TabIndex = 0;
            label3.Text = "Schedule 1 - Weekly Timetable Preview";
            // 
            // MySchedulesControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(963, 737);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MySchedulesControl";
            Text = "MySchedulesControl";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button button1;
        private DataGridView dataGridView1;
        private Panel panel1;
        private Label label3;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn Time;
        private DataGridViewTextBoxColumn Sunday;
        private DataGridViewTextBoxColumn Monday;
        private DataGridViewTextBoxColumn Tuesday;
        private DataGridViewTextBoxColumn Wednesday;
        private DataGridViewTextBoxColumn Thursday;
        private DataGridViewTextBoxColumn Schedule;
        private DataGridViewTextBoxColumn CreatedDate;
        private DataGridViewTextBoxColumn Courses;
        private DataGridViewButtonColumn Dataview;
        private DataGridViewButtonColumn Action2;
    }
}