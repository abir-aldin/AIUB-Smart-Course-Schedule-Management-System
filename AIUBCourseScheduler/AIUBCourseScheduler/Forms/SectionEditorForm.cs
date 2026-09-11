using AIUBCourseScheduler.DataAccess;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace AIUBCourseScheduler.Forms
{
    public partial class SectionEditorForm : Form
    {
        private readonly int? offeringId;

        public SectionEditorForm()
        {
            InitializeComponent();

            ConfigureMeetingTypeBehavior();
        }

        public SectionEditorForm(int offeringId)
        {
            InitializeComponent();

            ConfigureMeetingTypeBehavior();

            this.offeringId = offeringId;
        }

        private void ConfigureMeetingTypeBehavior()
        {
            comboBox3.SelectedIndexChanged -=
                comboBox3_SelectedIndexChanged;

            comboBox3.SelectedIndexChanged +=
                comboBox3_SelectedIndexChanged;
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


            comboBox9.Items.Clear();
            comboBox9.Items.AddRange(
                new object[]
                {
                    "Sunday",
                    "Monday",
                    "Tuesday",
                    "Wednesday",
                    "Thursday",
                    "Friday"
                }
            );


            checkBox1.Checked = true;

            UpdateAlternativeMeetingState();

            if (offeringId.HasValue)
            {
                label1.Text = "Edit Section";
                button2.Text = "Update Section";

                LoadSectionData();

                UpdateAlternativeMeetingState();
            }
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
                FROM Courses
                WHERE IsActive = 1
                   OR CourseId =
                      (
                          SELECT CourseId
                          FROM CourseOfferings
                          WHERE OfferingId = @OfferingId
                      )
                ORDER BY CourseTitle
            ";


            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.Add(
                "@OfferingId",
                SqlDbType.Int
            ).Value =
                offeringId.HasValue
                    ? offeringId.Value
                    : DBNull.Value;



            DataTable table =
                new DataTable();


            table.Load(
                command.ExecuteReader()
            );


            comboBox1.DataSource = table;

            comboBox1.DisplayMember =
                "CourseTitle";

            comboBox1.ValueMember =
                "CourseId";
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
                FROM AcademicTerms
                WHERE IsActive = 1
                   OR TermId =
                      (
                          SELECT TermId
                          FROM CourseOfferings
                          WHERE OfferingId = @OfferingId
                      )
                ORDER BY TermId DESC
            ";


            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.Add(
                "@OfferingId",
                SqlDbType.Int
            ).Value =
                offeringId.HasValue
                    ? offeringId.Value
                    : DBNull.Value;



            DataTable table =
                new DataTable();


            table.Load(
                command.ExecuteReader()
            );


            comboBox2.DataSource =
                table;


            comboBox2.DisplayMember =
                "TermName";


            comboBox2.ValueMember =
                "TermId";
        }

        private void LoadSectionData()
        {
            if (!offeringId.HasValue)
            {
                return;
            }

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            string offeringQuery = @"
                SELECT
                    TermId,
                    CourseId,
                    SourceClassId,
                    Section,
                    OfferingStatus,
                    Capacity,
                    EnrolledCount,
                    IsActive,
                    OfferingType
                FROM dbo.CourseOfferings
                WHERE OfferingId = @OfferingId;
            ";

            using (
                SqlCommand command =
                    new SqlCommand(
                        offeringQuery,
                        connection
                    )
            )
            {
                command.Parameters.Add(
                    "@OfferingId",
                    SqlDbType.Int
                ).Value = offeringId.Value;

                using SqlDataReader reader =
                    command.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show(
                        "The selected section could not be found.",
                        "Section Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                comboBox2.SelectedValue =
                    reader.GetInt32(0);

                comboBox1.SelectedValue =
                    reader.GetInt32(1);

                textBox1.Text =
                    reader.GetString(2);

                textBox2.Text =
                    reader.GetString(3);

                string offeringStatus =
                    reader.IsDBNull(4)
                        ? "Open"
                        : reader.GetString(4);

                if (!comboBox4.Items.Contains(offeringStatus))
                {
                    comboBox4.Items.Add(offeringStatus);
                }

                comboBox4.SelectedItem = offeringStatus;

                numericUpDown1.Value =
                    Math.Min(
                        numericUpDown1.Maximum,
                        reader.IsDBNull(5)
                            ? 0
                            : reader.GetInt32(5)
                    );

                numericUpDown2.Value =
                    Math.Min(
                        numericUpDown2.Maximum,
                        reader.IsDBNull(6)
                            ? 0
                            : reader.GetInt32(6)
                    );

                checkBox1.Checked =
                    reader.GetBoolean(7);

                string offeringType =
                    reader.IsDBNull(8)
                        ? "Theory"
                        : reader.GetString(8);

                if (!comboBox3.Items.Contains(offeringType))
                {
                    comboBox3.Items.Add(offeringType);
                }

                comboBox3.SelectedItem = offeringType;
            }

            string meetingQuery = @"
                SELECT TOP (2)
                    MeetingDay,
                    StartTime,
                    EndTime,
                    Room
                FROM dbo.ClassMeetings
                WHERE OfferingId = @OfferingId
                ORDER BY MeetingId;
            ";

            using SqlCommand meetingCommand =
                new SqlCommand(
                    meetingQuery,
                    connection
                );

            meetingCommand.Parameters.Add(
                "@OfferingId",
                SqlDbType.Int
            ).Value = offeringId.Value;

            using SqlDataReader meetingReader =
                meetingCommand.ExecuteReader();

            int meetingNumber = 0;

            while (meetingReader.Read())
            {
                string day =
                    meetingReader.GetString(0).Trim();

                string startTime =
                    FormatTime(
                        meetingReader.GetTimeSpan(1)
                    );

                string endTime =
                    FormatTime(
                        meetingReader.GetTimeSpan(2)
                    );

                string room =
                    meetingReader.IsDBNull(3)
                        ? string.Empty
                        : meetingReader.GetString(3);

                if (meetingNumber == 0)
                {
                    SetComboBoxValue(comboBox5, day);
                    SetComboBoxValue(comboBox6, startTime);
                    SetComboBoxValue(comboBox7, endTime);
                    textBox3.Text = room;
                }
                else
                {
                    SetComboBoxValue(comboBox9, day);
                    SetComboBoxValue(comboBox10, startTime);
                    SetComboBoxValue(comboBox11, endTime);
                    textBox4.Text = room;
                }

                meetingNumber++;
            }
        }

        private static string FormatTime(TimeSpan time)
        {
            return DateTime.Today
                .Add(time)
                .ToString("h:mm tt");
        }

        private static void SetComboBoxValue(
            ComboBox comboBox,
            string value)
        {
            if (!comboBox.Items.Contains(value))
            {
                comboBox.Items.Add(value);
            }

            comboBox.SelectedItem = value;
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
                Convert.ToInt32(comboBox2.SelectedValue);

            int selectedCourseId =
                Convert.ToInt32(comboBox1.SelectedValue);

            string classId =
                textBox1.Text.Trim();

            string sectionName =
                textBox2.Text.Trim();



            using SqlConnection connection =
                DatabaseConnection.GetConnection();


            connection.Open();



            try
            {

                // Duplicate Class ID অথবা একই course-এর section check
                string checkQuery = @"
                    SELECT COUNT(*)
                    FROM dbo.CourseOfferings
                    WHERE TermId = @TermId
                      AND OfferingId <> @CurrentOfferingId
                      AND
                      (
                          UPPER(LTRIM(RTRIM(SourceClassId))) =
                              UPPER(@SourceClassId)
                          OR
                          (
                              CourseId = @CourseId
                              AND UPPER(LTRIM(RTRIM(Section))) =
                                  UPPER(@Section)
                          )
                      );";



                using (SqlCommand checkCommand =
                    new SqlCommand(
                        checkQuery,
                        connection))
                {


                    checkCommand.Parameters.AddWithValue(
                        "@TermId",
                        selectedTermId
                    );


                    checkCommand.Parameters.AddWithValue(
                        "@CourseId",
                        selectedCourseId
                    );

                    checkCommand.Parameters.AddWithValue(
                        "@SourceClassId",
                        classId
                    );


                    checkCommand.Parameters.AddWithValue(
                        "@Section",
                        sectionName
                    );

                    checkCommand.Parameters.AddWithValue(
                        "@CurrentOfferingId",
                        offeringId ?? -1
                    );



                    int existingCount =
                        Convert.ToInt32(
                            checkCommand.ExecuteScalar()
                        );



                    if (existingCount > 0)
                    {
                        MessageBox.Show(
                            "The Class ID already exists, or this course " +
                            "already has the same section in the selected " +
                            "academic term.",
                            "Duplicate Section",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return;
                    }

                }





                SqlTransaction transaction =
                    connection.BeginTransaction();



                try
                {

                    int savedOfferingId;



                    string offeringQuery =
                        offeringId.HasValue
                            ? @"
                                UPDATE dbo.CourseOfferings
                                SET
                                    TermId = @TermId,
                                    CourseId = @CourseId,
                                    SourceClassId = @SourceClassId,
                                    Section = @Section,
                                    OfferingStatus = @OfferingStatus,
                                    Capacity = @Capacity,
                                    EnrolledCount = @EnrolledCount,
                                    IsActive = @IsActive,
                                    OfferingType = @OfferingType
                                WHERE OfferingId = @OfferingId;"
                            : @"
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

                                SELECT SCOPE_IDENTITY();";




                    using (SqlCommand command =
                        new SqlCommand(
                            offeringQuery,
                            connection,
                            transaction))
                    {


                        command.Parameters.AddWithValue(
                            "@TermId",
                            selectedTermId
                        );


                        command.Parameters.AddWithValue(
                            "@CourseId",
                            selectedCourseId
                        );


                        command.Parameters.AddWithValue(
                            "@SourceClassId",
                            classId
                        );


                        command.Parameters.AddWithValue(
                            "@Section",
                            sectionName
                        );


                        command.Parameters.AddWithValue(
                            "@OfferingStatus",
                            comboBox4.Text
                        );


                        command.Parameters.AddWithValue(
                            "@Capacity",
                            numericUpDown1.Value
                        );


                        command.Parameters.AddWithValue(
                            "@EnrolledCount",
                            numericUpDown2.Value
                        );


                        command.Parameters.AddWithValue(
                            "@IsActive",
                            checkBox1.Checked
                        );


                        command.Parameters.AddWithValue(
                            "@OfferingType",
                            comboBox3.Text
                        );



                        if (offeringId.HasValue)
                        {
                            command.Parameters.AddWithValue(
                                "@OfferingId",
                                offeringId.Value
                            );

                            command.ExecuteNonQuery();
                            savedOfferingId = offeringId.Value;

                            string deleteMeetingsQuery = @"
                                DELETE FROM dbo.ClassMeetings
                                WHERE OfferingId = @OfferingId;";

                            using SqlCommand deleteMeetingsCommand =
                                new SqlCommand(
                                    deleteMeetingsQuery,
                                    connection,
                                    transaction
                                );

                            deleteMeetingsCommand.Parameters.AddWithValue(
                                "@OfferingId",
                                savedOfferingId
                            );

                            deleteMeetingsCommand.ExecuteNonQuery();
                        }
                        else
                        {
                            savedOfferingId =
                                Convert.ToInt32(
                                    command.ExecuteScalar()
                                );
                        }

                    }







                    string meetingQuery = @"

                INSERT INTO ClassMeetings
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
                )

            ";





                    using (SqlCommand command =
                        new SqlCommand(
                            meetingQuery,
                            connection,
                            transaction))
                    {


                        command.Parameters.AddWithValue(
                            "@OfferingId",
                            savedOfferingId
                        );


                        command.Parameters.AddWithValue(
                            "@MeetingDay",
                            comboBox5.Text.Trim()
                        );


                        command.Parameters.AddWithValue(
                            "@StartTime",
                            DateTime.Parse(
                                comboBox6.Text
                            ).TimeOfDay
                        );


                        command.Parameters.AddWithValue(
                            "@EndTime",
                            DateTime.Parse(
                                comboBox7.Text
                            ).TimeOfDay
                        );


                        command.Parameters.AddWithValue(
                            "@Room",
                            textBox3.Text.Trim()
                        );


                        command.ExecuteNonQuery();

                    }

                    bool hasSecondMeeting =
                        IsTheorySelected() &&
                        comboBox9.SelectedIndex >= 0 &&
                        comboBox10.SelectedIndex >= 0 &&
                        comboBox11.SelectedIndex >= 0 &&
                        !string.IsNullOrWhiteSpace(textBox4.Text);

                    if (hasSecondMeeting)
                    {
                        using SqlCommand secondMeetingCommand =
                            new SqlCommand(
                                meetingQuery,
                                connection,
                                transaction
                            );

                        secondMeetingCommand.Parameters.AddWithValue(
                            "@OfferingId",
                            savedOfferingId
                        );

                        secondMeetingCommand.Parameters.AddWithValue(
                            "@MeetingDay",
                            comboBox9.Text.Trim()
                        );

                        secondMeetingCommand.Parameters.AddWithValue(
                            "@StartTime",
                            DateTime.Parse(
                                comboBox10.Text
                            ).TimeOfDay
                        );

                        secondMeetingCommand.Parameters.AddWithValue(
                            "@EndTime",
                            DateTime.Parse(
                                comboBox11.Text
                            ).TimeOfDay
                        );

                        secondMeetingCommand.Parameters.AddWithValue(
                            "@Room",
                            textBox4.Text.Trim()
                        );

                        secondMeetingCommand.ExecuteNonQuery();
                    }



                    transaction.Commit();



                    MessageBox.Show(
                        offeringId.HasValue
                            ? "Section updated successfully!"
                            : "Section added successfully!",
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
            if (!IsTheorySelected())
            {
                return;
            }

            SelectSuggestedAlternativeDay();
        }

        private void comboBox3_SelectedIndexChanged(
            object? sender,
            EventArgs e)
        {
            UpdateAlternativeMeetingState();
        }

        private bool IsTheorySelected()
        {
            return comboBox3.Text.Trim().Equals(
                "Theory",
                StringComparison.OrdinalIgnoreCase
            );
        }

        private void UpdateAlternativeMeetingState()
        {
            bool allowSecondMeeting =
                IsTheorySelected();

            comboBox9.Enabled = allowSecondMeeting;
            comboBox10.Enabled = allowSecondMeeting;
            comboBox11.Enabled = allowSecondMeeting;
            textBox4.Enabled = allowSecondMeeting;

            if (allowSecondMeeting)
            {
                SelectSuggestedAlternativeDay();
                return;
            }

            comboBox9.SelectedIndex = -1;
            comboBox10.SelectedIndex = -1;
            comboBox11.SelectedIndex = -1;

            comboBox9.Text = string.Empty;
            comboBox10.Text = string.Empty;
            comboBox11.Text = string.Empty;
            textBox4.Clear();
        }

        private void SelectSuggestedAlternativeDay()
        {
            string firstDay =
                comboBox5.Text.Trim();

            if (firstDay.Equals(
                "Sunday",
                StringComparison.OrdinalIgnoreCase))
            {
                comboBox9.SelectedItem = "Tuesday";
            }
            else if (firstDay.Equals(
                "Monday",
                StringComparison.OrdinalIgnoreCase))
            {
                comboBox9.SelectedItem = "Wednesday";
            }
            else
            {
                /*
                 * Thursday, Friday অথবা অন্য day হলে
                 * alternative day manually select করা হবে।
                 */
                comboBox9.SelectedIndex = -1;
                comboBox9.Text = string.Empty;
            }
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult =
     DialogResult.Cancel;

            Close();
        }
    }
}
