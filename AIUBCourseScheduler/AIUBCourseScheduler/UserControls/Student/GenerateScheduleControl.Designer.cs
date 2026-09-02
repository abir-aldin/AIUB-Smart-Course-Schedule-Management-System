#nullable disable

using System.Drawing;
using System.Windows.Forms;

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
        /// <param name="disposing">
        /// true if managed resources should be disposed;
        /// otherwise, false.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing &&
                components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support.
        /// Do not modify the contents of this method
        /// with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label3 = new Label();
            button1 = new Button();
            groupBox2 = new GroupBox();
            label4 = new Label();
            numericUpDown1 = new NumericUpDown();
            label5 = new Label();
            numericUpDown2 = new NumericUpDown();
            label6 = new Label();
            numericUpDown3 = new NumericUpDown();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dataGridView1 = new DataGridView();
            TimeColumn = new DataGridViewTextBoxColumn();
            SundayColumn = new DataGridViewTextBoxColumn();
            MondayColumn = new DataGridViewTextBoxColumn();
            TuesdayColumn = new DataGridViewTextBoxColumn();
            WednesdayColumn = new DataGridViewTextBoxColumn();
            ThursdayColumn = new DataGridViewTextBoxColumn();
            tabPage2 = new TabPage();
            button2 = new Button();
            groupBox1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            groupBox2.SuspendLayout();
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
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(7, 43, 91);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(165, 35);
            label1.TabIndex = 0;
            label1.Text = "My Schedule";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8.5F);
            label2.ForeColor = SystemColors.ControlDark;
            label2.Location = new Point(12, 48);
            label2.Name = "label2";
            label2.Size = new Size(630, 20);
            label2.TabIndex = 1;
            label2.Text = "Set your preferences and generate the best possible schedules based on your selected courses";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(flowLayoutPanel1);
            groupBox1.Location = new Point(12, 82);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(8);
            groupBox1.Size = new Size(510, 145);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.White;
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(8, 22);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(3);
            flowLayoutPanel1.Size = new Size(494, 110);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.WrapContents = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(6, 6);
            label3.Margin = new Padding(3);
            label3.Name = "label3";
            label3.Size = new Size(171, 23);
            label3.TabIndex = 0;
            label3.Text = "Selected Courses (0)";
            // 
            // button1
            // 
            button1.BackColor = Color.RoyalBlue;
            button1.FlatAppearance.BorderColor = Color.LightGray;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(550, 94);
            button1.Name = "button1";
            button1.Size = new Size(385, 125);
            button1.TabIndex = 3;
            button1.Text = "Generate Clash-Free Schedules\r\nSystem will generate your preferred schedules";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.FromArgb(224, 199, 225);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(numericUpDown1);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(numericUpDown2);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(numericUpDown3);
            groupBox2.Controls.Add(checkBox1);
            groupBox2.Controls.Add(checkBox2);
            groupBox2.Controls.Add(checkBox3);
            groupBox2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox2.Location = new Point(12, 245);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(10);
            groupBox2.Size = new Size(939, 180);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Preference";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(12, 54);
            label4.Name = "label4";
            label4.Size = new Size(181, 20);
            label4.TabIndex = 0;
            label4.Text = "Minimum Available Seats";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Font = new Font("Segoe UI", 9F);
            numericUpDown1.Location = new Point(20, 91);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(240, 54);
            label5.Name = "label5";
            label5.Size = new Size(184, 20);
            label5.TabIndex = 2;
            label5.Text = "Maximum Available Seats";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Font = new Font("Segoe UI", 9F);
            numericUpDown2.Location = new Point(260, 91);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(150, 27);
            numericUpDown2.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(476, 54);
            label6.Name = "label6";
            label6.Size = new Size(156, 20);
            label6.TabIndex = 4;
            label6.Text = "Number of Schedules";
            // 
            // numericUpDown3
            // 
            numericUpDown3.Font = new Font("Segoe UI", 9F);
            numericUpDown3.Location = new Point(496, 91);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(150, 27);
            numericUpDown3.TabIndex = 5;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 8.5F);
            checkBox1.ForeColor = Color.Black;
            checkBox1.Location = new Point(690, 41);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(179, 24);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "Avoid 8:00 AM Classes";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Font = new Font("Segoe UI", 8.5F);
            checkBox2.ForeColor = Color.Black;
            checkBox2.Location = new Point(690, 76);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(133, 24);
            checkBox2.TabIndex = 7;
            checkBox2.Text = "Avoid Thursday";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Font = new Font("Segoe UI", 8.5F);
            checkBox3.ForeColor = Color.Black;
            checkBox3.Location = new Point(690, 111);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(179, 24);
            checkBox3.TabIndex = 8;
            checkBox3.Text = "Avoid Large Time Gap";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(50, 443);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(863, 190);
            tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(855, 157);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Schedule 1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeight = 34;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { TimeColumn, SundayColumn, MondayColumn, TuesdayColumn, WednesdayColumn, ThursdayColumn });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(849, 151);
            dataGridView1.TabIndex = 0;
            // 
            // TimeColumn
            // 
            TimeColumn.HeaderText = "Time";
            TimeColumn.MinimumWidth = 6;
            TimeColumn.Name = "TimeColumn";
            TimeColumn.ReadOnly = true;
            // 
            // SundayColumn
            // 
            SundayColumn.HeaderText = "Sunday";
            SundayColumn.MinimumWidth = 6;
            SundayColumn.Name = "SundayColumn";
            SundayColumn.ReadOnly = true;
            // 
            // MondayColumn
            // 
            MondayColumn.HeaderText = "Monday";
            MondayColumn.MinimumWidth = 6;
            MondayColumn.Name = "MondayColumn";
            MondayColumn.ReadOnly = true;
            // 
            // TuesdayColumn
            // 
            TuesdayColumn.HeaderText = "Tuesday";
            TuesdayColumn.MinimumWidth = 6;
            TuesdayColumn.Name = "TuesdayColumn";
            TuesdayColumn.ReadOnly = true;
            // 
            // WednesdayColumn
            // 
            WednesdayColumn.HeaderText = "Wednesday";
            WednesdayColumn.MinimumWidth = 6;
            WednesdayColumn.Name = "WednesdayColumn";
            WednesdayColumn.ReadOnly = true;
            // 
            // ThursdayColumn
            // 
            ThursdayColumn.HeaderText = "Thursday";
            ThursdayColumn.MinimumWidth = 6;
            ThursdayColumn.Name = "ThursdayColumn";
            ThursdayColumn.ReadOnly = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(855, 157);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Schedule 2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.BackColor = Color.Green;
            button2.FlatAppearance.BorderColor = Color.LightGray;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(328, 650);
            button2.Name = "button2";
            button2.Size = new Size(305, 58);
            button2.TabIndex = 6;
            button2.Text = "Save Schedule";
            button2.UseVisualStyleBackColor = false;
            // 
            // GenerateScheduleControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 251);
            ClientSize = new Size(963, 737);
            Controls.Add(button2);
            Controls.Add(tabControl1);
            Controls.Add(groupBox2);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "GenerateScheduleControl";
            Text = "GenerateScheduleControl";
            Load += GenerateScheduleControl_Load;
            groupBox1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
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

        private GroupBox groupBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label3;

        private Button button1;

        private GroupBox groupBox2;

        private Label label4;
        private NumericUpDown numericUpDown1;

        private Label label5;
        private NumericUpDown numericUpDown2;

        private Label label6;
        private NumericUpDown numericUpDown3;

        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;

        private DataGridView dataGridView1;

        private DataGridViewTextBoxColumn TimeColumn;
        private DataGridViewTextBoxColumn SundayColumn;
        private DataGridViewTextBoxColumn MondayColumn;
        private DataGridViewTextBoxColumn TuesdayColumn;
        private DataGridViewTextBoxColumn WednesdayColumn;
        private DataGridViewTextBoxColumn ThursdayColumn;

        private Button button2;
    }
}