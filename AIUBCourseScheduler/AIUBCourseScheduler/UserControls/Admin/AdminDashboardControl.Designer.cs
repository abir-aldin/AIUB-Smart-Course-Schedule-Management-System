namespace AIUBCourseScheduler.UserControls.Admin
{
    partial class AdminDashboardControl
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
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboardControl));
            panelHeader = new Panel();
            labelTitle = new Label();
            labelSubtitle = new Label();
            panelStudents = new Panel();
            panelCourses = new Panel();
            panelSections = new Panel();
            panelPending = new Panel();
            panelApproved = new Panel();
            panelRejected = new Panel();
            labelStudentsTitle = new Label();
            labelCoursesTitle = new Label();
            labelSectionsTitle = new Label();
            labelPendingTitle = new Label();
            labelApprovedTitle = new Label();
            labelRejectedTitle = new Label();
            lblStudentsCount = new Label();
            lblCoursesCount = new Label();
            lblSectionsCount = new Label();
            lblPendingCount = new Label();
            lblApprovedCount = new Label();
            lblRejectedCount = new Label();
            labelRecent = new Label();
            dgvRecentRequests = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label1 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            panelHeader.SuspendLayout();
            panelStudents.SuspendLayout();
            panelCourses.SuspendLayout();
            panelSections.SuspendLayout();
            panelPending.SuspendLayout();
            panelApproved.SuspendLayout();
            panelRejected.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecentRequests).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.BorderStyle = BorderStyle.FixedSingle;
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Controls.Add(labelSubtitle);
            panelHeader.Location = new Point(20, 3);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(929, 90);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelTitle.ForeColor = Color.FromArgb(25, 45, 80);
            labelTitle.Location = new Point(20, 15);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(273, 41);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Admin Dashboard";
            // 
            // labelSubtitle
            // 
            labelSubtitle.AutoSize = true;
            labelSubtitle.Font = new Font("Segoe UI", 10F);
            labelSubtitle.ForeColor = Color.Gray;
            labelSubtitle.Location = new Point(22, 55);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(328, 23);
            labelSubtitle.TabIndex = 1;
            labelSubtitle.Text = "Overview of your course scheduler system";
            // 
            // panelStudents
            // 
            panelStudents.BackColor = Color.FromArgb(235, 245, 255);
            panelStudents.Controls.Add(pictureBox1);
            panelStudents.Controls.Add(label2);
            panelStudents.Controls.Add(label3);
            panelStudents.Location = new Point(41, 138);
            panelStudents.Name = "panelStudents";
            panelStudents.Size = new Size(221, 100);
            panelStudents.TabIndex = 1;
            // 
            // panelCourses
            // 
            panelCourses.BackColor = Color.FromArgb(235, 255, 245);
            panelCourses.Controls.Add(pictureBox2);
            panelCourses.Controls.Add(label1);
            panelCourses.Controls.Add(label7);
            panelCourses.Location = new Point(364, 138);
            panelCourses.Name = "panelCourses";
            panelCourses.Size = new Size(214, 100);
            panelCourses.TabIndex = 2;
            // 
            // panelSections
            // 
            panelSections.BackColor = Color.FromArgb(245, 235, 255);
            panelSections.Controls.Add(pictureBox3);
            panelSections.Controls.Add(label9);
            panelSections.Controls.Add(label6);
            panelSections.Location = new Point(692, 138);
            panelSections.Name = "panelSections";
            panelSections.Size = new Size(216, 100);
            panelSections.TabIndex = 3;
            // 
            // panelPending
            // 
            panelPending.BackColor = Color.FromArgb(255, 248, 220);
            panelPending.Controls.Add(pictureBox4);
            panelPending.Controls.Add(label10);
            panelPending.Controls.Add(label5);
            panelPending.Location = new Point(41, 276);
            panelPending.Name = "panelPending";
            panelPending.Size = new Size(221, 100);
            panelPending.TabIndex = 4;
            // 
            // panelApproved
            // 
            panelApproved.BackColor = Color.FromArgb(225, 250, 235);
            panelApproved.Controls.Add(pictureBox5);
            panelApproved.Controls.Add(label4);
            panelApproved.Controls.Add(label11);
            panelApproved.Location = new Point(364, 276);
            panelApproved.Name = "panelApproved";
            panelApproved.Size = new Size(214, 100);
            panelApproved.TabIndex = 5;
            // 
            // panelRejected
            // 
            panelRejected.BackColor = Color.FromArgb(255, 235, 235);
            panelRejected.Controls.Add(pictureBox6);
            panelRejected.Controls.Add(label12);
            panelRejected.Controls.Add(label8);
            panelRejected.Location = new Point(692, 276);
            panelRejected.Name = "panelRejected";
            panelRejected.Size = new Size(216, 100);
            panelRejected.TabIndex = 6;
            // 
            // labelStudentsTitle
            // 
            labelStudentsTitle.Location = new Point(0, 0);
            labelStudentsTitle.Name = "labelStudentsTitle";
            labelStudentsTitle.Size = new Size(100, 23);
            labelStudentsTitle.TabIndex = 0;
            // 
            // labelCoursesTitle
            // 
            labelCoursesTitle.Location = new Point(0, 0);
            labelCoursesTitle.Name = "labelCoursesTitle";
            labelCoursesTitle.Size = new Size(100, 23);
            labelCoursesTitle.TabIndex = 0;
            // 
            // labelSectionsTitle
            // 
            labelSectionsTitle.Location = new Point(0, 0);
            labelSectionsTitle.Name = "labelSectionsTitle";
            labelSectionsTitle.Size = new Size(100, 23);
            labelSectionsTitle.TabIndex = 0;
            // 
            // labelPendingTitle
            // 
            labelPendingTitle.Location = new Point(0, 0);
            labelPendingTitle.Name = "labelPendingTitle";
            labelPendingTitle.Size = new Size(100, 23);
            labelPendingTitle.TabIndex = 0;
            // 
            // labelApprovedTitle
            // 
            labelApprovedTitle.Location = new Point(0, 0);
            labelApprovedTitle.Name = "labelApprovedTitle";
            labelApprovedTitle.Size = new Size(100, 23);
            labelApprovedTitle.TabIndex = 0;
            // 
            // labelRejectedTitle
            // 
            labelRejectedTitle.Location = new Point(0, 0);
            labelRejectedTitle.Name = "labelRejectedTitle";
            labelRejectedTitle.Size = new Size(100, 23);
            labelRejectedTitle.TabIndex = 0;
            // 
            // lblStudentsCount
            // 
            lblStudentsCount.Location = new Point(0, 0);
            lblStudentsCount.Name = "lblStudentsCount";
            lblStudentsCount.Size = new Size(100, 23);
            lblStudentsCount.TabIndex = 0;
            // 
            // lblCoursesCount
            // 
            lblCoursesCount.Location = new Point(0, 0);
            lblCoursesCount.Name = "lblCoursesCount";
            lblCoursesCount.Size = new Size(100, 23);
            lblCoursesCount.TabIndex = 0;
            // 
            // lblSectionsCount
            // 
            lblSectionsCount.Location = new Point(0, 0);
            lblSectionsCount.Name = "lblSectionsCount";
            lblSectionsCount.Size = new Size(100, 23);
            lblSectionsCount.TabIndex = 0;
            // 
            // lblPendingCount
            // 
            lblPendingCount.Location = new Point(0, 0);
            lblPendingCount.Name = "lblPendingCount";
            lblPendingCount.Size = new Size(100, 23);
            lblPendingCount.TabIndex = 0;
            // 
            // lblApprovedCount
            // 
            lblApprovedCount.Location = new Point(0, 0);
            lblApprovedCount.Name = "lblApprovedCount";
            lblApprovedCount.Size = new Size(100, 23);
            lblApprovedCount.TabIndex = 0;
            // 
            // lblRejectedCount
            // 
            lblRejectedCount.Location = new Point(0, 0);
            lblRejectedCount.Name = "lblRejectedCount";
            lblRejectedCount.Size = new Size(100, 23);
            lblRejectedCount.TabIndex = 0;
            // 
            // labelRecent
            // 
            labelRecent.AutoSize = true;
            labelRecent.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelRecent.ForeColor = Color.FromArgb(25, 45, 80);
            labelRecent.Location = new Point(20, 400);
            labelRecent.Name = "labelRecent";
            labelRecent.Size = new Size(259, 28);
            labelRecent.TabIndex = 7;
            labelRecent.Text = "Recent Schedule Requests";
            // 
            // dgvRecentRequests
            // 
            dgvRecentRequests.AllowUserToAddRows = false;
            dgvRecentRequests.AllowUserToDeleteRows = false;
            dgvRecentRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecentRequests.BackgroundColor = Color.White;
            dgvRecentRequests.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = Color.FromArgb(235, 240, 250);
            dataGridViewCellStyle11.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle11.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
            dgvRecentRequests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dgvRecentRequests.ColumnHeadersHeight = 29;
            dgvRecentRequests.EnableHeadersVisualStyles = false;
            dgvRecentRequests.Location = new Point(20, 440);
            dgvRecentRequests.Name = "dgvRecentRequests";
            dgvRecentRequests.ReadOnly = true;
            dgvRecentRequests.RowHeadersWidth = 51;
            dgvRecentRequests.RowTemplate.Height = 35;
            dgvRecentRequests.Size = new Size(929, 250);
            dgvRecentRequests.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(88, 46);
            label2.Name = "label2";
            label2.Size = new Size(33, 38);
            label2.TabIndex = 10;
            label2.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(76, 21);
            label3.Name = "label3";
            label3.Size = new Size(71, 20);
            label3.TabIndex = 9;
            label3.Text = "Students";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(88, 46);
            label4.Name = "label4";
            label4.Size = new Size(33, 38);
            label4.TabIndex = 11;
            label4.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(88, 46);
            label5.Name = "label5";
            label5.Size = new Size(33, 38);
            label5.TabIndex = 12;
            label5.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(101, 46);
            label6.Name = "label6";
            label6.Size = new Size(33, 38);
            label6.TabIndex = 13;
            label6.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(88, 46);
            label7.Name = "label7";
            label7.Size = new Size(33, 38);
            label7.TabIndex = 14;
            label7.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(101, 46);
            label8.Name = "label8";
            label8.Size = new Size(33, 38);
            label8.TabIndex = 11;
            label8.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(76, 21);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 10;
            label1.Text = "Courses";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ControlDarkDark;
            label9.Location = new Point(86, 21);
            label9.Name = "label9";
            label9.Size = new Size(67, 20);
            label9.TabIndex = 10;
            label9.Text = "Sections";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = SystemColors.ControlDarkDark;
            label10.Location = new Point(56, 23);
            label10.Name = "label10";
            label10.Size = new Size(134, 20);
            label10.TabIndex = 9;
            label10.Text = "Pending Requests";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = SystemColors.ControlDarkDark;
            label11.Location = new Point(76, 13);
            label11.Name = "label11";
            label11.Size = new Size(78, 20);
            label11.TabIndex = 9;
            label11.Text = "Approved";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = SystemColors.ControlDarkDark;
            label12.Location = new Point(84, 13);
            label12.Name = "label12";
            label12.Size = new Size(69, 20);
            label12.TabIndex = 10;
            label12.Text = "Rejected";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(18, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(52, 47);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(9, 33);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(61, 51);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(18, 38);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(52, 40);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 9;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(9, 39);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(51, 45);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 9;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(23, 39);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(47, 37);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 9;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(23, 32);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(47, 35);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 9;
            pictureBox6.TabStop = false;
            // 
            // AdminDashboardControl
            // 
            Controls.Add(panelHeader);
            Controls.Add(panelStudents);
            Controls.Add(panelCourses);
            Controls.Add(panelSections);
            Controls.Add(panelPending);
            Controls.Add(panelApproved);
            Controls.Add(panelRejected);
            Controls.Add(labelRecent);
            Controls.Add(dgvRecentRequests);
            Name = "AdminDashboardControl";
            Size = new Size(969, 740);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelStudents.ResumeLayout(false);
            panelStudents.PerformLayout();
            panelCourses.ResumeLayout(false);
            panelCourses.PerformLayout();
            panelSections.ResumeLayout(false);
            panelSections.PerformLayout();
            panelPending.ResumeLayout(false);
            panelPending.PerformLayout();
            panelApproved.ResumeLayout(false);
            panelApproved.PerformLayout();
            panelRejected.ResumeLayout(false);
            panelRejected.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecentRequests).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }



        private void CreateCard(
            Panel panel,
            Label title,
            Label count,
            string text,
            Point location)
        {

            panel.Location =
                location;


            panel.Size =
                new Size(280, 110);


            panel.BorderStyle =
                BorderStyle.FixedSingle;



            title.Text =
                text;


            title.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Regular);


            title.ForeColor =
                Color.FromArgb(50, 70, 100);


            title.Location =
                new Point(20, 18);


            title.AutoSize =
                true;




            count.Text =
                "0";


            count.Font =
                new Font(
                    "Segoe UI",
                    24,
                    FontStyle.Bold);


            count.ForeColor =
                Color.FromArgb(30, 50, 90);


            count.Location =
                new Point(20, 50);


            count.AutoSize =
                true;



            panel.Controls.Add(title);

            panel.Controls.Add(count);

        }


        #endregion



        private Panel panelHeader;


        private Label labelTitle;
        private Label labelSubtitle;


        private Panel panelStudents;
        private Panel panelCourses;
        private Panel panelSections;


        private Panel panelPending;
        private Panel panelApproved;
        private Panel panelRejected;



        private Label labelStudentsTitle;
        private Label labelCoursesTitle;
        private Label labelSectionsTitle;


        private Label labelPendingTitle;
        private Label labelApprovedTitle;
        private Label labelRejectedTitle;



        private Label lblStudentsCount;
        private Label lblCoursesCount;
        private Label lblSectionsCount;


        private Label lblPendingCount;
        private Label lblApprovedCount;
        private Label lblRejectedCount;



        private Label labelRecent;


        private DataGridView dgvRecentRequests;
        private Label label2;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label8;
        private Label label3;
        private Label label1;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
    }
}