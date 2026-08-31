using AIUBCourseScheduler.DataAccess;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIUBCourseScheduler.Services;

namespace AIUBCourseScheduler.UserControls.Admin
{
    public partial class UsersControl : Form
    {
        public UsersControl()
        {
            InitializeComponent();

            Load += UsersControl_Load;
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            textBox1.KeyDown += textBox1_KeyDown;
            button3.Click += button3_Click;
        }

        private async void UsersControl_Load(
            object? sender,
            EventArgs e)
        {
            await LoadUsersAsync();
        }

        // Search button
        private async void button1_Click(
            object? sender,
            EventArgs e)
        {
            await SearchUsersAsync();
        }

        // Search using Enter key
        private async void textBox1_KeyDown(
            object? sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await SearchUsersAsync();
            }
        }

        private async Task SearchUsersAsync()
        {
            button1.Enabled = false;
            button1.Text = "Searching...";

            try
            {
                string searchText =
                    textBox1.Text.Trim();

                await LoadUsersAsync(searchText);
            }
            finally
            {
                button1.Text = "Search";
                button1.Enabled = true;
            }
        }

        // Refresh button
        private async void button2_Click(
            object? sender,
            EventArgs e)
        {
            button2.Enabled = false;
            button2.Text = "Loading...";

            try
            {
                textBox1.Clear();
                await LoadUsersAsync();
            }
            finally
            {
                button2.Text = "Refresh";
                button2.Enabled = true;
            }
        }

        private async Task LoadUsersAsync(
            string searchText = "")
        {
            try
            {
                using SqlConnection connection =
                    DatabaseConnection.GetConnection();

                await connection.OpenAsync();

                string query = @"
                    SELECT
                        UserId AS [User ID],
                        FullName AS [Full Name],

                        ISNULL(
                            StudentId,
                            'N/A'
                        ) AS [Student ID],

                        Email,
                        UserRole AS [Role],

                        CASE
                            WHEN IsActive = 1
                                THEN 'Active'
                            ELSE 'Inactive'
                        END AS [Status],

                        CreatedAt AS [Created At]

                    FROM dbo.Users

                    WHERE
                        @SearchText = N''

                        OR FullName LIKE
                            N'%' + @SearchText + N'%'

                        OR ISNULL(StudentId, N'') LIKE
                            N'%' + @SearchText + N'%'

                        OR Email LIKE
                            N'%' + @SearchText + N'%'

                        OR UserRole LIKE
                            N'%' + @SearchText + N'%'

                    ORDER BY
                        CreatedAt DESC;";

                using SqlCommand command =
                    new SqlCommand(
                        query,
                        connection
                    );

                command.Parameters
                    .Add(
                        "@SearchText",
                        SqlDbType.NVarChar,
                        255
                    )
                    .Value = searchText;

                using SqlDataReader reader =
                    await command.ExecuteReaderAsync();

                DataTable userTable =
                    new DataTable();

                userTable.Load(reader);

                dataGridView1.DataSource =
                    userTable;

                ConfigureGridColumns();
                dataGridView1.ClearSelection();

                if (string.IsNullOrWhiteSpace(searchText))
                {
                    label3.Text =
                        $"{userTable.Rows.Count} user(s) found.";
                }
                else
                {
                    label3.Text =
                        $"{userTable.Rows.Count} result(s) found for \"{searchText}\".";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Could not load users.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ConfigureGridColumns()
        {
            if (dataGridView1.Columns["User ID"]
                is DataGridViewColumn userIdColumn)
            {
                userIdColumn.FillWeight = 45;
            }

            if (dataGridView1.Columns["Full Name"]
                is DataGridViewColumn fullNameColumn)
            {
                fullNameColumn.FillWeight = 110;
            }

            if (dataGridView1.Columns["Student ID"]
                is DataGridViewColumn studentIdColumn)
            {
                studentIdColumn.FillWeight = 75;
            }

            if (dataGridView1.Columns["Email"]
                is DataGridViewColumn emailColumn)
            {
                emailColumn.FillWeight = 135;
            }

            if (dataGridView1.Columns["Role"]
                is DataGridViewColumn roleColumn)
            {
                roleColumn.FillWeight = 60;
            }

            if (dataGridView1.Columns["Status"]
                is DataGridViewColumn statusColumn)
            {
                statusColumn.FillWeight = 65;
            }

            if (dataGridView1.Columns["Created At"]
                is DataGridViewColumn createdAtColumn)
            {
                createdAtColumn.FillWeight = 100;

                createdAtColumn.DefaultCellStyle.Format =
                    "dd MMM yyyy, hh:mm tt";
            }
        }

        private async void button3_Click(
    object? sender,
    EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a user first.",
                    "No User Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DataGridViewRow selectedRow =
                dataGridView1.SelectedRows[0];

            int userId = Convert.ToInt32(
                selectedRow.Cells["User ID"].Value
            );

            string fullName =
                Convert.ToString(
                    selectedRow.Cells["Full Name"].Value
                ) ?? "Selected user";

            string currentStatus =
                Convert.ToString(
                    selectedRow.Cells["Status"].Value
                ) ?? "Inactive";

            // Currently logged-in Admin নিজের account
            // deactivate করতে পারবে না
            if (userId == UserSession.UserId)
            {
                MessageBox.Show(
                    "You cannot deactivate your own account while you are logged in.",
                    "Action Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            bool newIsActive =
                !currentStatus.Equals(
                    "Active",
                    StringComparison.OrdinalIgnoreCase
                );

            string actionText =
                newIsActive ? "activate" : "deactivate";

            DialogResult confirmation =
                MessageBox.Show(
                    $"Are you sure you want to {actionText} {fullName}'s account?",
                    "Confirm Account Status",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (confirmation != DialogResult.Yes)
            {
                return;
            }

            button3.Enabled = false;
            button3.Text = "Updating...";

            try
            {
                using SqlConnection connection =
                    DatabaseConnection.GetConnection();

                await connection.OpenAsync();

                string query = @"
            UPDATE dbo.Users
            SET IsActive = @IsActive
            WHERE UserId = @UserId;";

                using SqlCommand command =
                    new SqlCommand(query, connection);

                command.Parameters
                    .Add(
                        "@IsActive",
                        SqlDbType.Bit
                    )
                    .Value = newIsActive;

                command.Parameters
                    .Add(
                        "@UserId",
                        SqlDbType.Int
                    )
                    .Value = userId;

                int affectedRows =
                    await command.ExecuteNonQueryAsync();

                if (affectedRows > 0)
                {
                    MessageBox.Show(
                        $"The account has been {actionText}d successfully.",
                        "Status Updated",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    await LoadUsersAsync(
                        textBox1.Text.Trim()
                    );
                }
                else
                {
                    MessageBox.Show(
                        "The selected user could not be found.",
                        "Update Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Could not update account status.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                button3.Text = "Activate / Deactivate";
                button3.Enabled = true;
            }
        }
    }
}