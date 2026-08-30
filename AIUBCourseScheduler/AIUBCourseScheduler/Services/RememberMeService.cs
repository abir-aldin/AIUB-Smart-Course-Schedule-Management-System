using System;
using System.IO;

namespace AIUBCourseScheduler.Services
{
    public static class RememberMeService
    {
        private static readonly string FolderPath =
            Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "AIUBCourseScheduler"
            );

        private static readonly string FilePath =
            Path.Combine(
                FolderPath,
                "remembered-user.txt"
            );

        public static void SaveIdentifier(
            string identifier)
        {
            Directory.CreateDirectory(FolderPath);

            File.WriteAllText(
                FilePath,
                identifier.Trim()
            );
        }

        public static string LoadIdentifier()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    return string.Empty;
                }

                return File
                    .ReadAllText(FilePath)
                    .Trim();
            }
            catch
            {
                return string.Empty;
            }
        }

        public static void Clear()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                }
            }
            catch
            {
                // Remembered identifier delete না হলেও
                // application বন্ধ হবে না
            }
        }
    }
}