using Microsoft.Data.SqlClient;

namespace AIUBCourseScheduler.DataAccess
{
    public static class DatabaseInitializer
    {
        public static void EnsureRequiredTables()
        {
            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            string query = @"
                IF OBJECT_ID(N'dbo.EmailOtps', N'U') IS NULL
                BEGIN
                    CREATE TABLE dbo.EmailOtps
                    (
                        OtpId INT IDENTITY(1,1) PRIMARY KEY,
                        Email NVARCHAR(255) NOT NULL,
                        OtpHash NVARCHAR(255) NOT NULL,
                        Purpose NVARCHAR(30) NOT NULL,
                        ExpiresAt DATETIME2 NOT NULL,
                        IsUsed BIT NOT NULL DEFAULT 0,
                        AttemptCount INT NOT NULL DEFAULT 0,
                        CreatedAt DATETIME2 NOT NULL
                            DEFAULT SYSUTCDATETIME(),

                        CONSTRAINT CK_EmailOtps_Purpose
                        CHECK
                        (
                            Purpose IN
                            (
                                'Registration',
                                'ForgotPassword'
                            )
                        )
                    );

                    CREATE INDEX IX_EmailOtps_EmailPurpose
                    ON dbo.EmailOtps
                    (
                        Email,
                        Purpose,
                        IsUsed
                    );
                END;";

            using SqlCommand command = new SqlCommand(query, connection);

            command.ExecuteNonQuery();
        }
    }
}