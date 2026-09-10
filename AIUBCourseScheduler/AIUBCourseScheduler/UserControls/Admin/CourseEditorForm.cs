using AIUBCourseScheduler.DataAccess;
using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace AIUBCourseScheduler.UserControls.Admin
{
    public partial class CourseEditorForm : Form
    {

        private int? courseId = null;
        public CourseEditorForm()
        {
            InitializeComponent();
        }


        public CourseEditorForm(int id)
        {
            InitializeComponent();

            courseId = id;

            LoadCourseData();
        }

        private void LoadCourseData()
        {
            using SqlConnection connection =
                DatabaseConnection.GetConnection();


            connection.Open();


            string query = @"
        SELECT 
            CourseCode,
            CourseTitle,
            Department,
            IsActive
        FROM Courses
        WHERE CourseId=@Id
    ";


            using SqlCommand command =
                new SqlCommand(query, connection);


            command.Parameters.AddWithValue(
                "@Id",
                courseId
            );


            using SqlDataReader reader =
                command.ExecuteReader();


            if (reader.Read())
            {
                textBox1.Text =
                    reader.IsDBNull(0)
                    ? ""
                    : reader.GetString(0);


                textBox2.Text =
                    reader.GetString(1);


                textBox3.Text =
                    reader.GetString(2);


                comboBox1.SelectedItem =
                    reader.GetBoolean(3)
                    ? "Active"
                    : "Inactive";
            }
        }



        private void btnSaveCourse_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            bool isValid = true;


            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider1.SetError(
                    textBox2,
                    "Course Name is required."
                );

                isValid = false;
            }


            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                errorProvider1.SetError(
                    textBox3,
                    "Department is required."
                );

                isValid = false;
            }


            if (comboBox1.SelectedIndex == -1)
            {
                errorProvider1.SetError(
                    comboBox1,
                    "Status is required."
                );

                isValid = false;
            }


            if (!isValid)
            {
                MessageBox.Show(
                    "Please fill in all required fields.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }



            try
            {
                using SqlConnection connection =
                    DatabaseConnection.GetConnection();


                connection.Open();



                string query;



                if (courseId == null)
                {
                    // ADD NEW COURSE

                    query = @"
                INSERT INTO Courses
                (
                    CourseCode,
                    CourseTitle,
                    Department,
                    IsActive
                )

                VALUES
                (
                    @CourseCode,
                    @CourseTitle,
                    @Department,
                    @IsActive
                )";
                }
                else
                {
                    // UPDATE EXISTING COURSE

                    query = @"
                UPDATE Courses

                SET
                    CourseCode = @CourseCode,
                    CourseTitle = @CourseTitle,
                    Department = @Department,
                    IsActive = @IsActive

                WHERE CourseId = @CourseId";
                }



                using SqlCommand command =
                    new SqlCommand(
                        query,
                        connection);



                command.Parameters.AddWithValue(
                    "@CourseCode",
                    string.IsNullOrWhiteSpace(textBox1.Text)
                    ? DBNull.Value
                    : textBox1.Text.Trim()
                );


                command.Parameters.AddWithValue(
                    "@CourseTitle",
                    textBox2.Text.Trim()
                );


                command.Parameters.AddWithValue(
                    "@Department",
                    textBox3.Text.Trim()
                );


                command.Parameters.AddWithValue(
                    "@IsActive",
                    comboBox1.Text == "Active"
                );



                if (courseId != null)
                {
                    command.Parameters.AddWithValue(
                        "@CourseId",
                        courseId.Value
                    );
                }



                int result =
                    command.ExecuteNonQuery();



                if (result > 0)
                {
                    MessageBox.Show(
                        courseId == null
                        ? "Course added successfully!"
                        : "Course updated successfully!",

                        "Success",

                        MessageBoxButtons.OK,

                        MessageBoxIcon.Information
                    );


                    DialogResult =
                        DialogResult.OK;


                    Close();
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database error:\n\n" +
                    ex.Message,

                    "Error",

                    MessageBoxButtons.OK,

                    MessageBoxIcon.Error
                );
            }
        }









        private void panel1_Paint(
            object sender,
            PaintEventArgs e)
        {

        }


        private void label4_Click(
            object sender,
            EventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult =
    DialogResult.Cancel;

            Close();
        }
    }
}