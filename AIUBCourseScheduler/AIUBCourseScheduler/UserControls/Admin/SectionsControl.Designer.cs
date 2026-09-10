namespace AIUBCourseScheduler.UserControls.Admin
{
    partial class SectionsControl
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
            panel1 = new Panel();
            button2 = new Button();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            SectionColumn = new DataGridViewTextBoxColumn();
            CourseColumn = new DataGridViewTextBoxColumn();
            DayTimeColumn = new DataGridViewTextBoxColumn();
            RoomColumn = new DataGridViewTextBoxColumn();
            CpacityColumn = new DataGridViewTextBoxColumn();
            EnrolledColumn = new DataGridViewTextBoxColumn();
            ActionColumn1 = new DataGridViewButtonColumn();
            ActionColumn2 = new DataGridViewButtonColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(350, 50);
            label1.TabIndex = 0;
            label1.Text = "Section Management";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(12, 49);
            label2.Name = "label2";
            label2.Size = new Size(301, 20);
            label2.TabIndex = 1;
            label2.Text = "Create,view, and manage all course section";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.HotTrack;
            button1.Cursor = Cursors.Hand;
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(823, 22);
            button1.Name = "button1";
            button1.Size = new Size(128, 47);
            button1.TabIndex = 2;
            button1.Text = "+  Add Section\r\n";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(21, 79);
            panel1.Name = "panel1";
            panel1.Size = new Size(930, 72);
            panel1.TabIndex = 3;
            // 
            // button2
            // 
            button2.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(802, 17);
            button2.Name = "button2";
            button2.Size = new Size(111, 39);
            button2.TabIndex = 1;
            button2.Text = "Refresh";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(28, 21);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Search by section, course";
            textBox1.RightToLeft = RightToLeft.No;
            textBox1.Size = new Size(313, 30);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { SectionColumn, CourseColumn, DayTimeColumn, RoomColumn, CpacityColumn, EnrolledColumn, ActionColumn1, ActionColumn2 });
            dataGridView1.Location = new Point(21, 157);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(913, 531);
            dataGridView1.TabIndex = 4;
            // 
            // SectionColumn
            // 
            SectionColumn.HeaderText = "Section";
            SectionColumn.MinimumWidth = 6;
            SectionColumn.Name = "SectionColumn";
            SectionColumn.Width = 96;
            // 
            // CourseColumn
            // 
            CourseColumn.HeaderText = "Course";
            CourseColumn.MinimumWidth = 6;
            CourseColumn.Name = "CourseColumn";
            CourseColumn.Width = 96;
            // 
            // DayTimeColumn
            // 
            DayTimeColumn.HeaderText = "Day & Time";
            DayTimeColumn.MinimumWidth = 6;
            DayTimeColumn.Name = "DayTimeColumn";
            DayTimeColumn.Width = 96;
            // 
            // RoomColumn
            // 
            RoomColumn.HeaderText = "Room";
            RoomColumn.MinimumWidth = 6;
            RoomColumn.Name = "RoomColumn";
            RoomColumn.Width = 96;
            // 
            // CpacityColumn
            // 
            CpacityColumn.HeaderText = "Capacity";
            CpacityColumn.MinimumWidth = 6;
            CpacityColumn.Name = "CpacityColumn";
            CpacityColumn.Width = 96;
            // 
            // EnrolledColumn
            // 
            EnrolledColumn.HeaderText = "Enrolled";
            EnrolledColumn.MinimumWidth = 6;
            EnrolledColumn.Name = "EnrolledColumn";
            EnrolledColumn.Width = 96;
            // 
            // ActionColumn1
            // 
            ActionColumn1.HeaderText = "Action1";
            ActionColumn1.MinimumWidth = 6;
            ActionColumn1.Name = "ActionColumn1";
            ActionColumn1.Width = 96;
            // 
            // ActionColumn2
            // 
            ActionColumn2.HeaderText = "Action2";
            ActionColumn2.MinimumWidth = 6;
            ActionColumn2.Name = "ActionColumn2";
            ActionColumn2.Width = 96;
            // 
            // SectionsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(963, 737);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SectionsControl";
            Text = "SectionsControl";
            Load += SectionsControl_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button button1;
        private Panel panel1;
        private TextBox textBox1;
        private Button button2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn SectionColumn;
        private DataGridViewTextBoxColumn CourseColumn;
        private DataGridViewTextBoxColumn DayTimeColumn;
        private DataGridViewTextBoxColumn RoomColumn;
        private DataGridViewTextBoxColumn CpacityColumn;
        private DataGridViewTextBoxColumn EnrolledColumn;
        private DataGridViewButtonColumn ActionColumn1;
        private DataGridViewButtonColumn ActionColumn2;
    }
}