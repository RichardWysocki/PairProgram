using System;
using System.Data;
using System.Data.SqlClient;
using WebApplication.Library.Models;

namespace WebApplication.Library
{
    public class LogErrorDA
    {
        public bool LogError_Insert(LogError InsertLogError)
        {
            bool insertSuccessful = true;

            SqlCommand cmd = ConfigSettings.DBCmd;
            cmd.Parameters.Clear();
            cmd.CommandText = "LogError_Insert";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlTransaction transaction;
            // Start a local transaction.
            transaction = cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted, "LogError_Insert");
            cmd.Transaction = transaction;
            try
            {
                cmd.Parameters.Add("@LogErrorMethod", SqlDbType.Text, 50);
                cmd.Parameters.Add("@LogErrorMessage", SqlDbType.Text, 4000);
                cmd.Parameters.Add("@LogErrorSource", SqlDbType.Text, 4000);

                cmd.Parameters["@LogErrorMethod"].Value = InsertLogError.LogErrorMethod;
                cmd.Parameters["@LogErrorMessage"].Value = InsertLogError.LogErrorMessage;
                cmd.Parameters["@LogErrorSource"].Value = InsertLogError.LogErrorSource;

                cmd.Parameters.Add("@RETURNVALUE", SqlDbType.Int);
                cmd.Parameters["@RETURNVALUE"].Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();
                transaction.Commit();
                int ReturnValue = int.Parse(cmd.Parameters["@RETURNVALUE"].Value.ToString());

                if (ReturnValue < 0)
                {
                    insertSuccessful = false;
                    throw new Exception("Error Text Added to the Database: " + ReturnValue.ToString());

                }
                //else
                //{
                //    EMail sendEmail = new EMail();
                //    EMail.Send("RichardWysocki@gmail.com", "RichardWysocki@gmail.com", "RichardWysocki@gmail.com", "RichardWysocki@gmail.com", "Wysocki-Richard@aramark.com");
                //}
            }
            catch (Exception e)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (SqlException ex)
                {
                    if (transaction.Connection != null)
                    {
                        Console.WriteLine("An exception of type " + ex.GetType() +
                            " was encountered while attempting to roll back the transaction.");
                    }
                }

                Console.WriteLine("An exception of type " + e.GetType() +
                    " was encountered while inserting the data.");
                Console.WriteLine("Neither record was written to database.");
                insertSuccessful = false;
            }
            return insertSuccessful;

        }
    }
}
