namespace AIUBCourseScheduler.Services
{
    public static class UserSession
    {
        public static int UserId { get; private set; }

        public static string FullName { get; private set; }
            = string.Empty;

        public static string StudentId { get; private set; }
            = string.Empty;

        public static string Email { get; private set; }
            = string.Empty;

        public static string UserRole { get; private set; }
            = string.Empty;

        public static bool IsLoggedIn =>
            UserId > 0;

        public static void Start(
            int userId,
            string fullName,
            string studentId,
            string email,
            string userRole)
        {
            UserId = userId;
            FullName = fullName;
            StudentId = studentId;
            Email = email;
            UserRole = userRole;
        }

        public static void Clear()
        {
            UserId = 0;
            FullName = string.Empty;
            StudentId = string.Empty;
            Email = string.Empty;
            UserRole = string.Empty;
        }
    }
}