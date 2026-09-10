using AIUBCourseScheduler.DataAccess;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.Threading.Tasks;

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
                FROM Courses
                WHERE IsActive = 1
                ORDER BY CourseTitle
            ";


            using SqlCommand command =
                new SqlCommand(query, connection);



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
                ORDER BY TermId DESC
            ";


            using SqlCommand command =
                new SqlCommand(query, connection);



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



            using SqlConnection connection =
                DatabaseConnection.GetConnection();


            connection.Open();



            try
            {

                // Duplicate Check
                string checkQuery = @"
                                    SELECT COUNT(*)
                                    FROM CourseOfferings
                                    WHERE TermId = @TermId
                                    AND CourseId = @CourseId
                                    AND Section = @Section
                                ";



                using (SqlCommand checkCommand =
                    new SqlCommand(
                        checkQuery,
                        connection))
                {


                    checkCommand.Parameters.AddWithValue(
                        "@TermId",
                        comboBox2.SelectedValue
                    );


                    checkCommand.Parameters.AddWithValue(
    "@CourseId",
    comboBox1.SelectedValue
);


                    checkCommand.Parameters.AddWithValue(
                        "@Section",
                        textBox2.Text.Trim()
                    );



                    int existingCount =
                        Convert.ToInt32(
                            checkCommand.ExecuteScalar()
                        );



                    if (existingCount > 0)
                    {
                        MessageBox.Show(
                            "This Class ID already exists for the selected academic term.\nPlease use another Class ID.",
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

                    int offeringId;



                    string offeringQuery = @"

                INSERT INTO CourseOfferings
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




                    using (SqlCommand command =
                        new SqlCommand(
                            offeringQuery,
                            connection,
                            transaction))
                    {


                        command.Parameters.AddWithValue(
                            "@TermId",
                            comboBox2.SelectedValue
                        );


                        command.Parameters.AddWithValue(
                            "@CourseId",
                            comboBox1.SelectedValue
                        );


                        command.Parameters.AddWithValue(
                            "@SourceClassId",
                            textBox1.Text.Trim()
                        );


                        command.Parameters.AddWithValue(
                            "@Section",
                            textBox2.Text.Trim()
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



                        offeringId =
                            Convert.ToInt32(
                                command.ExecuteScalar()
                            );

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
                            offeringId
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