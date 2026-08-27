namespace AIUBCourseScheduler.UserControls.Student
{
    partial class GenerateScheduleControl
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            label3 = new Label();
            groupBox1 = new GroupBox();
            label4 = new Label();
            numericUpDown1 = new NumericUpDown();
            label5 = new Label();
            numericUpDown2 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            label6 = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            button1 = new Button();
            label7 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            dataGridView1 = new DataGridView();
            Time = new DataGridViewTextBoxColumn();
            Sunday = new DataGridViewTextBoxColumn();
            Monday = new DataGridViewTextBoxColumn();
            Tuesday = new DataGridViewTextBoxColumn();
            Wednesday = new DataGridViewTextBoxColumn();
            Thursday = new DataGridViewTextBoxColumn();
            flowLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Navy;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(213, 31);
            label1.TabIndex = 0;
            label1.Text = "Generate Schedule";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ButtonShadow;
            label2.Location = new Point(12, 40);
            label2.Name = "label2";
            label2.Size = new Size(630, 20);
            label2.TabIndex = 1;
            label2.Text = "Set your preferences and generate the best possible schedules based on your selected courses";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = SystemColors.ControlLightLight;
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Location = new Point(12, 74);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(559, 81);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            label3.ForeColor = Color.Navy;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(182, 20);
            label3.TabIndex = 3;
            label3.Text = "Selected Courses(0)";
            // 
            // groupBox1
            // 
            groupBox1.AccessibleName = "grpPreference";
            groupBox1.Controls.Add(checkBox3);
            groupBox1.Controls.Add(checkBox2);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(numericUpDown3);
            groupBox1.Controls.Add(numericUpDown2);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(numericUpDown1);
            groupBox1.Controls.Add(label4);
            groupBox1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.Navy;
            groupBox1.Location = new Point(12, 201);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(939, 160);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Preference";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(6, 44);
            label4.Name = "label4";
            label4.Size = new Size(181, 20);
            label4.TabIndex = 0;
            label4.Text = "Minimum Available Seats";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(23, 91);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 31);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(242, 44);
            label5.Name = "label5";
            label5.Size = new Size(184, 20);
            label5.TabIndex = 2;
            label5.Text = "Maximum Available Seats";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(252, 82);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(150, 31);
            numericUpDown2.TabIndex = 3;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(496, 82);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(150, 31);
            numericUpDown3.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ActiveCaptionText;
            label6.Location = new Point(490, 44);
            label6.Name = "label6";
            label6.Size = new Size(156, 20);
            label6.TabIndex = 5;
            label6.Text = "Number of Schedules";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBox1.ForeColor = SystemColors.ActiveCaptionText;
            checkBox1.Location = new Point(695, 30);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(238, 21);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "Avoid Early Classes (Before 8 AM)";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBox2.ForeColor = SystemColors.ActiveCaptionText;
            checkBox2.Location = new Point(695, 57);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(127, 21);
            checkBox2.TabIndex = 7;
            checkBox2.Text = "Avoid Thursday";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBox3.ForeColor = SystemColors.ActiveCaptionText;
            checkBox3.Location = new Point(695, 82);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(132, 21);
            checkBox3.TabIndex = 8;
            checkBox3.Text = "Avoid Large Gap";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.BackColor = Color.Blue;
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(595, 63);
            button1.Name = "button1";
            button1.Size = new Size(356, 106);
            button1.TabIndex = 4;
            button1.Text = "Generate Clash- Free Schedules";
            button1.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Blue;
            label7.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ButtonHighlight;
            label7.Location = new Point(642, 125);
            label7.Name = "label7";
            label7.Size = new Size(274, 17);
            label7.TabIndex = 5;
            label7.Text = "System will generateyour preferred schedules";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(18, 409);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(803, 233);
            tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.AccessibleName = "tabSchedule1";
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(795, 200);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Schedule 1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.AccessibleName = "tabsSchedule2";
            tabPage2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(795, 200);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Schedule 2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Time, Sunday, Monday, Tuesday, Wednesday, Thursday });
            dataGridView1.Location = new Point(3, 17);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(786, 164);
            dataGridView1.TabIndex = 0;
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
            // GenerateScheduleControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(963, 737);
            Controls.Add(tabControl1);
            Controls.Add(label7);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "GenerateScheduleControl";
            Text = "GenerateScheduleControl";
            Load += GenerateScheduleControl_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label3;
        private GroupBox groupBox1;
        private NumericUpDown numericUpDown1;
        private Label label4;
        private Label label5;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Label label6;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown2;
        private CheckBox checkBox3;
        private Button button1;
        private Label label7;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Time;
        private DataGridViewTextBoxColumn Sunday;
        private DataGridViewTextBoxColumn Monday;
        private DataGridViewTextBoxColumn Tuesday;
        private DataGridViewTextBoxColumn Wednesday;
        private DataGridViewTextBoxColumn Thursday;
    }
}