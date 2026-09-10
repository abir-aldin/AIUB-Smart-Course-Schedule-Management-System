namespace AIUBCourseScheduler.Forms
{
    partial class SectionEditorForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            comboBox4 = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            textBox1 = new TextBox();
            numericUpDown1 = new NumericUpDown();
            textBox2 = new TextBox();
            numericUpDown2 = new NumericUpDown();
            checkBox1 = new CheckBox();
            label11 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            label15 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            comboBox5 = new ComboBox();
            comboBox6 = new ComboBox();
            comboBox7 = new ComboBox();
            comboBox9 = new ComboBox();
            comboBox10 = new ComboBox();
            comboBox11 = new ComboBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label16 = new Label();
            button1 = new Button();
            button2 = new Button();
            label17 = new Label();
            label18 = new Label();
            label19 = new Label();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            label23 = new Label();
            label24 = new Label();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.Navy;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(237, 37);
            label1.TabIndex = 0;
            label1.Text = "Add New Section";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(12, 46);
            label2.Name = "label2";
            label2.Size = new Size(361, 20);
            label2.TabIndex = 1;
            label2.Text = "Enter section information and class meeting schedule";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(32, 90);
            label3.Name = "label3";
            label3.Size = new Size(63, 23);
            label3.TabIndex = 2;
            label3.Text = "Course";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(32, 116);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(372, 28);
            comboBox1.TabIndex = 3;
            comboBox1.Text = "Select a course";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(471, 116);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(372, 28);
            comboBox2.TabIndex = 4;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(32, 254);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(372, 28);
            comboBox3.TabIndex = 5;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(471, 254);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(372, 28);
            comboBox4.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(32, 157);
            label4.Name = "label4";
            label4.Size = new Size(70, 23);
            label4.TabIndex = 7;
            label4.Text = "Class ID";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(32, 228);
            label5.Name = "label5";
            label5.Size = new Size(107, 23);
            label5.TabIndex = 8;
            label5.Text = "Section Type";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(32, 300);
            label6.Name = "label6";
            label6.Size = new Size(76, 23);
            label6.TabIndex = 9;
            label6.Text = "Capacity";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(469, 90);
            label7.Name = "label7";
            label7.Size = new Size(126, 23);
            label7.TabIndex = 10;
            label7.Text = "Academic Term";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(471, 157);
            label8.Name = "label8";
            label8.Size = new Size(66, 23);
            label8.TabIndex = 11;
            label8.Text = "Section";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(471, 228);
            label9.Name = "label9";
            label9.Size = new Size(126, 23);
            label9.TabIndex = 12;
            label9.Text = "Offering Status";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(471, 300);
            label10.Name = "label10";
            label10.Size = new Size(124, 23);
            label10.TabIndex = 13;
            label10.Text = "Enrolled Count";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(32, 183);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "e.g.01234";
            textBox1.Size = new Size(372, 27);
            textBox1.TabIndex = 14;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(32, 329);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(372, 27);
            numericUpDown1.TabIndex = 15;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(471, 183);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "e.g. A or L1-A";
            textBox2.Size = new Size(372, 27);
            textBox2.TabIndex = 17;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(471, 329);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(372, 27);
            numericUpDown2.TabIndex = 18;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            checkBox1.ForeColor = Color.DarkGreen;
            checkBox1.Location = new Point(32, 371);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(140, 27);
            checkBox1.TabIndex = 19;
            checkBox1.Text = "Active Section";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.RoyalBlue;
            label11.Location = new Point(32, 424);
            label11.Name = "label11";
            label11.Size = new Size(228, 28);
            label11.TabIndex = 20;
            label11.Text = "Class Meeting Schedule";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(label15, 3, 0);
            tableLayoutPanel1.Controls.Add(label12, 0, 0);
            tableLayoutPanel1.Controls.Add(label13, 1, 0);
            tableLayoutPanel1.Controls.Add(label14, 2, 0);
            tableLayoutPanel1.Controls.Add(comboBox5, 0, 1);
            tableLayoutPanel1.Controls.Add(comboBox6, 1, 1);
            tableLayoutPanel1.Controls.Add(comboBox7, 2, 1);
            tableLayoutPanel1.Controls.Add(comboBox9, 0, 2);
            tableLayoutPanel1.Controls.Add(comboBox10, 1, 2);
            tableLayoutPanel1.Controls.Add(comboBox11, 2, 2);
            tableLayoutPanel1.Controls.Add(textBox3, 3, 1);
            tableLayoutPanel1.Controls.Add(textBox4, 3, 2);
            tableLayoutPanel1.Location = new Point(32, 455);
            tableLayoutPanel1.Margin = new Padding(10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.Size = new Size(692, 150);
            tableLayoutPanel1.TabIndex = 21;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(522, 0);
            label15.Name = "label15";
            label15.Size = new Size(49, 20);
            label15.TabIndex = 22;
            label15.Text = "Room";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(3, 0);
            label12.Name = "label12";
            label12.Size = new Size(35, 20);
            label12.TabIndex = 0;
            label12.Text = "Day";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(176, 0);
            label13.Name = "label13";
            label13.Size = new Size(77, 20);
            label13.TabIndex = 1;
            label13.Text = "Start Time";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(349, 0);
            label14.Name = "label14";
            label14.Size = new Size(71, 20);
            label14.TabIndex = 2;
            label14.Text = "End Time";
            // 
            // comboBox5
            // 
            comboBox5.Dock = DockStyle.Fill;
            comboBox5.FormattingEnabled = true;
            comboBox5.Items.AddRange(new object[] { "Sunday ", "Monday", "Tuesday", "Wednesday", "Thursday" });
            comboBox5.Location = new Point(3, 33);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(167, 28);
            comboBox5.TabIndex = 22;
            comboBox5.SelectedIndexChanged += comboBox5_SelectedIndexChanged;
            // 
            // comboBox6
            // 
            comboBox6.Dock = DockStyle.Fill;
            comboBox6.FormattingEnabled = true;
            comboBox6.Items.AddRange(new object[] { "8:00 AM", "9:40 AM", "11:20 AM", "1:00 PM", "2:40 PM" });
            comboBox6.Location = new Point(176, 33);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new Size(167, 28);
            comboBox6.TabIndex = 23;
            // 
            // comboBox7
            // 
            comboBox7.Dock = DockStyle.Fill;
            comboBox7.FormattingEnabled = true;
            comboBox7.Items.AddRange(new object[] { "9:30 AM", "11:10 AM", "12:50 PM", "1:30 PM", "4:10 PM" });
            comboBox7.Location = new Point(349, 33);
            comboBox7.Name = "comboBox7";
            comboBox7.Size = new Size(167, 28);
            comboBox7.TabIndex = 24;
            // 
            // comboBox9
            // 
            comboBox9.Dock = DockStyle.Fill;
            comboBox9.FormattingEnabled = true;
            comboBox9.Location = new Point(3, 93);
            comboBox9.Name = "comboBox9";
            comboBox9.Size = new Size(167, 28);
            comboBox9.TabIndex = 26;
            // 
            // comboBox10
            // 
            comboBox10.Dock = DockStyle.Fill;
            comboBox10.FormattingEnabled = true;
            comboBox10.Location = new Point(176, 93);
            comboBox10.Name = "comboBox10";
            comboBox10.Size = new Size(167, 28);
            comboBox10.TabIndex = 27;
            // 
            // comboBox11
            // 
            comboBox11.Dock = DockStyle.Fill;
            comboBox11.FormattingEnabled = true;
            comboBox11.Location = new Point(349, 93);
            comboBox11.Name = "comboBox11";
            comboBox11.Size = new Size(167, 28);
            comboBox11.TabIndex = 28;
            // 
            // textBox3
            // 
            textBox3.Dock = DockStyle.Fill;
            textBox3.Location = new Point(522, 33);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(167, 27);
            textBox3.TabIndex = 29;
            // 
            // textBox4
            // 
            textBox4.Dock = DockStyle.Fill;
            textBox4.Location = new Point(522, 93);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(167, 27);
            textBox4.TabIndex = 30;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.ForeColor = SystemColors.ControlDarkDark;
            label16.Location = new Point(12, 647);
            label16.Name = "label16";
            label16.Size = new Size(409, 23);
            label16.TabIndex = 22;
            label16.Text = "Theory sections require exactly 2 meeting schedules.";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button1.Location = new Point(471, 630);
            button1.Name = "button1";
            button1.Size = new Size(143, 55);
            button1.TabIndex = 23;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.BackColor = Color.Blue;
            button2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ControlLightLight;
            button2.Location = new Point(665, 630);
            button2.Name = "button2";
            button2.Size = new Size(178, 55);
            button2.TabIndex = 24;
            button2.Text = "Save Section";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.Red;
            label17.Location = new Point(589, 88);
            label17.Name = "label17";
            label17.Size = new Size(20, 25);
            label17.TabIndex = 25;
            label17.Text = "*";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.Red;
            label18.Location = new Point(89, 88);
            label18.Name = "label18";
            label18.Size = new Size(20, 25);
            label18.TabIndex = 26;
            label18.Text = "*";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = Color.Red;
            label19.Location = new Point(134, 226);
            label19.Name = "label19";
            label19.Size = new Size(20, 25);
            label19.TabIndex = 27;
            label19.Text = "*";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label20.ForeColor = Color.Red;
            label20.Location = new Point(101, 298);
            label20.Name = "label20";
            label20.Size = new Size(20, 25);
            label20.TabIndex = 28;
            label20.Text = "*";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label21.ForeColor = Color.Red;
            label21.Location = new Point(594, 298);
            label21.Name = "label21";
            label21.Size = new Size(20, 25);
            label21.TabIndex = 29;
            label21.Text = "*";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label22.ForeColor = Color.Red;
            label22.Location = new Point(594, 226);
            label22.Name = "label22";
            label22.Size = new Size(20, 25);
            label22.TabIndex = 30;
            label22.Text = "*";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label23.ForeColor = Color.Red;
            label23.Location = new Point(534, 155);
            label23.Name = "label23";
            label23.Size = new Size(20, 25);
            label23.TabIndex = 31;
            label23.Text = "*";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label24.ForeColor = Color.Red;
            label24.Location = new Point(101, 155);
            label24.Name = "label24";
            label24.Size = new Size(20, 25);
            label24.TabIndex = 32;
            label24.Text = "*";
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // SectionEditorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(883, 703);
            Controls.Add(label24);
            Controls.Add(label23);
            Controls.Add(label22);
            Controls.Add(label21);
            Controls.Add(label20);
            Controls.Add(label19);
            Controls.Add(label18);
            Controls.Add(label17);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label16);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(label11);
            Controls.Add(checkBox1);
            Controls.Add(numericUpDown2);
            Controls.Add(textBox2);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox1);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(comboBox4);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SectionEditorForm";
            Text = "SectionEditorForm";
            Load += SectionEditorForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox textBox1;
        private NumericUpDown numericUpDown1;
        private TextBox textBox2;
        private NumericUpDown numericUpDown2;
        private CheckBox checkBox1;
        private Label label11;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private ComboBox comboBox5;
        private ComboBox comboBox6;
        private ComboBox comboBox7;
        private ComboBox comboBox9;
        private ComboBox comboBox10;
        private ComboBox comboBox11;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label16;
        private Button button1;
        private Button button2;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private ErrorProvider errorProvider1;
    }
}