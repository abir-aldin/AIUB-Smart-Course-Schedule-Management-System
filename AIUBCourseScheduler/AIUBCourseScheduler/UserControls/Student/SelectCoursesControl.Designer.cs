using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AIUBCourseScheduler.UserControls.Student
{
    partial class SelectCoursesControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// true if managed resources should be disposed;
        /// otherwise, false.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(SelectCoursesControl));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lblTitle = new Label();
            panelMain = new Panel();
            btnContinue = new Button();
            panelSummary = new Panel();
            lblMaxCreditsValue = new Label();
            lblMaxCreditsTitle = new Label();
            lblTotalCreditsValue = new Label();
            lblTotalCreditsTitle = new Label();
            lblTotalCoursesValue = new Label();
            lblTotalCoursesTitle = new Label();
            lblSeparator = new Label();
            lblEmptyMessage = new Label();
            lblEmptyTitle = new Label();
            pictureBoxSummary = new PictureBox();
            lblSummaryTitle = new Label();
            dgvCourses = new DataGridView();
            txtSearch = new TextBox();
            panelMain.SuspendLayout();
            panelSummary.SuspendLayout();
            ((ISupportInitialize)pictureBoxSummary).BeginInit();
            ((ISupportInitialize)dgvCourses).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(10, 45, 95);
            lblTitle.Location = new Point(28, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(271, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Select Courses";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.BorderStyle = BorderStyle.FixedSingle;
            panelMain.Controls.Add(btnContinue);
            panelMain.Controls.Add(panelSummary);
            panelMain.Controls.Add(dgvCourses);
            panelMain.Controls.Add(txtSearch);
            panelMain.Location = new Point(20, 80);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(941, 680);
            panelMain.TabIndex = 1;
            // 
            // btnContinue
            // 
            btnContinue.BackColor = Color.FromArgb(0, 104, 220);
            btnContinue.Cursor = Cursors.Hand;
            btnContinue.FlatAppearance.BorderSize = 0;
            btnContinue.FlatStyle = FlatStyle.Flat;
            btnContinue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnContinue.ForeColor = Color.White;
            btnContinue.Location = new Point(658, 622);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(265, 45);
            btnContinue.TabIndex = 3;
            btnContinue.Text = "Save selected courses";
            btnContinue.UseVisualStyleBackColor = false;
            btnContinue.Click += btnContinue_Click;
            // 
            // panelSummary
            // 
            panelSummary.BackColor = Color.White;
            panelSummary.BorderStyle = BorderStyle.FixedSingle;
            panelSummary.Controls.Add(lblMaxCreditsValue);
            panelSummary.Controls.Add(lblMaxCreditsTitle);
            panelSummary.Controls.Add(lblTotalCreditsValue);
            panelSummary.Controls.Add(lblTotalCreditsTitle);
            panelSummary.Controls.Add(lblTotalCoursesValue);
            panelSummary.Controls.Add(lblTotalCoursesTitle);
            panelSummary.Controls.Add(lblSeparator);
            panelSummary.Controls.Add(lblEmptyMessage);
            panelSummary.Controls.Add(lblEmptyTitle);
            panelSummary.Controls.Add(pictureBoxSummary);
            panelSummary.Controls.Add(lblSummaryTitle);
            panelSummary.Location = new Point(658, 73);
            panelSummary.Name = "panelSummary";
            panelSummary.Size = new Size(265, 535);
            panelSummary.TabIndex = 2;
            // 
            // lblMaxCreditsValue
            // 
            lblMaxCreditsValue.Font = new Font("Segoe UI", 9.5F);
            lblMaxCreditsValue.Location = new Point(200, 416);
            lblMaxCreditsValue.Name = "lblMaxCreditsValue";
            lblMaxCreditsValue.Size = new Size(40, 22);
            lblMaxCreditsValue.TabIndex = 10;
            lblMaxCreditsValue.Text = "18";
            lblMaxCreditsValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblMaxCreditsTitle
            // 
            lblMaxCreditsTitle.AutoSize = true;
            lblMaxCreditsTitle.Font = new Font("Segoe UI", 9.5F);
            lblMaxCreditsTitle.Location = new Point(18, 416);
            lblMaxCreditsTitle.Name = "lblMaxCreditsTitle";
            lblMaxCreditsTitle.Size = new Size(164, 21);
            lblMaxCreditsTitle.TabIndex = 9;
            lblMaxCreditsTitle.Text = "Max Allowable Credits";
            // 
            // lblTotalCreditsValue
            // 
            lblTotalCreditsValue.Font = new Font("Segoe UI", 9.5F);
            lblTotalCreditsValue.Location = new Point(205, 368);
            lblTotalCreditsValue.Name = "lblTotalCreditsValue";
            lblTotalCreditsValue.Size = new Size(35, 22);
            lblTotalCreditsValue.TabIndex = 8;
            lblTotalCreditsValue.Text = "0";
            lblTotalCreditsValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalCreditsTitle
            // 
            lblTotalCreditsTitle.AutoSize = true;
            lblTotalCreditsTitle.Font = new Font("Segoe UI", 9.5F);
            lblTotalCreditsTitle.Location = new Point(18, 368);
            lblTotalCreditsTitle.Name = "lblTotalCreditsTitle";
            lblTotalCreditsTitle.Size = new Size(95, 21);
            lblTotalCreditsTitle.TabIndex = 7;
            lblTotalCreditsTitle.Text = "Total Credits";
            // 
            // lblTotalCoursesValue
            // 
            lblTotalCoursesValue.Font = new Font("Segoe UI", 9.5F);
            lblTotalCoursesValue.Location = new Point(205, 320);
            lblTotalCoursesValue.Name = "lblTotalCoursesValue";
            lblTotalCoursesValue.Size = new Size(35, 22);
            lblTotalCoursesValue.TabIndex = 6;
            lblTotalCoursesValue.Text = "0";
            lblTotalCoursesValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalCoursesTitle
            // 
            lblTotalCoursesTitle.AutoSize = true;
            lblTotalCoursesTitle.Font = new Font("Segoe UI", 9.5F);
            lblTotalCoursesTitle.Location = new Point(18, 320);
            lblTotalCoursesTitle.Name = "lblTotalCoursesTitle";
            lblTotalCoursesTitle.Size = new Size(102, 21);
            lblTotalCoursesTitle.TabIndex = 5;
            lblTotalCoursesTitle.Text = "Total Courses";
            // 
            // lblSeparator
            // 
            lblSeparator.BackColor = Color.FromArgb(220, 225, 232);
            lblSeparator.Location = new Point(17, 285);
            lblSeparator.Name = "lblSeparator";
            lblSeparator.Size = new Size(229, 1);
            lblSeparator.TabIndex = 4;
            // 
            // lblEmptyMessage
            // 
            lblEmptyMessage.Font = new Font("Segoe UI", 9F);
            lblEmptyMessage.ForeColor = Color.FromArgb(100, 108, 120);
            lblEmptyMessage.Location = new Point(18, 210);
            lblEmptyMessage.Name = "lblEmptyMessage";
            lblEmptyMessage.Size = new Size(227, 52);
            lblEmptyMessage.TabIndex = 3;
            lblEmptyMessage.Text = "Select courses from the list\r\nto build your schedule.";
            lblEmptyMessage.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblEmptyTitle
            // 
            lblEmptyTitle.Font = new Font("Segoe UI", 9.5F);
            lblEmptyTitle.ForeColor = Color.FromArgb(45, 55, 70);
            lblEmptyTitle.Location = new Point(15, 179);
            lblEmptyTitle.Name = "lblEmptyTitle";
            lblEmptyTitle.Size = new Size(235, 28);
            lblEmptyTitle.TabIndex = 2;
            lblEmptyTitle.Text = "No courses selected yet.";
            lblEmptyTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBoxSummary
            // 
            pictureBoxSummary.BackColor = Color.FromArgb(236, 246, 255);
            pictureBoxSummary.Image = (Image)resources.GetObject("pictureBoxSummary.Image");
            pictureBoxSummary.Location = new Point(80, 62);
            pictureBoxSummary.Name = "pictureBoxSummary";
            pictureBoxSummary.Size = new Size(105, 105);
            pictureBoxSummary.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxSummary.TabIndex = 1;
            pictureBoxSummary.TabStop = false;
            // 
            // lblSummaryTitle
            // 
            lblSummaryTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSummaryTitle.ForeColor = Color.FromArgb(10, 45, 95);
            lblSummaryTitle.Location = new Point(12, 18);
            lblSummaryTitle.Name = "lblSummaryTitle";
            lblSummaryTitle.Size = new Size(239, 32);
            lblSummaryTitle.TabIndex = 0;
            lblSummaryTitle.Text = "Selected Courses";
            lblSummaryTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvCourses
            // 
            dgvCourses.AllowUserToAddRows = false;
            dgvCourses.AllowUserToDeleteRows = false;
            dgvCourses.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 253);
            dgvCourses.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvCourses.BackgroundColor = Color.White;
            dgvCourses.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(235, 241, 250);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(20, 45, 85);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(235, 241, 250);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(20, 45, 85);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCourses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCourses.ColumnHeadersHeight = 45;
            dgvCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(35, 45, 60);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(215, 232, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(20, 45, 85);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvCourses.DefaultCellStyle = dataGridViewCellStyle3;
            dgvCourses.EnableHeadersVisualStyles = false;
            dgvCourses.GridColor = Color.FromArgb(220, 225, 232);
            dgvCourses.Location = new Point(18, 73);
            dgvCourses.MultiSelect = false;
            dgvCourses.Name = "dgvCourses";
            dgvCourses.RowHeadersVisible = false;
            dgvCourses.RowHeadersWidth = 51;
            dgvCourses.RowTemplate.Height = 38;
            dgvCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCourses.Size = new Size(625, 535);
            dgvCourses.TabIndex = 1;
            dgvCourses.CellValueChanged += dgvCourses_CellValueChanged;
            dgvCourses.CurrentCellDirtyStateChanged += dgvCourses_CurrentCellDirtyStateChanged;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.Location = new Point(18, 18);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by course code or name";
            txtSearch.Size = new Size(905, 32);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // SelectCoursesControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 251);
            ClientSize = new Size(981, 784);
            Controls.Add(panelMain);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SelectCoursesControl";
            Text = "Select Courses";
            Load += SelectCoursesControl_Load;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            panelSummary.ResumeLayout(false);
            panelSummary.PerformLayout();
            ((ISupportInitialize)pictureBoxSummary).EndInit();
            ((ISupportInitialize)dgvCourses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Panel panelMain;
        private TextBox txtSearch;
        private DataGridView dgvCourses;

        private DataGridViewCheckBoxColumn SelectColumn;
        private DataGridViewTextBoxColumn CourseCodeColumn;
        private DataGridViewTextBoxColumn CourseNameColumn;
        private DataGridViewTextBoxColumn CreditsColumn;
        private DataGridViewTextBoxColumn AvailableSectionsColumn;

        private Panel panelSummary;
        private Label lblSummaryTitle;
        private PictureBox pictureBoxSummary;
        private Label lblEmptyTitle;
        private Label lblEmptyMessage;
        private Label lblSeparator;
        private Label lblTotalCoursesTitle;
        private Label lblTotalCoursesValue;
        private Label lblTotalCreditsTitle;
        private Label lblTotalCreditsValue;
        private Label lblMaxCreditsTitle;
        private Label lblMaxCreditsValue;
        private Button btnContinue;
    }
}