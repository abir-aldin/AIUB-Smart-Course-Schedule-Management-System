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
            this.components = new System.ComponentModel.Container();


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



            // Header Panel

            panelHeader.Location =
                new Point(20, 20);

            panelHeader.Size =
                new Size(929, 90);

            panelHeader.BackColor =
                Color.White;

            panelHeader.BorderStyle =
                BorderStyle.FixedSingle;



            labelTitle.Text =
                "Admin Dashboard";


            labelTitle.Font =
                new Font(
                    "Segoe UI",
                    18,
                    FontStyle.Bold);


            labelTitle.ForeColor =
                Color.FromArgb(25, 45, 80);


            labelTitle.Location =
                new Point(20, 15);


            labelTitle.AutoSize = true;



            labelSubtitle.Text =
                "Overview of your course scheduler system";


            labelSubtitle.Font =
                new Font(
                    "Segoe UI",
                    10);


            labelSubtitle.ForeColor =
                Color.Gray;


            labelSubtitle.Location =
                new Point(22, 55);


            labelSubtitle.AutoSize = true;



            panelHeader.Controls.Add(labelTitle);
            panelHeader.Controls.Add(labelSubtitle);

            // Cards

            CreateCard(
                panelStudents,
                labelStudentsTitle,
                lblStudentsCount,
                "Students",
                new Point(20, 130)
            );


            CreateCard(
                panelCourses,
                labelCoursesTitle,
                lblCoursesCount,
                "Courses",
                new Point(335, 130)
            );


            CreateCard(
                panelSections,
                labelSectionsTitle,
                lblSectionsCount,
                "Sections",
                new Point(650, 130)
            );


            CreateCard(
                panelPending,
                labelPendingTitle,
                lblPendingCount,
                "Pending Requests",
                new Point(20, 260)
            );


            CreateCard(
                panelApproved,
                labelApprovedTitle,
                lblApprovedCount,
                "Approved",
                new Point(335, 260)
            );


            CreateCard(
                panelRejected,
                labelRejectedTitle,
                lblRejectedCount,
                "Rejected",
                new Point(650, 260)
            );



            // Card Colors

            panelStudents.BackColor =
                Color.FromArgb(235, 245, 255);


            panelCourses.BackColor =
                Color.FromArgb(235, 255, 245);


            panelSections.BackColor =
                Color.FromArgb(245, 235, 255);


            panelPending.BackColor =
                Color.FromArgb(255, 248, 220);


            panelApproved.BackColor =
                Color.FromArgb(225, 250, 235);


            panelRejected.BackColor =
                Color.FromArgb(255, 235, 235);





            // Recent Requests Title

            labelRecent.Text =
                "Recent Schedule Requests";


            labelRecent.Font =
                new Font(
                    "Segoe UI",
                    12,
                    FontStyle.Bold);


            labelRecent.ForeColor =
                Color.FromArgb(25, 45, 80);


            labelRecent.Location =
                new Point(20, 400);


            labelRecent.AutoSize = true;




            // DataGridView

            dgvRecentRequests.Location =
                new Point(20, 440);


            dgvRecentRequests.Size =
                new Size(929, 250);


            dgvRecentRequests.ReadOnly = true;


            dgvRecentRequests.AllowUserToAddRows =
                false;


            dgvRecentRequests.AllowUserToDeleteRows =
                false;


            dgvRecentRequests.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;


            dgvRecentRequests.BackgroundColor =
                Color.White;


            dgvRecentRequests.BorderStyle =
                BorderStyle.None;


            dgvRecentRequests.RowTemplate.Height =
                35;


            dgvRecentRequests.EnableHeadersVisualStyles =
                false;


            dgvRecentRequests.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(235, 240, 250);


            dgvRecentRequests.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold);




            // Add Controls

            this.Controls.Add(panelHeader);


            this.Controls.Add(panelStudents);
            this.Controls.Add(panelCourses);
            this.Controls.Add(panelSections);


            this.Controls.Add(panelPending);
            this.Controls.Add(panelApproved);
            this.Controls.Add(panelRejected);


            this.Controls.Add(labelRecent);

            this.Controls.Add(dgvRecentRequests);



            this.Name =
                "AdminDashboardControl";


            this.Size =
                new Size(969, 740);



            this.ResumeLayout(false);

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

    }
}