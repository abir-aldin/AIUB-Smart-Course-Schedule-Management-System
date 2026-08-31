using AIUBCourseScheduler.DataAccess;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace AIUBCourseScheduler.UserControls.Admin
{
    public partial class SectionsControl : Form
    {
        // Database থেকে আসা সকল section এখানে রাখা হবে
        private readonly List<CourseSection> sections =
            new List<CourseSection>();

        public SectionsControl()
        {
            InitializeComponent();

            // Designer-এর columns ব্যবহার করা হবে
            dataGridView1.AutoGenerateColumns = false;

            // Model properties-এর সঙ্গে grid columns connect করা হচ্ছে
            SectionColumn.DataPropertyName = "SectionName";
            CourseColumn.DataPropertyName = "CourseName";
            DayTimeColumn.DataPropertyName = "DayTime";
            RoomColumn.DataPropertyName = "Room";
            CpacityColumn.DataPropertyName = "Capacity";
            EnrolledColumn.DataPropertyName = "EnrolledCount";

            // Grid শুধুমাত্র data দেখাবে
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // Action button-এর text
            ActionColumn1.Text = "Edit";
            ActionColumn1.UseColumnTextForButtonValue = true;

            ActionColumn2.Text = "Delete";
            ActionColumn2.UseColumnTextForButtonValue = true;

        
        }

        private async Task LoadSectionsAsync()
        {
            sections.Clear();

            // SQL থেকে সাধারণ row নেওয়া হবে।
            // Day/time grouping এবং formatting C#-এ করা হবে।
            const string query = @"
        SELECT
            CO.OfferingId,
            CO.Section,
            C.CourseTitle,
            CM.MeetingDay,
            CM.StartTime,
            CM.EndTime,
            CM.Room,
            ISNULL(CO.Capacity, 0) AS Capacity,
            ISNULL(CO.EnrolledCount, 0) AS EnrolledCount,
            ISNULL(CO.OfferingType, 'N/A') AS SectionType,
            CO.IsActive

        FROM dbo.CourseOfferings AS CO

        INNER JOIN dbo.Courses AS C
            ON C.CourseId = CO.CourseId

        LEFT JOIN dbo.ClassMeetings AS CM
            ON CM.OfferingId = CO.OfferingId

        ORDER BY
            C.CourseTitle,
            CO.Section,
            CM.MeetingId;";

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            await connection.OpenAsync();

            using SqlCommand command =
                new SqlCommand(query, connection);

            using SqlDataReader reader =
                await command.ExecuteReaderAsync();

            // একই section-এর meeting day/time একসঙ্গে রাখবে
            Dictionary<int, List<string>> sectionMeetings =
                new Dictionary<int, List<string>>();

            // একই room একাধিকবার থাকলে duplicate দেখাবে না
            Dictionary<int, HashSet<string>> sectionRooms =
                new Dictionary<int, HashSet<string>>();

            // OfferingId দিয়ে section খুঁজে বের করা হবে
            Dictionary<int, CourseSection> sectionDictionary =
                new Dictionary<int, CourseSection>();

            while (await reader.ReadAsync())
            {
                int offeringId = reader.GetInt32(0);

                // Section প্রথমবার পাওয়া গেলে model তৈরি হবে
                if (!sectionDictionary.TryGetValue(
                    offeringId,
                    out CourseSection? section))
                {
                    section = new CourseSection
                    {
                        OfferingId = offeringId,
                        SectionName = reader.GetString(1),
                        CourseName = reader.GetString(2),

                        Capacity = reader.GetInt32(7),
                        EnrolledCount = reader.GetInt32(8),

                        SectionType = reader.GetString(9),

                        Status = reader.GetBoolean(10)
                            ? "Active"
                            : "Inactive"
                    };

                    sectionDictionary.Add(
                        offeringId,
                        section
                    );

                    sections.Add(section);

                    sectionMeetings.Add(
                        offeringId,
                        new List<string>()
                    );

                    sectionRooms.Add(
                        offeringId,
                        new HashSet<string>(
                            StringComparer.OrdinalIgnoreCase
                        )
                    );
                }

                // Meeting না থাকলে LEFT JOIN-এর values null হবে
                if (!reader.IsDBNull(3))
                {
                    string meetingDay =
                        reader.GetString(3);

                    TimeSpan startTime =
                        reader.GetTimeSpan(4);

                    TimeSpan endTime =
                        reader.GetTimeSpan(5);

                    string meetingText =
                        $"{meetingDay} " +
                        $"{FormatTime(startTime)} - " +
                        $"{FormatTime(endTime)}";

                    sectionMeetings[offeringId]
                        .Add(meetingText);

                    if (!reader.IsDBNull(6))
                    {
                        sectionRooms[offeringId]
                            .Add(reader.GetString(6));
                    }
                }
            }

            // প্রতিটি section-এর meeting এবং room একসঙ্গে দেখানো হবে
            foreach (CourseSection section in sections)
            {
                List<string> meetings =
                    sectionMeetings[section.OfferingId];

                HashSet<string> rooms =
                    sectionRooms[section.OfferingId];

                section.DayTime = meetings.Count > 0
                    ? string.Join(" | ", meetings)
                    : "Not assigned";

                section.Room = rooms.Count > 0
                    ? string.Join(" | ", rooms)
                    : "N/A";
            }
        }

        private static string FormatTime(TimeSpan time)
        {
            // SQL TimeSpan-কে 12-hour AM/PM format-এ দেখাবে
            return DateTime.Today
                .Add(time)
                .ToString("h:mm tt");
        }

        private void ShowSections(
    IEnumerable<CourseSection> sectionList)
        {
            // Filter অনুযায়ী যেসব section দেখানো হবে
            List<CourseSection> displayedSections =
                sectionList.ToList();

            // Grid-এর পুরোনো data clear করে নতুন data দেখানো হচ্ছে
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = displayedSections;

            // Data দেখানোর পর কোনো row selected থাকবে না
            dataGridView1.ClearSelection();
        }

        private async void SectionsControl_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                // Database থেকে sections load করা হচ্ছে
                await LoadSectionsAsync();

                // Loaded sections grid-এ দেখানো হচ্ছে
                ShowSections(sections);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Could not load sections.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void textBox1_TextChanged(
    object sender,
    EventArgs e)
        {
            string searchText =
                textBox1.Text.Trim();

            // Search box খালি হলে সকল section দেখানো হবে
            if (string.IsNullOrWhiteSpace(searchText))
            {
                ShowSections(sections);
                return;
            }

            // Section name অথবা Course name দিয়ে search হবে
            List<CourseSection> filteredSections =
                sections.Where(section =>
                    section.SectionName.Contains(
                        searchText,
                        StringComparison.OrdinalIgnoreCase
                    ) ||
                    section.CourseName.Contains(
                        searchText,
                        StringComparison.OrdinalIgnoreCase
                    )
                ).ToList();

            ShowSections(filteredSections);
        }

        private async void button2_Click(
    object sender,
    EventArgs e)
        {
            try
            {
                // Refresh চলাকালীন button দ্বিতীয়বার click করা যাবে না
                button2.Enabled = false;
                button2.Text = "Refreshing...";

                // Search field clear করা হচ্ছে
                textBox1.Clear();

                // Database থেকে সর্বশেষ section data load করা হচ্ছে
                await LoadSectionsAsync();

                // নতুন data grid-এ দেখানো হচ্ছে
                ShowSections(sections);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Could not refresh sections.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                // Refresh শেষ হলে button আবার চালু হবে
                button2.Enabled = true;
                button2.Text = "Refresh";
            }
        }
    }
}