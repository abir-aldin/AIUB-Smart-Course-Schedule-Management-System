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
            groupBox1 = new GroupBox();
            button1 = new Button();
            label3 = new Label();
            groupBox2 = new GroupBox();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            label6 = new Label();
            label5 = new Label();
            numericUpDown3 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            label4 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dataGridView1 = new DataGridView();
            TimeColumn = new DataGridViewTextBoxColumn();
            Sundaycolumn = new DataGridViewTextBoxColumn();
            MondayColumn = new DataGridViewTextBoxColumn();
            TuesdayColumn = new DataGridViewTextBoxColumn();
            WednesdayColumn = new DataGridViewTextBoxColumn();
            ThursdayColumn = new DataGridViewTextBoxColumn();
            tabPage2 = new TabPage();
            dataGridView2 = new DataGridView();
            TimeColumn2 = new DataGridViewTextBoxColumn();
            SundayColumn2 = new DataGridViewTextBoxColumn();
            MondayColumn2 = new DataGridViewTextBoxColumn();
            TuesdayColumn2 = new DataGridViewTextBoxColumn();
            WednesdayColumn2 = new DataGridViewTextBoxColumn();
            ThursdayColumn2 = new DataGridViewTextBoxColumn();
            button2 = new Button();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Navy;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(151, 31);
            label1.TabIndex = 0;
            label1.Text = "My Schedule";
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
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ControlLightLight;
            groupBox1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 94);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(505, 119);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Selected Courses(0)";
            // 
            // button1
            // 
            button1.BackColor = Color.RoyalBlue;
            button1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(561, 94);
            button1.Name = "button1";
            button1.Size = new Size(390, 119);
            button1.TabIndex = 3;
            button1.Text = "Generate Clash- Free Schedules";
            button1.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.RoyalBlue;
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(605, 167);
            label3.Name = "label3";
            label3.Size = new Size(317, 20);
            label3.TabIndex = 4;
            label3.Text = "System will generate your  preferred schedules";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Thistle;
            groupBox2.Controls.Add(checkBox3);
            groupBox2.Controls.Add(checkBox2);
            groupBox2.Controls.Add(checkBox1);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(numericUpDown3);
            groupBox2.Controls.Add(numericUpDown2);
            groupBox2.Controls.Add(numericUpDown1);
            groupBox2.Controls.Add(label4);
            groupBox2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            groupBox2.Location = new Point(12, 261);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(939, 183);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Preferrence";
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            checkBox3.Location = new Point(691, 90);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(169, 23);
            checkBox3.TabIndex = 14;
            checkBox3.Text = "Avoid Large Time Gap";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            checkBox2.Location = new Point(691, 61);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(128, 23);
            checkBox2.TabIndex = 13;
            checkBox2.Text = "Avoid Thursday";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            checkBox1.Location = new Point(691, 31);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(168, 21);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "Avoid 8:00 AM Classes";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label6.Location = new Point(469, 61);
            label6.Name = "label6";
            label6.Size = new Size(175, 23);
            label6.TabIndex = 11;
            label6.Text = "Number of Schedules";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label5.Location = new Point(6, 61);
            label5.Name = "label5";
            label5.Size = new Size(203, 23);
            label5.TabIndex = 10;
            label5.Text = "Minimum Available Seats";
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(494, 106);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(150, 32);
            numericUpDown3.TabIndex = 9;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(21, 106);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(150, 32);
            numericUpDown2.TabIndex = 8;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(258, 106);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 32);
            numericUpDown1.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label4.Location = new Point(236, 61);
            label4.Name = "label4";
            label4.Size = new Size(207, 23);
            label4.TabIndex = 6;
            label4.Text = "Maximum Available Seats";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(50, 470);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(876, 147);
            tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(868, 114);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Schedule 1";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { TimeColumn, Sundaycolumn, MondayColumn, TuesdayColumn, WednesdayColumn, ThursdayColumn });
            dataGridView1.Location = new Point(27, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(809, 92);
            dataGridView1.TabIndex = 0;
            // 
            // TimeColumn
            // 
            TimeColumn.HeaderText = "Time";
            TimeColumn.MinimumWidth = 6;
            TimeColumn.Name = "TimeColumn";
            TimeColumn.Width = 125;
            // 
            // Sundaycolumn
            // 
            Sundaycolumn.HeaderText = "Sunday";
            Sundaycolumn.MinimumWidth = 6;
            Sundaycolumn.Name = "Sundaycolumn";
            Sundaycolumn.Width = 125;
            // 
            // MondayColumn
            // 
            MondayColumn.HeaderText = "Monday";
            MondayColumn.MinimumWidth = 6;
            MondayColumn.Name = "MondayColumn";
            MondayColumn.Width = 125;
            // 
            // TuesdayColumn
            // 
            TuesdayColumn.HeaderText = "Tuesday";
            TuesdayColumn.MinimumWidth = 6;
            TuesdayColumn.Name = "TuesdayColumn";
            TuesdayColumn.Width = 125;
            // 
            // WednesdayColumn
            // 
            WednesdayColumn.HeaderText = "Wednesday";
            WednesdayColumn.MinimumWidth = 6;
            WednesdayColumn.Name = "WednesdayColumn";
            WednesdayColumn.Width = 125;
            // 
            // ThursdayColumn
            // 
            ThursdayColumn.HeaderText = "Thursday";
            ThursdayColumn.MinimumWidth = 6;
            ThursdayColumn.Name = "ThursdayColumn";
            ThursdayColumn.Width = 125;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridView2);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(868, 114);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Schedule 2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { TimeColumn2, SundayColumn2, MondayColumn2, TuesdayColumn2, WednesdayColumn2, ThursdayColumn2 });
            dataGridView2.Location = new Point(30, 6);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(797, 80);
            dataGridView2.TabIndex = 0;
            // 
            // TimeColumn2
            // 
            TimeColumn2.HeaderText = "Time";
            TimeColumn2.MinimumWidth = 6;
            TimeColumn2.Name = "TimeColumn2";
            TimeColumn2.Width = 125;
            // 
            // SundayColumn2
            // 
            SundayColumn2.HeaderText = "Sunday";
            SundayColumn2.MinimumWidth = 6;
            SundayColumn2.Name = "SundayColumn2";
            SundayColumn2.Width = 125;
            // 
            // MondayColumn2
            // 
            MondayColumn2.HeaderText = "Monday";
            MondayColumn2.MinimumWidth = 6;
            MondayColumn2.Name = "MondayColumn2";
            MondayColumn2.Width = 125;
            // 
            // TuesdayColumn2
            // 
            TuesdayColumn2.HeaderText = "Tuesday";
            TuesdayColumn2.MinimumWidth = 6;
            TuesdayColumn2.Name = "TuesdayColumn2";
            TuesdayColumn2.Width = 125;
            // 
            // WednesdayColumn2
            // 
            WednesdayColumn2.HeaderText = "Wednesday";
            WednesdayColumn2.MinimumWidth = 6;
            WednesdayColumn2.Name = "WednesdayColumn2";
            WednesdayColumn2.Width = 125;
            // 
            // ThursdayColumn2
            // 
            ThursdayColumn2.HeaderText = "Thursday";
            ThursdayColumn2.MinimumWidth = 6;
            ThursdayColumn2.Name = "ThursdayColumn2";
            ThursdayColumn2.Width = 125;
            // 
            // button2
            // 
            button2.BackColor = Color.Green;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ControlLightLight;
            button2.Location = new Point(334, 644);
            button2.Name = "button2";
            button2.Size = new Size(308, 71);
            button2.TabIndex = 8;
            button2.Text = "Save Schedule";
            button2.UseVisualStyleBackColor = false;
            // 
            // GenerateScheduleControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(963, 737);
            Controls.Add(button2);
            Controls.Add(tabControl1);
            Controls.Add(groupBox2);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "GenerateScheduleControl";
            Text = "GenerateScheduleControl";
            Load += GenerateScheduleControl_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private Button button1;
        private Label label3;
        private GroupBox groupBox2;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        private Label label4;
        private CheckBox checkBox1;
        private Label label6;
        private Label label5;
        private NumericUpDown numericUpDown3;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn TimeColumn;
        private DataGridViewTextBoxColumn Sundaycolumn;
        private DataGridViewTextBoxColumn MondayColumn;
        private DataGridViewTextBoxColumn TuesdayColumn;
        private DataGridViewTextBoxColumn WednesdayColumn;
        private DataGridViewTextBoxColumn ThursdayColumn;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn TimeColumn2;
        private DataGridViewTextBoxColumn SundayColumn2;
        private DataGridViewTextBoxColumn MondayColumn2;
        private DataGridViewTextBoxColumn TuesdayColumn2;
        private DataGridViewTextBoxColumn WednesdayColumn2;
        private DataGridViewTextBoxColumn ThursdayColumn2;
        private Button button2;
    }
}