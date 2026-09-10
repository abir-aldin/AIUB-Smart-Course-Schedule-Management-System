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

            foreach (DataGridViewRow row in dgvCourses.Rows)
            {
                if (row.DataBoundItem is Course course)
                {
                    row.Tag = course.CourseId;
                }
            }

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

        private async void dgvCourses_CellContentClick(
    object sender,
    DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


            string columnName =
                dgvCourses.Columns[e.ColumnIndex].Name;



            int courseId =
                Convert.ToInt32(
                    dgvCourses.Rows[e.RowIndex].Tag
                );



            if (columnName == "EditColumn")
            {

                using CourseEditorForm form =
                    new CourseEditorForm(courseId);


                if (form.ShowDialog() == DialogResult.OK)
                {
                    await ReloadCoursesAsync();
                }

            }


            else if (columnName == "DeleteColumn")
            {

                DialogResult result =
                    MessageBox.Show(
                        "Are you sure you want to delete this course?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );


                if (result == DialogResult.Yes)
                {
                    DeleteCourse(courseId);

                    await ReloadCoursesAsync();
                }

            }
        }

        private void DeleteCourse(int courseId)
        {
            using SqlConnection connection =
                DatabaseConnection.GetConnection();


            connection.Open();


            string query = @"
        DELETE FROM Courses
        WHERE CourseId=@CourseId
    ";


            using SqlCommand command =
                new SqlCommand(query, connection);


            command.Parameters.AddWithValue(
                "@CourseId",
                courseId
            );


            command.ExecuteNonQuery();


            MessageBox.Show(
                "Course deleted successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
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

        private void button1_Click(object sender, EventArgs e)
        {
            using CourseEditorForm form =
    new CourseEditorForm();


            DialogResult result =
                form.ShowDialog();


            if (result == DialogResult.OK)
            {
                // Save হওয়ার পরে grid refresh

                _ = ReloadCoursesAsync();
            }
        }

        private async Task ReloadCoursesAsync()
        {
            try
            {
                await LoadCoursesAsync();

                ShowCourses(courses);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Could not reload courses.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}