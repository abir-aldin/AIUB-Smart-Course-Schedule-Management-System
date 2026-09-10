namespace AIUBCourseScheduler.UserControls.Admin
{
    partial class CoursesControl
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            panel1 = new Panel();
            button2 = new Button();
            dgvCourses = new DataGridView();
            colCoursecode = new DataGridViewTextBoxColumn();
            colCourseName = new DataGridViewTextBoxColumn();
            colCredits = new DataGridViewTextBoxColumn();
            colDepartment = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            EditColumn = new DataGridViewButtonColumn();
            DeleteColumn = new DataGridViewButtonColumn();
            panel2 = new Panel();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            label3 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(247, 31);
            label1.TabIndex = 0;
            label1.Text = "Course Management";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(12, 52);
            label2.Name = "label2";
            label2.Size = new Size(403, 23);
            label2.TabIndex = 1;
            label2.Text = "View,add,edit,and manage all courses in the system";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.HotTrack;
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(807, 24);
            button1.Name = "button1";
            button1.Size = new Size(127, 41);
            button1.TabIndex = 2;
            button1.Text = "+ Add Course";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(42, 23);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Search course code or name";
            textBox1.Size = new Size(230, 32);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(20, 86);
            panel1.Name = "panel1";
            panel1.Size = new Size(914, 75);
            panel1.TabIndex = 4;
            // 
            // button2
            // 
            button2.Location = new Point(787, 16);
            button2.Name = "button2";
            button2.Size = new Size(111, 40);
            button2.TabIndex = 4;
            button2.Text = "Clear Filters";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dgvCourses
            // 
            dgvCourses.AllowUserToAddRows = false;
            dgvCourses.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCourses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCourses.Columns.AddRange(new DataGridViewColumn[] { colCoursecode, colCourseName, colCredits, colDepartment, colStatus, EditColumn, DeleteColumn });
            dgvCourses.Location = new Point(22, 167);
            dgvCourses.MultiSelect = false;
            dgvCourses.Name = "dgvCourses";
            dgvCourses.ReadOnly = true;
            dgvCourses.RowHeadersVisible = false;
            dgvCourses.RowHeadersWidth = 51;
            dgvCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCourses.Size = new Size(912, 483);
            dgvCourses.TabIndex = 5;
            dgvCourses.CellContentClick += dgvCourses_CellContentClick;
            // 
            // colCoursecode
            // 
            colCoursecode.DataPropertyName = "CourseCode";
            colCoursecode.HeaderText = "Course Code";
            colCoursecode.MinimumWidth = 6;
            colCoursecode.Name = "colCoursecode";
            colCoursecode.ReadOnly = true;
            colCoursecode.Width = 125;
            // 
            // colCourseName
            // 
            colCourseName.DataPropertyName = "CourseName";
            colCourseName.HeaderText = "Course Name";
            colCourseName.MinimumWidth = 6;
            colCourseName.Name = "colCourseName";
            colCourseName.ReadOnly = true;
            colCourseName.Width = 220;
            // 
            // colCredits
            // 
            colCredits.DataPropertyName = "Credits";
            colCredits.HeaderText = "Credits";
            colCredits.MinimumWidth = 6;
            colCredits.Name = "colCredits";
            colCredits.ReadOnly = true;
            colCredits.Width = 80;
            // 
            // colDepartment
            // 
            colDepartment.DataPropertyName = "Department";
            colDepartment.HeaderText = "Department";
            colDepartment.MinimumWidth = 6;
            colDepartment.Name = "colDepartment";
            colDepartment.ReadOnly = true;
            colDepartment.Width = 220;
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "Status";
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            colStatus.Width = 125;
            // 
            // EditColumn
            // 
            EditColumn.HeaderText = "Action1";
            EditColumn.MinimumWidth = 6;
            EditColumn.Name = "EditColumn";
            EditColumn.ReadOnly = true;
            EditColumn.Text = "Edit";
            EditColumn.UseColumnTextForButtonValue = true;
            EditColumn.Width = 125;
            // 
            // DeleteColumn
            // 
            DeleteColumn.HeaderText = "Action2";
            DeleteColumn.MinimumWidth = 6;
            DeleteColumn.Name = "DeleteColumn";
            DeleteColumn.ReadOnly = true;
            DeleteColumn.Text = "Delete";
            DeleteColumn.UseColumnTextForButtonValue = true;
            DeleteColumn.Width = 125;
            // 
            // panel2
            // 
            panel2.Controls.Add(button7);
            panel2.Controls.Add(button6);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(23, 649);
            panel2.Name = "panel2";
            panel2.Size = new Size(911, 45);
            panel2.TabIndex = 6;
            // 
            // button7
            // 
            button7.ForeColor = SystemColors.MenuHighlight;
            button7.Location = new Point(784, 8);
            button7.Name = "button7";
            button7.Size = new Size(94, 29);
            button7.TabIndex = 5;
            button7.Text = "Next";
            button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(746, 8);
            button6.Name = "button6";
            button6.Size = new Size(28, 29);
            button6.TabIndex = 4;
            button6.Text = "3";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(712, 8);
            button5.Name = "button5";
            button5.Size = new Size(28, 29);
            button5.TabIndex = 3;
            button5.Text = "2";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(677, 8);
            button4.Name = "button4";
            button4.Size = new Size(29, 29);
            button4.TabIndex = 2;
            button4.Text = "1";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.ForeColor = SystemColors.MenuHighlight;
            button3.Location = new Point(577, 8);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 1;
            button3.Text = "Prevoius";
            button3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(11, 12);
            label3.Name = "label3";
            label3.Size = new Size(208, 20);
            label3.TabIndex = 0;
            label3.Text = "Showing 1 to 10 of 24 courses";
            // 
            // CoursesControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(963, 737);
            Controls.Add(panel2);
            Controls.Add(dgvCourses);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "CoursesControl";
            Text = "CoursesControl";
            Load += CoursesControl_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button button1;
        private TextBox textBox1;
        private Panel panel1;
        private Button button2;
        private DataGridView dgvCourses;
        private Panel panel2;
        private Label label3;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private DataGridViewTextBoxColumn colCoursecode;
        private DataGridViewTextBoxColumn colCourseName;
        private DataGridViewTextBoxColumn colCredits;
        private DataGridViewTextBoxColumn colDepartment;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewButtonColumn EditColumn;
        private DataGridViewButtonColumn DeleteColumn;
    }
}