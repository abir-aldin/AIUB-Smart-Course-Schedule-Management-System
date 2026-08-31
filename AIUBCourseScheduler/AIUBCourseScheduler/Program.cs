using AIUBCourseScheduler.DataAccess;
using AIUBCourseScheduler.Forms;

namespace AIUBCourseScheduler
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            try
            {
                DatabaseInitializer.EnsureRequiredTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Database initialization failed:\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }
            Application.Run(new LoginForm());
            //Application.Run(new RegisterForm());
            //Application.Run(new AdminMainForm());
            //Application.Run(new StudentMainForm());
            //            Application.Run(
            //    new OtpVerificationForm("testreceiver@gmail.com")
            //);
        }
    }
}