using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication.Library
{
    public class LogFile
    {
        private string _errorSource;
        private string _errorText;

        public string ErrorSource
        {
            get
            {
                return _errorSource;
            }
            set
            {
                _errorSource = value;
            }
        }
        public string ErrorText
        {
            get
            {
                return _errorText;
            }
            set
            {
                _errorText = value;
            }
        }

        public static void AppendToFile(string appendText)
        {
            if (ConfigSettings.WriteLogFile == "True")
            {
                StreamWriter SW;
                SW = File.AppendText(ConfigSettings.LogFile);
                SW.WriteLine(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "     " + appendText);
                SW.Close();
                //Console.WriteLine("Text Appended Successfully");

            }
        }

        public void AppendtoDB()
        {
            if (_errorText.Length > 0)
            {
                DbErrorLog(_errorSource, _errorText);
            }
            else
            {
                throw new Exception("ErrorText is empty");
            }
        }

        public static void AppendtoDB(string dbErrorSource, string appendText)
        {
            AppendToFile(dbErrorSource.PadRight(50) + " -> " + appendText);
            LogFile addLog = new LogFile();
            addLog.DbErrorLog(dbErrorSource,appendText);
        }

        public void DbErrorLog(string dbErrorSource, string dbErrorText)
        {
           SqlCommand cmd = ConfigSettings.DBCmd;
           cmd.Parameters.Clear();
           cmd.CommandText = "ErrorLog_Insert";
           cmd.CommandType = CommandType.StoredProcedure;

           cmd.Parameters.Add("@ErrorSource", SqlDbType.Text,100);
           cmd.Parameters.Add("@ErrorText", SqlDbType.Text,4000);
           cmd.Parameters["@ErrorSource"].Value = dbErrorSource;
           cmd.Parameters["@ErrorText"].Value = DateTime.Now.ToLongTimeString() + "     " + dbErrorText;

           cmd.Parameters.Add("@RETURNVALUE", SqlDbType.Int);
           cmd.Parameters["@RETURNVALUE"].Direction = ParameterDirection.ReturnValue;

           cmd.ExecuteNonQuery();

           int returnValue = int.Parse(cmd.Parameters["@RETURNVALUE"].Value.ToString());

           if (returnValue < 0)
           {
               throw new Exception("Error Text Added to the Database: " + returnValue.ToString());
           }
        }
    }
}
