using AIUBCourseScheduler.DataAccess;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace AIUBCourseScheduler.Forms
{
    public partial class SectionEditorForm : Form
    {
        public SectionEditorForm()
        {
            InitializeComponent();
        }

        private void SectionEditorForm_Load(
            object sender,
            EventArgs e)
        {
            LoadCourses();
            LoadTerms();

            comboBox3.Items.Clear();
            comboBox3.Items.Add("Theory");
            comboBox3.Items.Add("Lab");

            comboBox4.Items.Clear();
            comboBox4.Items.Add("Open");
            comboBox4.Items.Add("Closed");

            checkBox1.Checked = true;
        }

        private void LoadCourses()
        {
            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            string query = @"
                SELECT
                    CourseId,
                    CourseTitle
                FROM dbo.Courses
                WHERE IsActive = 1
                ORDER BY CourseTitle;
            ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            DataTable table =
                new DataTable();

            table.Load(
                command.ExecuteReader()
            );

            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "CourseTitle";
            comboBox1.ValueMember = "CourseId";
        }

        private void LoadTerms()
        {
            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            string query = @"
                SELECT
                    TermId,
                    TermName
                FROM dbo.AcademicTerms
                WHERE IsActive = 1
                ORDER BY TermId DESC;
            ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            DataTable table =
                new DataTable();

            table.Load(
                command.ExecuteReader()
            );

            comboBox2.DataSource = table;
            comboBox2.DisplayMember = "TermName";
            comboBox2.ValueMember = "TermId";
        }

        private bool ValidateSection()
        {
            errorProvider1.Clear();

            bool valid = true;

            if (comboBox1.SelectedIndex == -1)
            {
                errorProvider1.SetError(
                    comboBox1,
                    "Select course."
                );

                valid = false;
            }

            if (comboBox2.SelectedIndex == -1)
            {
                errorProvider1.SetError(
                    comboBox2,
                    "Select academic term."
                );

                valid = false;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(
                    textBox1,
                    "Class ID required."
                );

                valid = false;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider1.SetError(
                    textBox2,
                    "Section required."
                );

                valid = false;
            }

            if (comboBox3.SelectedIndex == -1)
            {
                errorProvider1.SetError(
                    comboBox3,
                    "Select section type."
                );

                valid = false;
            }

            if (comboBox4.SelectedIndex == -1)
            {
                errorProvider1.SetError(
                    comboBox4,
                    "Select status."
                );

                valid = false;
            }

            if (numericUpDown1.Value <= 0)
            {
                errorProvider1.SetError(
                    numericUpDown1,
                    "Capacity must be greater than zero."
                );

                valid = false;
            }

            if (comboBox5.SelectedIndex == -1)
            {
                errorProvider1.SetError(
                    comboBox5,
                    "Select meeting day."
                );

                valid = false;
            }

            if (comboBox6.SelectedIndex == -1)
            {
                errorProvider1.SetError(
                    comboBox6,
                    "Select start time."
                );

                valid = false;
            }

            if (comboBox7.SelectedIndex == -1)
            {
                errorProvider1.SetError(
                    comboBox7,
                    "Select end time."
                );

                valid = false;
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                errorProvider1.SetError(
                    textBox3,
                    "Room required."
                );

                valid = false;
            }

            return valid;
        }

        private void button2_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateSection())
            {
                MessageBox.Show(
                    "Please fix the highlighted fields.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            int selectedTermId =
                Convert.ToInt32(
                    comboBox2.SelectedValue
                );

            int selectedCourseId =
                Convert.ToInt32(
                    comboBox1.SelectedValue
                );

            string classId =
                textBox1.Text.Trim();

            string sectionName =
                textBox2.Text.Trim();

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            try
            {
                /*
                 * একই term-এ একই Class ID অথবা
                 * একই course-এর একই section পুনরায়
                 * add করা যাবে না।
                 */
                string checkQuery = @"
                    SELECT COUNT(*)
                    FROM dbo.CourseOfferings
                    WHERE TermId = @TermId
                    AND
                    (
                        UPPER(LTRIM(RTRIM(SourceClassId))) =
                            UPPER(@SourceClassId)

                        OR

                        (
                            CourseId = @CourseId
                            AND
                            UPPER(LTRIM(RTRIM(Section))) =
                                UPPER(@Section)
                        )
                    );
                ";

                using SqlCommand checkCommand =
                    new SqlCommand(
                        checkQuery,
                        connection
                    );

                checkCommand.Parameters.Add(
                    "@TermId",
                    SqlDbType.Int
                ).Value = selectedTermId;

                checkCommand.Parameters.Add(
                    "@CourseId",
                    SqlDbType.Int
                ).Value = selectedCourseId;

                checkCommand.Parameters.Add(
                    "@SourceClassId",
                    SqlDbType.NVarChar,
                    50
                ).Value = classId;

                checkCommand.Parameters.Add(
                    "@Section",
                    SqlDbType.NVarChar,
                    50
                ).Value = sectionName;

                int existingCount =
                    Convert.ToInt32(
                        checkCommand.ExecuteScalar()
                    );

                if (existingCount > 0)
                {
                    MessageBox.Show(
                        "The Class ID already exists, or this " +
                        "course already has the same section in " +
                        "the selected academic term.",
                        "Duplicate Section",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                SqlTransaction transaction =
                    connection.BeginTransaction();

                try
                {
                    int offeringId;

                    string offeringQuery = @"
                        INSERT INTO dbo.CourseOfferings
                        (
                            TermId,
                            CourseId,
                            SourceClassId,
                            Section,
                            OfferingStatus,
                            Capacity,
                            EnrolledCount,
                            IsActive,
                            OfferingType
                        )
                        VALUES
                        (
                            @TermId,
                            @CourseId,
                            @SourceClassId,
                            @Section,
                            @OfferingStatus,
                            @Capacity,
                            @EnrolledCount,
                            @IsActive,
                            @OfferingType
                        );

                        SELECT SCOPE_IDENTITY();
                    ";

                    using (
                        SqlCommand command =
                            new SqlCommand(
                                offeringQuery,
                                connection,
                                transaction
                            )
                    )
                    {
                        command.Parameters.Add(
                            "@TermId",
                            SqlDbType.Int
                        ).Value = selectedTermId;

                        command.Parameters.Add(
                            "@CourseId",
                            SqlDbType.Int
                        ).Value = selectedCourseId;

                        command.Parameters.Add(
                            "@SourceClassId",
                            SqlDbType.NVarChar,
                            50
                        ).Value = classId;

                        command.Parameters.Add(
                            "@Section",
                            SqlDbType.NVarChar,
                            50
                        ).Value = sectionName;

                        command.Parameters.Add(
                            "@OfferingStatus",
                            SqlDbType.NVarChar,
                            30
                        ).Value = comboBox4.Text.Trim();

                        command.Parameters.Add(
                            "@Capacity",
                            SqlDbType.Int
                        ).Value =
                            Convert.ToInt32(
                                numericUpDown1.Value
                            );

                        command.Parameters.Add(
                            "@EnrolledCount",
                            SqlDbType.Int
                        ).Value =
                            Convert.ToInt32(
                                numericUpDown2.Value
                            );

                        command.Parameters.Add(
                            "@IsActive",
                            SqlDbType.Bit
                        ).Value = checkBox1.Checked;

                        command.Parameters.Add(
                            "@OfferingType",
                            SqlDbType.NVarChar,
                            50
                        ).Value = comboBox3.Text.Trim();

                        offeringId =
                            Convert.ToInt32(
                                command.ExecuteScalar()
                            );
                    }

                    string meetingQuery = @"
                        INSERT INTO dbo.ClassMeetings
                        (
                            OfferingId,
                            MeetingDay,
                            StartTime,
                            EndTime,
                            Room
                        )
                        VALUES
                        (
                            @OfferingId,
                            @MeetingDay,
                            @StartTime,
                            @EndTime,
                            @Room
                        );
                    ";

                    using (
                        SqlCommand command =
                            new SqlCommand(
                                meetingQuery,
                                connection,
                                transaction
                            )
                    )
                    {
                        command.Parameters.Add(
                            "@OfferingId",
                            SqlDbType.Int
                        ).Value = offeringId;

                        command.Parameters.Add(
                            "@MeetingDay",
                            SqlDbType.NVarChar,
                            20
                        ).Value =
                            comboBox5.Text.Trim();

                        command.Parameters.Add(
                            "@StartTime",
                            SqlDbType.Time
                        ).Value =
                            DateTime.Parse(
                                comboBox6.Text
                            ).TimeOfDay;

                        command.Parameters.Add(
                            "@EndTime",
                            SqlDbType.Time
                        ).Value =
                            DateTime.Parse(
                                comboBox7.Text
                            ).TimeOfDay;

                        command.Parameters.Add(
                            "@Room",
                            SqlDbType.NVarChar,
                            100
                        ).Value =
                            textBox3.Text.Trim();

                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    MessageBox.Show(
                        "Section added successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    DialogResult =
                        DialogResult.OK;

                    Close();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Section could not be saved.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void button1_Click(
            object sender,
            EventArgs e)
        {
            DialogResult =
                DialogResult.Cancel;

            Close();
        }

        private void comboBox1_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(
            object sender,
            EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {

        }

        private void label4_Click(
            object sender,
            EventArgs e)
        {

        }

        private void label6_Click(
            object sender,
            EventArgs e)
        {

        }
    }
}