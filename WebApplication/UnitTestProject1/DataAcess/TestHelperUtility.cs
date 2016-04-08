using System;
using System.Data.SqlClient;
using WebApplication.Library;

namespace WebApplication.Tests.DataAcess
{
    public class TestHelperUtility
    {
        public static int ExecuteInsert(string Insert)
        {
            int returnValue;
            string queryString = Insert + "SELECT SCOPE_IDENTITY()";
            //using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlConnection connection = ConfigSettings.DBConn)
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                //connection.Open();

                var primaryKey = Convert.ToInt32(command.ExecuteScalar());
                //SqlDataReader reader = command.ExecuteReader();
                //try
                //{
                //    while (reader.Read())
                //    {
                //        Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
                //    }
                //}
                //finally
                //{
                //    // Always call Close when done reading.
                //    reader.Close();
                //}
                return primaryKey;
            }
        }

        public static int Execute(string Insert)
        {
            int returnValue;
            string queryString = Insert;
            //using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlConnection connection = ConfigSettings.DBConn)
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                //connection.Open();

                var primaryKey = Convert.ToInt32(command.ExecuteScalar());
                return primaryKey;
            }
        }

        public static bool Delete(string deleteSQL)
        {
            string queryString = deleteSQL;
            using (SqlConnection connection = ConfigSettings.DBConn)
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                //connection.Open();

                var rows = Convert.ToInt32(command.ExecuteNonQuery());
                return rows>0 ? true : false;
            }
        }
    }
}