using System;
using System.Data.SqlClient;

namespace WebApplication.Library.Utilities
{
    public class TestHelperUtility
    {
        public static int ExecuteInsert(string insertSql)
        {
            var queryString = insertSql + "SELECT SCOPE_IDENTITY()";
            using (SqlConnection connection = ConfigSettings.DBConn)
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                var primaryKey = Convert.ToInt32(command.ExecuteScalar());
                return primaryKey;
            }
        }

        public static int Execute(string insertSql)
        {
            using (SqlConnection connection = ConfigSettings.DBConn)
            {
                SqlCommand command = new SqlCommand(insertSql, connection);
                var primaryKey = Convert.ToInt32(command.ExecuteScalar());
                return primaryKey;
            }
        }

        public static bool Delete(string deleteSql)
        {
            using (SqlConnection connection = ConfigSettings.DBConn)
            {
                SqlCommand command = new SqlCommand(deleteSql, connection);

                var rows = Convert.ToInt32(command.ExecuteNonQuery());
                return rows>0;
            }
        }
    }
}