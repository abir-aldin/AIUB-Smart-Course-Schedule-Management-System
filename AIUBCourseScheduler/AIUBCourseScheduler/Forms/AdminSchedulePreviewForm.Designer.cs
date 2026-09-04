namespace AIUBCourseScheduler.Forms
{
    partial class AdminSchedulePreviewForm
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
            dataGridView1 = new DataGridView();
            buttonClose = new Button();

            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();

            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.Navy;
            label1.Location = new Point(25, 20);
            label1.Name = "label1";
            label1.Size = new Size(320, 37);
            label1.TabIndex = 0;
            label1.Text = "Weekly Schedule Preview";

            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(25, 80);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(950, 420);
            dataGridView1.TabIndex = 1;

            // 
            // buttonClose
            // 
            buttonClose.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            buttonClose.Location =
                new Point(425, 535);

            buttonClose.Name =
                "buttonClose";

            buttonClose.Size =
                new Size(150, 45);

            buttonClose.TabIndex = 2;

            buttonClose.Text =
                "Close";

            buttonClose.UseVisualStyleBackColor = true;

            buttonClose.Click += buttonClose_Click;


            // 
            // AdminSchedulePreviewForm
            // 
            AutoScaleDimensions =
                new SizeF(8F, 20F);

            AutoScaleMode =
                AutoScaleMode.Font;

            ClientSize =
                new Size(1000, 620);

            Controls.Add(buttonClose);
            Controls.Add(dataGridView1);
            Controls.Add(label1);

            Name =
                "AdminSchedulePreviewForm";

            Text =
                "Admin Schedule Preview";


            ((System.ComponentModel.ISupportInitialize)dataGridView1)
                .EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private Label label1;
        private DataGridView dataGridView1;
        private Button buttonClose;
    }
}