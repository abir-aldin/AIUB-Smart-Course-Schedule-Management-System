using AIUBCourseScheduler.DataAccess;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIUBCourseScheduler.UserControls.Student
{
    public partial class SelectCoursesControl : Form
    {
        // Database থেকে আসা selectable courses এখানে রাখা হবে
        private readonly List<SelectableCourse> courses =
            new List<SelectableCourse>();

        // Checkbox programmatically পরিবর্তনের সময়
        // duplicate event আটকানোর জন্য
        private bool isUpdatingSelection;

        public SelectCoursesControl()
        {
            InitializeComponent();

            /*
             * Grid columns runtime-এ তৈরি করা হবে।
             * তাই Designer columns null হলেও সমস্যা হবে না।
             */
            ConfigureCourseGrid();
        }

        private void ConfigureCourseGrid()
        {
            dgvCourses.AutoGenerateColumns = false;

            // Designer-এর অসম্পূর্ণ columns থাকলে remove করবে
            dgvCourses.Columns.Clear();

            // Checkbox column
            DataGridViewCheckBoxColumn selectColumn =
                new DataGridViewCheckBoxColumn
                {
                    Name = "SelectColumn",
                    HeaderText = "",
                    DataPropertyName =
                        nameof(SelectableCourse.IsSelected),
                    Width = 45,
                    MinimumWidth = 45,
                    Resizable =
                        DataGridViewTriState.False
                };

            selectColumn.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            // Course Code column
            DataGridViewTextBoxColumn courseCodeColumn =
                new DataGridViewTextBoxColumn
                {
                    Name = "CourseCodeColumn",
                    HeaderText = "Course Code",
                    DataPropertyName =
                        nameof(SelectableCourse.CourseCode),
                    Width = 115,
                    MinimumWidth = 100,
                    ReadOnly = true,
                    SortMode =
                        DataGridViewColumnSortMode.NotSortable
                };

            courseCodeColumn.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            // Course Name column
            DataGridViewTextBoxColumn courseNameColumn =
                new DataGridViewTextBoxColumn
                {
                    Name = "CourseNameColumn",
                    HeaderText = "Course Name",
                    DataPropertyName =
                        nameof(SelectableCourse.CourseName),
                    Width = 235,
                    MinimumWidth = 180,
                    ReadOnly = true,
                    SortMode =
                        DataGridViewColumnSortMode.NotSortable
                };

            courseNameColumn.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            // Credits column
            DataGridViewTextBoxColumn creditsColumn =
                new DataGridViewTextBoxColumn
                {
                    Name = "CreditsColumn",
                    HeaderText = "Credits",
                    DataPropertyName =
                        nameof(SelectableCourse.Credits),
                    Width = 75,
                    MinimumWidth = 70,
                    ReadOnly = true,
                    SortMode =
                        DataGridViewColumnSortMode.NotSortable
                };

            creditsColumn.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            // Available Sections column
            DataGridViewTextBoxColumn availableSectionsColumn =
                new DataGridViewTextBoxColumn
                {
                    Name = "AvailableSectionsColumn",
                    HeaderText = "Available Sections",
                    DataPropertyName =
                        nameof(SelectableCourse.AvailableSections),
                    Width = 135,
                    MinimumWidth = 120,
                    ReadOnly = true,
                    SortMode =
                        DataGridViewColumnSortMode.NotSortable
                };

            availableSectionsColumn.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            // তৈরি করা columns grid-এ add করা হচ্ছে
            dgvCourses.Columns.AddRange(
                selectColumn,
                courseCodeColumn,
                courseNameColumn,
                creditsColumn,
                availableSectionsColumn
            );

            // Grid settings
            dgvCourses.AllowUserToAddRows = false;
            dgvCourses.AllowUserToDeleteRows = false;
            dgvCourses.AllowUserToResizeRows = false;
            dgvCourses.RowHeadersVisible = false;
            dgvCourses.MultiSelect = false;

            dgvCourses.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
        }

        private async Task LoadCoursesAsync()
        {
            courses.Clear();

            /*
             * শুধুমাত্র সেই active course দেখানো হবে:
             *
             * 1. Course active
             * 2. Section/Offering active
             * 3. Section-এ ৩টির বেশি seat available
             *
             * Available seat =
             * Capacity - EnrolledCount
             */
            const string query = @"
                SELECT
                    C.CourseId,
                    C.CourseCode,
                    C.CourseTitle,

                    CAST(
                        CASE
                            WHEN EXISTS
                            (
                                SELECT 1
                                FROM dbo.CourseOfferings AS COType
                                WHERE COType.CourseId = C.CourseId
                                  AND COType.IsActive = 1
                                  AND COType.OfferingType = 'Lab'
                            )
                            THEN 1.0
                            ELSE 3.0
                        END
                        AS FLOAT
                    ) AS Credits,

                    COUNT(CO.OfferingId) AS AvailableSections

                FROM dbo.Courses AS C

                INNER JOIN dbo.CourseOfferings AS CO
                    ON CO.CourseId = C.CourseId

                WHERE C.IsActive = 1
                  AND CO.IsActive = 1
                  AND
                  (
                      ISNULL(CO.Capacity, 0) -
                      ISNULL(CO.EnrolledCount, 0)
                  ) > 3

                GROUP BY
                    C.CourseId,
                    C.CourseCode,
                    C.CourseTitle

                ORDER BY
                    C.CourseTitle;";

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            await connection.OpenAsync();

            using SqlCommand command =
                new SqlCommand(query, connection);

            // Database response slow হলেও অপেক্ষা করবে
            command.CommandTimeout = 120;

            using SqlDataReader reader =
                await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                courses.Add(new SelectableCourse
                {
                    IsSelected = false,

                    CourseId = reader.GetInt32(0),

                    CourseCode = reader.IsDBNull(1)
                        ? "N/A"
                        : reader.GetString(1),

                    CourseName = reader.GetString(2),

                    Credits = reader.GetDouble(3),

                    AvailableSections = reader.GetInt32(4)
                });
            }
        }

        private void ShowCourses(
            IEnumerable<SelectableCourse> courseList)
        {
            List<SelectableCourse> displayedCourses =
                courseList.ToList();

            // পুরোনো data clear করা হচ্ছে
            dgvCourses.DataSource = null;

            // নির্ধারিত courses grid-এ দেখানো হচ্ছে
            dgvCourses.DataSource = displayedCourses;

            dgvCourses.ClearSelection();
        }

        private async void SelectCoursesControl_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                await LoadCoursesAsync();

                // সব available courses দেখানো হচ্ছে
                ShowCourses(courses);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Could not load available courses.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load courses.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void txtSearch_TextChanged(
            object sender,
            EventArgs e)
        {
            string searchText =
                txtSearch.Text.Trim();

            // Search box খালি হলে সব courses দেখাবে
            if (string.IsNullOrWhiteSpace(searchText))
            {
                ShowCourses(courses);
                return;
            }

            // Course code অথবা course name দিয়ে search করবে
            List<SelectableCourse> filteredCourses =
                courses.Where(course =>
                    course.CourseCode.Contains(
                        searchText,
                        StringComparison.OrdinalIgnoreCase
                    ) ||
                    course.CourseName.Contains(
                        searchText,
                        StringComparison.OrdinalIgnoreCase
                    )
                ).ToList();

            ShowCourses(filteredCourses);
        }

        private void dgvCourses_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            /*
 * Checkbox click করার সঙ্গে সঙ্গে value commit করবে।
 * অন্যথায় অন্য cell-এ click করার আগে event নাও চলতে পারে।
 */
            if (dgvCourses.IsCurrentCellDirty)
            {
                dgvCourses.CommitEdit(
                    DataGridViewDataErrorContexts.Commit
                );
            }
        }

        private void dgvCourses_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isUpdatingSelection ||
    e.RowIndex < 0 ||
    e.ColumnIndex < 0)
            {
                return;
            }

            // Checkbox column ছাড়া অন্য column হলে কিছু করবে না
            if (dgvCourses.Columns[e.ColumnIndex].Name !=
                "SelectColumn")
            {
                return;
            }

            DataGridViewRow selectedRow =
                dgvCourses.Rows[e.RowIndex];

            if (selectedRow.DataBoundItem
                is not SelectableCourse selectedCourse)
            {
                return;
            }

            bool isSelected = Convert.ToBoolean(
                selectedRow.Cells["SelectColumn"].Value
                ?? false
            );

            selectedCourse.IsSelected = isSelected;

            double totalCredits =
                courses
                    .Where(course => course.IsSelected)
                    .Sum(course => course.Credits);

            // সর্বোচ্চ 18 credits-এর বেশি select করা যাবে না
            if (isSelected && totalCredits > 18)
            {
                isUpdatingSelection = true;

                selectedCourse.IsSelected = false;

                selectedRow.Cells["SelectColumn"].Value =
                    false;

                isUpdatingSelection = false;

                UpdateSelectedCoursesSummary();

                MessageBox.Show(
                    "You cannot select more than 18 credits.",
                    "Credit Limit",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            UpdateSelectedCoursesSummary();
        }

        private void UpdateSelectedCoursesSummary()
        {
            List<SelectableCourse> selectedCourses =
                courses
                    .Where(course => course.IsSelected)
                    .ToList();

            double totalCredits =
                selectedCourses.Sum(
                    course => course.Credits
                );

            lblTotalCoursesValue.Text =
                selectedCourses.Count.ToString();

            lblTotalCreditsValue.Text =
                totalCredits.ToString("0.#");

            if (selectedCourses.Count == 0)
            {
                lblEmptyTitle.Text =
                    "No courses selected yet.";

                lblEmptyMessage.Text =
                    "Select courses from the list\r\n" +
                    "to build your schedule.";

            }
            else
            {
                lblEmptyTitle.Text =
                    $"{selectedCourses.Count} course(s) selected.";

                lblEmptyMessage.Text =
                    "You can select courses up to\r\n" +
                    "18 total credits.";

                btnContinue.Enabled = true;
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            List<SelectableCourse> selectedCourses =
        courses
            .Where(course => course.IsSelected)
            .ToList();

            if (selectedCourses.Count == 0)
            {
                MessageBox.Show(
                    "Please select at least one course.",
                    "No Course Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // Selected courses session-এ save হচ্ছে
            CourseSelectionSession.SaveSelectedCourses(
                selectedCourses
            );

            MessageBox.Show(
                $"{selectedCourses.Count} course(s) saved successfully.\n" +
                $"Total credits: " +
                $"{CourseSelectionSession.TotalCredits:0.#}\n\n",
                "Selection Saved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}