using AIUBCourseScheduler.DataAccess;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AIUBCourseScheduler.Services
{
    public enum OtpPurpose
    {
        Registration,
        ForgotPassword
    }

    public enum OtpVerificationResult
    {
        Success,
        Invalid,
        Expired,
        TooManyAttempts,
        NotFound
    }

    public static class OtpService
    {
        private const int OtpExpiryMinutes = 5;
        private const int MaximumAttempts = 5;

        // নতুন OTP তৈরি, Database-এ save এবং Email-এ send করবে
        public static async Task SendOtpAsync(
            string email,
            OtpPurpose purpose)
        {
            email = NormalizeEmail(email);

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException(
                    "Email address cannot be empty."
                );
            }

            string otp = GenerateOtp();

            // Database-এ original OTP না রেখে hash রাখা হবে
            string otpHash = PasswordHelper.HashPassword(otp);

            int newOtpId;

            using (SqlConnection connection =
                   DatabaseConnection.GetConnection())
            {
                await connection.OpenAsync();

                using SqlTransaction transaction =
                    connection.BeginTransaction();

                try
                {
                    // এই email ও purpose-এর আগের unused OTP বন্ধ করে দেবে
                    string invalidateQuery = @"
                        UPDATE dbo.EmailOtps
                        SET IsUsed = 1
                        WHERE Email = @Email
                          AND Purpose = @Purpose
                          AND IsUsed = 0;";

                    using (SqlCommand invalidateCommand =
                           new SqlCommand(
                               invalidateQuery,
                               connection,
                               transaction))
                    {
                        invalidateCommand.Parameters
                            .Add(
                                "@Email",
                                SqlDbType.NVarChar,
                                255)
                            .Value = email;

                        invalidateCommand.Parameters
                            .Add(
                                "@Purpose",
                                SqlDbType.NVarChar,
                                30)
                            .Value = purpose.ToString();

                        await invalidateCommand
                            .ExecuteNonQueryAsync();
                    }

                    // নতুন OTP Database-এ insert করবে
                    string insertQuery = @"
                        INSERT INTO dbo.EmailOtps
                        (
                            Email,
                            OtpHash,
                            Purpose,
                            ExpiresAt,
                            IsUsed,
                            AttemptCount,
                            CreatedAt
                        )
                        OUTPUT INSERTED.OtpId
                        VALUES
                        (
                            @Email,
                            @OtpHash,
                            @Purpose,
                            DATEADD(
                                MINUTE,
                                @ExpiryMinutes,
                                SYSUTCDATETIME()
                            ),
                            0,
                            0,
                            SYSUTCDATETIME()
                        );";

                    using (SqlCommand insertCommand =
                           new SqlCommand(
                               insertQuery,
                               connection,
                               transaction))
                    {
                        insertCommand.Parameters
                            .Add(
                                "@Email",
                                SqlDbType.NVarChar,
                                255)
                            .Value = email;

                        insertCommand.Parameters
                            .Add(
                                "@OtpHash",
                                SqlDbType.NVarChar,
                                255)
                            .Value = otpHash;

                        insertCommand.Parameters
                            .Add(
                                "@Purpose",
                                SqlDbType.NVarChar,
                                30)
                            .Value = purpose.ToString();

                        insertCommand.Parameters
                            .Add(
                                "@ExpiryMinutes",
                                SqlDbType.Int)
                            .Value = OtpExpiryMinutes;

                        object? insertedId =
                            await insertCommand
                                .ExecuteScalarAsync();

                        if (insertedId == null)
                        {
                            throw new InvalidOperationException(
                                "OTP could not be saved."
                            );
                        }

                        newOtpId =
                            Convert.ToInt32(insertedId);
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }

            try
            {
                // Project Gmail থেকে receiver-এর Email-এ OTP যাবে
                await EmailService.SendOtpAsync(email, otp);
            }
            catch
            {
                // Email send না হলে OTP-টি ব্যবহারযোগ্য থাকবে না
                await InvalidateOtpSilentlyAsync(newOtpId);
                throw;
            }
        }

        // User-এর দেওয়া OTP verify করবে
        public static async Task<OtpVerificationResult>
            VerifyOtpAsync(
                string email,
                string enteredOtp,
                OtpPurpose purpose)
        {
            email = NormalizeEmail(email);
            enteredOtp = enteredOtp.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                return OtpVerificationResult.NotFound;
            }

            // OTP অবশ্যই ৬ সংখ্যার হতে হবে
            if (enteredOtp.Length != 6 ||
                !int.TryParse(enteredOtp, out _))
            {
                return OtpVerificationResult.Invalid;
            }

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            await connection.OpenAsync();

            using SqlTransaction transaction =
                connection.BeginTransaction(
                    IsolationLevel.Serializable
                );

            try
            {
                int otpId;
                string savedOtpHash;
                DateTime expiresAt;
                int attemptCount;

                string selectQuery = @"
                    SELECT TOP (1)
                        OtpId,
                        OtpHash,
                        ExpiresAt,
                        AttemptCount
                    FROM dbo.EmailOtps
                         WITH (UPDLOCK, ROWLOCK)
                    WHERE Email = @Email
                      AND Purpose = @Purpose
                      AND IsUsed = 0
                    ORDER BY OtpId DESC;";

                using (SqlCommand selectCommand =
                       new SqlCommand(
                           selectQuery,
                           connection,
                           transaction))
                {
                    selectCommand.Parameters
                        .Add(
                            "@Email",
                            SqlDbType.NVarChar,
                            255)
                        .Value = email;

                    selectCommand.Parameters
                        .Add(
                            "@Purpose",
                            SqlDbType.NVarChar,
                            30)
                        .Value = purpose.ToString();

                    using SqlDataReader reader =
                        await selectCommand
                            .ExecuteReaderAsync();

                    if (!await reader.ReadAsync())
                    {
                        await reader.CloseAsync();
                        transaction.Commit();

                        return OtpVerificationResult.NotFound;
                    }

                    otpId = reader.GetInt32(0);
                    savedOtpHash = reader.GetString(1);
                    expiresAt = reader.GetDateTime(2);
                    attemptCount = reader.GetInt32(3);

                    await reader.CloseAsync();
                }

                // ৫ মিনিট পার হয়ে গেলে OTP expire
                if (expiresAt <= DateTime.UtcNow)
                {
                    await MarkOtpAsUsedAsync(
                        connection,
                        transaction,
                        otpId
                    );

                    transaction.Commit();

                    return OtpVerificationResult.Expired;
                }

                // সর্বোচ্চ ৫ বার ভুল OTP দেওয়া যাবে
                if (attemptCount >= MaximumAttempts)
                {
                    await MarkOtpAsUsedAsync(
                        connection,
                        transaction,
                        otpId
                    );

                    transaction.Commit();

                    return OtpVerificationResult
                        .TooManyAttempts;
                }

                bool otpIsCorrect =
                    PasswordHelper.VerifyPassword(
                        enteredOtp,
                        savedOtpHash
                    );

                if (!otpIsCorrect)
                {
                    int newAttemptCount =
                        attemptCount + 1;

                    bool maximumReached =
                        newAttemptCount >= MaximumAttempts;

                    string failedAttemptQuery = @"
                        UPDATE dbo.EmailOtps
                        SET AttemptCount = @AttemptCount,
                            IsUsed = @IsUsed
                        WHERE OtpId = @OtpId
                          AND IsUsed = 0;";

                    using SqlCommand failedCommand =
                        new SqlCommand(
                            failedAttemptQuery,
                            connection,
                            transaction
                        );

                    failedCommand.Parameters
                        .Add(
                            "@AttemptCount",
                            SqlDbType.Int)
                        .Value = newAttemptCount;

                    failedCommand.Parameters
                        .Add(
                            "@IsUsed",
                            SqlDbType.Bit)
                        .Value = maximumReached;

                    failedCommand.Parameters
                        .Add(
                            "@OtpId",
                            SqlDbType.Int)
                        .Value = otpId;

                    await failedCommand
                        .ExecuteNonQueryAsync();

                    transaction.Commit();

                    if (maximumReached)
                    {
                        return OtpVerificationResult
                            .TooManyAttempts;
                    }

                    return OtpVerificationResult.Invalid;
                }

                // সঠিক OTP একবার ব্যবহার হওয়ার পর বন্ধ করে দেবে
                await MarkOtpAsUsedAsync(
                    connection,
                    transaction,
                    otpId
                );

                transaction.Commit();

                return OtpVerificationResult.Success;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        // Registration-এর OTP send করার সহজ method
        public static Task SendRegistrationOtpAsync(
            string email)
        {
            return SendOtpAsync(
                email,
                OtpPurpose.Registration
            );
        }

        // Registration-এর OTP verify করার সহজ method
        public static Task<OtpVerificationResult>
            VerifyRegistrationOtpAsync(
                string email,
                string enteredOtp)
        {
            return VerifyOtpAsync(
                email,
                enteredOtp,
                OtpPurpose.Registration
            );
        }

        // Forgot Password-এর OTP send করার সহজ method
        public static Task SendForgotPasswordOtpAsync(
            string email)
        {
            return SendOtpAsync(
                email,
                OtpPurpose.ForgotPassword
            );
        }

        // Forgot Password-এর OTP verify করার সহজ method
        public static Task<OtpVerificationResult>
            VerifyForgotPasswordOtpAsync(
                string email,
                string enteredOtp)
        {
            return VerifyOtpAsync(
                email,
                enteredOtp,
                OtpPurpose.ForgotPassword
            );
        }

        private static string GenerateOtp()
        {
            int otpNumber =
                RandomNumberGenerator.GetInt32(
                    100000,
                    1000000
                );

            return otpNumber.ToString();
        }

        private static string NormalizeEmail(
            string email)
        {
            return email.Trim().ToLowerInvariant();
        }

        private static async Task MarkOtpAsUsedAsync(
            SqlConnection connection,
            SqlTransaction transaction,
            int otpId)
        {
            string updateQuery = @"
                UPDATE dbo.EmailOtps
                SET IsUsed = 1
                WHERE OtpId = @OtpId;";

            using SqlCommand command =
                new SqlCommand(
                    updateQuery,
                    connection,
                    transaction
                );

            command.Parameters
                .Add(
                    "@OtpId",
                    SqlDbType.Int)
                .Value = otpId;

            await command.ExecuteNonQueryAsync();
        }

        private static async Task
            InvalidateOtpSilentlyAsync(int otpId)
        {
            try
            {
                using SqlConnection connection =
                    DatabaseConnection.GetConnection();

                await connection.OpenAsync();

                string query = @"
                    UPDATE dbo.EmailOtps
                    SET IsUsed = 1
                    WHERE OtpId = @OtpId;";

                using SqlCommand command =
                    new SqlCommand(query, connection);

                command.Parameters
                    .Add(
                        "@OtpId",
                        SqlDbType.Int)
                    .Value = otpId;

                await command.ExecuteNonQueryAsync();
            }
            catch
            {
                // মূল Email sending error-টি যেন হারিয়ে না যায়
            }
        }
    }
}