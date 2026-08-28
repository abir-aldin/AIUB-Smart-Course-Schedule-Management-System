using Microsoft.Data.SqlClient;

namespace AIUBCourseScheduler.DataAccess
{
    public static class DatabaseConnection
    {
        private const string ConnectionString =
            @"Server=.\SQLEXPRESS;
              Database=AIUBCourseScheduleDB;
              Integrated Security=True;
              TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}