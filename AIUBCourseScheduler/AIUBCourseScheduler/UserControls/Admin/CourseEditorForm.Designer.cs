namespace AIUBCourseScheduler.UserControls.Admin
{
    partial class CourseEditorForm
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            comboBox1 = new ComboBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            label7 = new Label();
            textBox1 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            button2 = new Button();
            button1 = new Button();
            panel3 = new Panel();
            panel2 = new Panel();
            label2 = new Label();
            label1 = new Label();
            errorProvider1 = new ErrorProvider(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(22, 26);
            panel1.Name = "panel1";
            panel1.Size = new Size(753, 402);
            panel1.TabIndex = 0;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.FromArgb(255, 128, 0);
            label10.Location = new Point(80, 243);
            label10.Name = "label10";
            label10.Size = new Size(21, 28);
            label10.TabIndex = 17;
            label10.Text = "*";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(255, 128, 0);
            label9.Location = new Point(120, 195);
            label9.Name = "label9";
            label9.Size = new Size(21, 28);
            label9.TabIndex = 16;
            label9.Text = "*";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(255, 128, 0);
            label8.Location = new Point(129, 150);
            label8.Name = "label8";
            label8.Size = new Size(21, 28);
            label8.TabIndex = 15;
            label8.Text = "*";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Active", "Inactive" });
            comboBox1.Location = new Point(211, 248);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(495, 28);
            comboBox1.TabIndex = 14;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(214, 200);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Enter department";
            textBox3.Size = new Size(492, 27);
            textBox3.TabIndex = 13;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(214, 155);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Enter course name";
            textBox2.Size = new Size(496, 27);
            textBox2.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = SystemColors.ControlDarkDark;
            label7.Location = new Point(215, 131);
            label7.Name = "label7";
            label7.Size = new Size(283, 20);
            label7.TabIndex = 11;
            label7.Text = "Leave blank if no course code is available";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(214, 100);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "e.g.  CSE 311";
            textBox1.Size = new Size(500, 27);
            textBox1.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(35, 251);
            label6.Name = "label6";
            label6.Size = new Size(49, 20);
            label6.TabIndex = 9;
            label6.Text = "Status";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(35, 203);
            label5.Name = "label5";
            label5.Size = new Size(89, 20);
            label5.TabIndex = 8;
            label5.Text = "Department";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 158);
            label4.Name = "label4";
            label4.Size = new Size(98, 20);
            label4.TabIndex = 7;
            label4.Text = "Course Name";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 100);
            label3.Name = "label3";
            label3.Size = new Size(161, 20);
            label3.TabIndex = 6;
            label3.Text = "Course code (optional)";
            // 
            // button2
            // 
            button2.BackColor = SystemColors.HotTrack;
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(604, 353);
            button2.Name = "button2";
            button2.Size = new Size(106, 41);
            button2.TabIndex = 5;
            button2.Text = "Save Course";
            button2.UseVisualStyleBackColor = false;
            button2.Click += btnSaveCourse_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.HotTrack;
            button1.Location = new Point(480, 352);
            button1.Name = "button1";
            button1.Size = new Size(108, 42);
            button1.TabIndex = 4;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlDarkDark;
            panel3.Location = new Point(0, 338);
            panel3.Name = "panel3";
            panel3.Size = new Size(753, 1);
            panel3.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlDarkDark;
            panel2.Location = new Point(21, 77);
            panel2.Name = "panel2";
            panel2.Size = new Size(709, 1);
            panel2.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(17, 43);
            label2.Name = "label2";
            label2.Size = new Size(242, 20);
            label2.TabIndex = 1;
            label2.Text = "Enter the course information below";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 10);
            label1.Name = "label1";
            label1.Size = new Size(191, 31);
            label1.TabIndex = 0;
            label1.Text = "Add New Course";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // CourseEditorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "CourseEditorForm";
            Text = "CourseEditorForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private Button button2;
        private Button button1;
        private Panel panel3;
        private Panel panel2;
        private Label label4;
        private Label label3;
        private TextBox textBox1;
        private Label label6;
        private Label label5;
        private ComboBox comboBox1;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label7;
        private Label label10;
        private Label label9;
        private Label label8;
        private ErrorProvider errorProvider1;
    }
}