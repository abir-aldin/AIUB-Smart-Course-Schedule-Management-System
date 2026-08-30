using System.Security.Cryptography;

namespace AIUBCourseScheduler.Services
{
    public static class PasswordHelper
    {
        private const int Iterations = 100000;

        public static string HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                Iterations,
                HashAlgorithmName.SHA256,
                32
            );

            return $"{Iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
        }

        public static bool VerifyPassword(string password, string savedPassword)
        {
            try
            {
                string[] parts = savedPassword.Split('.');

                int iterations = int.Parse(parts[0]);
                byte[] salt = Convert.FromBase64String(parts[1]);
                byte[] savedHash = Convert.FromBase64String(parts[2]);

                byte[] newHash = Rfc2898DeriveBytes.Pbkdf2(
                    password,
                    salt,
                    iterations,
                    HashAlgorithmName.SHA256,
                    32
                );

                return CryptographicOperations.FixedTimeEquals(
                    newHash,
                    savedHash
                );
            }
            catch
            {
                return false;
            }
        }
    }
}