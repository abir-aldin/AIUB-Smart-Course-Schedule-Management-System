namespace AIUBCourseScheduler.UserControls.Admin
{
    partial class ImportExcelControl
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
            panel1 = new Panel();
            label4 = new Label();
            label3 = new Label();
            button1 = new Button();
            panel2 = new Panel();
            label8 = new Label();
            button2 = new Button();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            panel3 = new Panel();
            dataGridView1 = new DataGridView();
            ImportID = new DataGridViewTextBoxColumn();
            FileName = new DataGridViewTextBoxColumn();
            Semester = new DataGridViewTextBoxColumn();
            ImportedBy = new DataGridViewTextBoxColumn();
            ImportedAt = new DataGridViewTextBoxColumn();
            ValidRows = new DataGridViewTextBoxColumn();
            ViewDetails = new DataGridViewButtonColumn();
            label9 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
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
            label1.Size = new Size(150, 31);
            label1.TabIndex = 0;
            label1.Text = "Import Excel";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ButtonShadow;
            label2.Location = new Point(12, 40);
            label2.Name = "label2";
            label2.Size = new Size(603, 20);
            label2.TabIndex = 1;
            label2.Text = "Upload your excel file to import course offerings and validates the data before importing.";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(60, 114);
            panel1.Name = "panel1";
            panel1.Size = new Size(403, 166);
            panel1.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlDark;
            label4.Location = new Point(126, 73);
            label4.Name = "label4";
            label4.Size = new Size(142, 17);
            label4.TabIndex = 3;
            label4.Text = "Supported format:_xisx";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label3.Location = new Point(64, 53);
            label3.Name = "label3";
            label3.Size = new Size(249, 20);
            label3.TabIndex = 3;
            label3.Text = "Drop excel file here or click browse";
            // 
            // button1
            // 
            button1.BackColor = Color.DodgerBlue;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(114, 108);
            button1.Name = "button1";
            button1.Size = new Size(170, 55);
            button1.TabIndex = 3;
            button1.Text = "Import Data";
            button1.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLightLight;
            panel2.Controls.Add(label8);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(543, 114);
            panel2.Name = "panel2";
            panel2.Size = new Size(366, 166);
            panel2.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 7F);
            label8.Location = new Point(90, 88);
            label8.Name = "label8";
            label8.Size = new Size(187, 15);
            label8.TabIndex = 4;
            label8.Text = "Uploaded : May 17, 2025 10:35 AM";
            label8.Visible = false;
            // 
            // button2
            // 
            button2.BackgroundImageLayout = ImageLayout.Zoom;
            button2.Location = new Point(299, 45);
            button2.Name = "button2";
            button2.Size = new Size(54, 51);
            button2.TabIndex = 5;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(90, 62);
            label7.Name = "label7";
            label7.Size = new Size(194, 17);
            label7.TabIndex = 4;
            label7.Text = "Type: Microsoft Excel worksheet";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label6.Location = new Point(90, 39);
            label6.Name = "label6";
            label6.Size = new Size(156, 23);
            label6.TabIndex = 4;
            label6.Text = "Upload a excel file ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label5.Location = new Point(18, 7);
            label5.Name = "label5";
            label5.Size = new Size(119, 25);
            label5.TabIndex = 4;
            label5.Text = "Selected File";
            // 
            // panel3
            // 
            panel3.AccessibleName = "pnlImportHistory";
            panel3.BackColor = SystemColors.ControlLightLight;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(dataGridView1);
            panel3.Controls.Add(label9);
            panel3.Location = new Point(26, 352);
            panel3.Name = "panel3";
            panel3.Size = new Size(925, 304);
            panel3.TabIndex = 4;
            panel3.Paint += panel3_Paint;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ImportID, FileName, Semester, ImportedBy, ImportedAt, ValidRows, ViewDetails });
            dataGridView1.Location = new Point(-3, 66);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(941, 172);
            dataGridView1.TabIndex = 1;
            // 
            // ImportID
            // 
            ImportID.HeaderText = "Import ID";
            ImportID.MinimumWidth = 6;
            ImportID.Name = "ImportID";
            ImportID.Width = 125;
            // 
            // FileName
            // 
            FileName.HeaderText = "File Name";
            FileName.MinimumWidth = 6;
            FileName.Name = "FileName";
            FileName.Width = 125;
            // 
            // Semester
            // 
            Semester.HeaderText = "Semester";
            Semester.MinimumWidth = 6;
            Semester.Name = "Semester";
            Semester.Width = 125;
            // 
            // ImportedBy
            // 
            ImportedBy.HeaderText = "Imported By";
            ImportedBy.MinimumWidth = 6;
            ImportedBy.Name = "ImportedBy";
            ImportedBy.Width = 125;
            // 
            // ImportedAt
            // 
            ImportedAt.HeaderText = "Imported At";
            ImportedAt.MinimumWidth = 6;
            ImportedAt.Name = "ImportedAt";
            ImportedAt.Width = 125;
            // 
            // ValidRows
            // 
            ValidRows.HeaderText = "Valid Rows";
            ValidRows.MinimumWidth = 6;
            ValidRows.Name = "ValidRows";
            ValidRows.Width = 125;
            // 
            // ViewDetails
            // 
            ViewDetails.HeaderText = "Action";
            ViewDetails.MinimumWidth = 6;
            ViewDetails.Name = "ViewDetails";
            ViewDetails.Text = "View Details";
            ViewDetails.UseColumnTextForButtonValue = true;
            ViewDetails.Width = 125;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(10, 12);
            label9.Name = "label9";
            label9.Size = new Size(139, 25);
            label9.TabIndex = 0;
            label9.Text = "Import History";
            // 
            // ImportExcelControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(963, 737);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ImportExcelControl";
            Text = "ImportExcelControl";
            Load += ImportExcelControl_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Panel panel1;
        private Label label3;
        private Label label4;
        private Button button1;
        private Panel panel2;
        private Label label5;
        private Label label8;
        private Label label7;
        private Label label6;
        private Button button2;
        private Panel panel3;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ImportID;
        private DataGridViewTextBoxColumn FileName;
        private DataGridViewTextBoxColumn Semester;
        private DataGridViewTextBoxColumn ImportedBy;
        private DataGridViewTextBoxColumn ImportedAt;
        private DataGridViewTextBoxColumn ValidRows;
        private DataGridViewButtonColumn ViewDetails;
        private Label label9;
    }
}