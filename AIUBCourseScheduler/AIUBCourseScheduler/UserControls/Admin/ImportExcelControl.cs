using AIUBCourseScheduler.Services;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIUBCourseScheduler.UserControls.Admin
{
    public partial class ImportExcelControl : Form
    {
        private string? selectedFilePath;
        private ExcelValidationResult? validationResult;

        public ImportExcelControl()
        {
            InitializeComponent();

            button1.Click += button1_Click;
            dataGridView1.CellContentClick +=
                dataGridView1_CellContentClick;

            label4.Text = "Supported format: .xlsx";

            ConfigureImportHistoryGrid();
            ClearSelectedFile();
        }

        private async void ImportExcelControl_Load(
            object sender,
            EventArgs e)
        {
            await LoadImportHistoryAsync();
        }

        private async void button1_Click(
            object? sender,
            EventArgs e)
        {
            using OpenFileDialog fileDialog =
                new OpenFileDialog();

            fileDialog.Title =
                "Select Offered Course Report";

            fileDialog.Filter =
                "Excel Workbook (*.xlsx)|*.xlsx";

            fileDialog.Multiselect = false;
            fileDialog.CheckFileExists = true;
            fileDialog.CheckPathExists = true;

            if (fileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            selectedFilePath = fileDialog.FileName;

            FileInfo selectedFile =
                new FileInfo(selectedFilePath);

            label6.Text = selectedFile.Name;

            label7.Text =
                "Type: Microsoft Excel worksheet";

            label8.Text =
                $"Selected: {DateTime.Now:MMM dd, yyyy hh:mm tt}";

            label8.Visible = true;

            button2.Text = "×";
            button2.Visible = true;

            await ValidateAndImportAsync();
        }

        private async Task ValidateAndImportAsync()
        {
            if (string.IsNullOrWhiteSpace(selectedFilePath))
            {
                return;
            }

            try
            {
                SetBusyState(true, "Validating...");

                validationResult = await Task.Run(() =>
                    ExcelImportService.Validate(selectedFilePath)
                );

                SetBusyState(false, "Import Data");

                DialogResult confirmation = MessageBox.Show(
                    $"Excel validation completed.\n\n" +
                    $"Semester: {validationResult.TermName}\n" +
                    $"Total rows: {validationResult.TotalRows}\n" +
                    $"Valid rows: {validationResult.ValidRows}\n" +
                    $"Skipped/invalid rows: " +
                    $"{validationResult.InvalidRows}\n\n" +
                    "Do you want to import the valid rows " +
                    "into the database?",
                    "Confirm Excel Import",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmation != DialogResult.Yes)
                {
                    return;
                }

                await ImportValidatedDataAsync();
            }
            catch (Exception ex)
            {
                validationResult = null;

                MessageBox.Show(
                    "Excel validation failed.\n\n" +
                    ex.Message,
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                SetBusyState(false, "Import Data");
            }
        }

        private async Task ImportValidatedDataAsync()
        {
            if (string.IsNullOrWhiteSpace(selectedFilePath) ||
                validationResult == null)
            {
                return;
            }

            try
            {
                SetBusyState(true, "Importing...");

                DatabaseImportResult importResult =
                    await ExcelDatabaseImportService.ImportAsync(
                        selectedFilePath,
                        validationResult
                    );

                MessageBox.Show(
                    $"Excel data imported successfully!\n\n" +
                    $"Import ID: {importResult.ImportId}\n" +
                    $"Unique courses: " +
                    $"{importResult.UniqueCourses}\n" +
                    $"Course offerings: " +
                    $"{importResult.CourseOfferings}\n" +
                    $"Class meetings: " +
                    $"{importResult.ClassMeetings}\n" +
                    $"Skipped rows: " +
                    $"{validationResult.InvalidRows}",
                    "Import Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ClearSelectedFile();

                await LoadImportHistoryAsync();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Import Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Database import failed.\n\n" +
                    ex.Message +
                    "\n\nNo partial data was saved.",
                    "Import Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                SetBusyState(false, "Import Data");
            }
        }

        private void ConfigureImportHistoryGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.MultiSelect = false;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            ImportID.DataPropertyName = "ImportId";
            FileName.DataPropertyName = "FileName";
            Semester.DataPropertyName = "TermName";
            ImportedBy.DataPropertyName = "UploadedBy";
            ImportedAt.DataPropertyName = "UploadedAt";
            ValidRows.DataPropertyName = "ValidRows";

            ImportedAt.DefaultCellStyle.Format =
                "MMM dd, yyyy hh:mm tt";

            ViewDetails.Text = "View Details";
            ViewDetails.UseColumnTextForButtonValue = true;
        }

        private async Task LoadImportHistoryAsync()
        {
            try
            {
                DataTable history =
                    await ExcelDatabaseImportService
                        .GetImportHistoryAsync();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = history;
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Import history could not be loaded.\n\n" +
                    ex.Message,
                    "History Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dataGridView1_CellContentClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.ColumnIndex != ViewDetails.Index)
            {
                return;
            }

            DataGridViewRow selectedRow =
                dataGridView1.Rows[e.RowIndex];

            string importId =
                Convert.ToString(
                    selectedRow.Cells[ImportID.Name].Value
                ) ?? string.Empty;

            string fileName =
                Convert.ToString(
                    selectedRow.Cells[FileName.Name].Value
                ) ?? string.Empty;

            string semester =
                Convert.ToString(
                    selectedRow.Cells[Semester.Name].Value
                ) ?? string.Empty;

            string importedBy =
                Convert.ToString(
                    selectedRow.Cells[ImportedBy.Name].Value
                ) ?? string.Empty;

            string importedAt =
                Convert.ToString(
                    selectedRow.Cells[ImportedAt.Name]
                        .FormattedValue
                ) ?? string.Empty;

            string validRows =
                Convert.ToString(
                    selectedRow.Cells[ValidRows.Name].Value
                ) ?? string.Empty;

            MessageBox.Show(
                $"Import ID: {importId}\n" +
                $"File: {fileName}\n" +
                $"Semester: {semester}\n" +
                $"Imported By: {importedBy}\n" +
                $"Imported At: {importedAt}\n" +
                $"Valid Rows: {validRows}",
                "Import Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void SetBusyState(
            bool isBusy,
            string buttonText)
        {
            Cursor = isBusy
                ? Cursors.WaitCursor
                : Cursors.Default;

            button1.Enabled = !isBusy;
            button2.Enabled = !isBusy;
            button1.Text = buttonText;
        }

        private void button2_Click(
            object sender,
            EventArgs e)
        {
            ClearSelectedFile();
        }

        private void ClearSelectedFile()
        {
            selectedFilePath = null;
            validationResult = null;

            label6.Text = "No file selected";

            label7.Text =
                "Type: Microsoft Excel worksheet";

            label8.Text = string.Empty;
            label8.Visible = false;

            button2.Text = "×";
            button2.Visible = false;
        }

        private void label4_Click(
            object sender,
            EventArgs e)
        {

        }

        private void panel3_Paint(
            object sender,
            PaintEventArgs e)
        {

        }

        private async void button3_Click( object sender,
                            EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select an import history row first.",
                    "No Import Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DataGridViewRow selectedRow =
                dataGridView1.SelectedRows[0];

            object? importIdValue =
                selectedRow.Cells[ImportID.Name].Value;

            if (importIdValue == null ||
                !int.TryParse(
                    importIdValue.ToString(),
                    out int importId))
            {
                MessageBox.Show(
                    "The selected Import ID is not valid.",
                    "Invalid Import",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            string fileName =
                Convert.ToString(
                    selectedRow.Cells[FileName.Name].Value
                ) ?? string.Empty;

            string semester =
                Convert.ToString(
                    selectedRow.Cells[Semester.Name].Value
                ) ?? string.Empty;

            DialogResult confirmation = MessageBox.Show(
                $"Are you sure you want to delete this import?\n\n" +
                $"Import ID: {importId}\n" +
                $"File: {fileName}\n" +
                $"Semester: {semester}\n\n" +
                "This will also delete its course offerings, " +
                "class meetings and unused courses from the database.",
                "Confirm Import Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmation != DialogResult.Yes)
            {
                return;
            }

            try
            {
                button3.Enabled = false;
                dataGridView1.Enabled = false;
                Cursor = Cursors.WaitCursor;

                await ExcelDatabaseImportService
                    .DeleteImportAsync(importId);

                await LoadImportHistoryAsync();

                MessageBox.Show(
                    "Import history and its related database data " +
                    "were deleted successfully.",
                    "Delete Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Delete Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "The import could not be deleted.\n\n" +
                    ex.Message +
                    "\n\nNo partial data was deleted.",
                    "Delete Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                Cursor = Cursors.Default;
                dataGridView1.Enabled = true;
                button3.Enabled = true;
            }
        }
    }
}