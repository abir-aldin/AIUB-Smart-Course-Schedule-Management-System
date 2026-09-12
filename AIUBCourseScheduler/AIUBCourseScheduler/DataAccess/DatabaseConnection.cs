using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIUBCourseScheduler.DataAccess
{
    internal class DatabaseConnection
    {
        private const string ConnectionString = @"
                Server = (localdb)\MSSQLLocalDB;
                Database = AIUBCourseScheduleDB;
                Integrated Security = True;
                TrustServerCertificate = True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
