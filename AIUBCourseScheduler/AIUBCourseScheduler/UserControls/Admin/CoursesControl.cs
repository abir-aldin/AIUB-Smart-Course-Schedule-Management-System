using AIUBCourseScheduler.DataAccess;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace AIUBCourseScheduler.UserControls.Admin
{
    public partial class CoursesControl : Form
    {
        private readonly List<Course> courses =
            new List<Course>();

        public CoursesControl()
        {
            InitializeComponent();

            // Designer-এর নির্ধারিত columns-ই ব্যবহার হবে
            dgvCourses.AutoGenerateColumns = false;
        }



        private async Task LoadCoursesAsync()
        {
            courses.Clear();

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
                                FROM dbo.CourseOfferings AS CO
                                WHERE CO.CourseId = C.CourseId
                                  AND CO.OfferingType = 'Lab'
                            )
                            THEN 1.0
                            ELSE 3.0
                        END
                        AS FLOAT
                    ) AS Credits,
                    C.Department,
                    C.IsActive
                FROM dbo.Courses AS C
                ORDER BY C.CourseTitle;";

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            await connection.OpenAsync();

            using SqlCommand command =
                new SqlCommand(query, connection);

            using SqlDataReader reader =
                await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                courses.Add(new Course
                {
                    CourseId = reader.GetInt32(0),

                    CourseCode = reader.IsDBNull(1)
                        ? "N/A"
                        : reader.GetString(1),

                    CourseName = reader.GetString(2),

                    Credits = reader.GetDouble(3),

                    Department = reader.IsDBNull(4)
                        ? "N/A"
                        : reader.GetString(4),

                    Status = reader.GetBoolean(5)
                        ? "Active"
                        : "Inactive"
                });
            }
        }

        private void ShowCourses(IEnumerable<Course> courseList)
        {
            List<Course> displayedCourses =
                courseList.ToList();

            dgvCourses.DataSource = null;
            dgvCourses.DataSource = displayedCourses;

            label3.Text =
                $"Showing {displayedCourses.Count} courses";

            dgvCourses.ClearSelection();
        }

        private async void CoursesControl_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                await LoadCoursesAsync();
                ShowCourses(courses);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Could not load courses.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dgvCourses_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.ColumnIndex < 0)
            {
                return;
            }

            string columnName =
                dgvCourses.Columns[e.ColumnIndex].Name;

            if (columnName == "EditColumn")
            {
                MessageBox.Show(
                    "Edit function will be added next."
                );
            }
            else if (columnName == "DeleteColumn")
            {
                MessageBox.Show(
                    "Delete function will be added next."
                );
            }
        }

        private void textBox1_TextChanged(
    object sender,
    EventArgs e)
        {
            string searchText = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                ShowCourses(courses);
                return;
            }

            List<Course> filteredCourses =
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

        private void button2_Click(
            object sender,
            EventArgs e)
        {
            textBox1.Clear();
            textBox1.Focus();
        }
    }
}