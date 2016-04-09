using System.Data;
using System.Data.SqlClient;

namespace WebApplication.Library.DataAccess
{
    public class DBUtility
    {
        public static SqlCommand SqlCommand(string storedProcedure)
        {
            SqlCommand cmd = ConfigSettings.DBCmd;
            cmd.Parameters.Clear();
            cmd.CommandText = storedProcedure;
            cmd.CommandType = CommandType.StoredProcedure;

            return cmd;
        }
    }
}