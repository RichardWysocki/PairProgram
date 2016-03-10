using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication.Library
{
    public class LogFile
    {

        private string _ErrorSource;
        private string _ErrorText;

        public string ErrorSource
        {
            get
            {
                return _ErrorSource;
            }
            set
            {
                _ErrorSource = value;
            }
        }
        public string ErrorText
        {
            get
            {
                return _ErrorText;
            }
            set
            {
                _ErrorText = value;
            }
        }

        public static void AppendToFile(string AppendText)
        {
            if (ConfigSettings.WriteLogFile == "True")
            {
                StreamWriter SW;
                SW = File.AppendText(ConfigSettings.LogFile);
                SW.WriteLine(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "     " + AppendText);
                SW.Close();
                //Console.WriteLine("Text Appended Successfully");

            }
        }
        public void AppendtoDB()
        {
            if (this._ErrorText.Length > 0)
            {
                DBErrorLog(this._ErrorSource, this._ErrorText);
            }
            else
            {
                throw new Exception("ErrorText is empty");
            }
        }
        public static void AppendtoDB(string dbErrorSource, string AppendText)
        {
            AppendToFile(dbErrorSource.PadRight(50) + " -> " + AppendText);
            LogFile addLog = new LogFile();
            addLog.DBErrorLog(dbErrorSource,AppendText);
        }
        public void DBErrorLog(string dbErrorSource, string dbErrorText)
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

           int ReturnValue = int.Parse(cmd.Parameters["@RETURNVALUE"].Value.ToString());

           if (ReturnValue < 0)
           {
               throw new Exception("Error Text Added to the Database: " + ReturnValue.ToString());
           }
        }

    }



}
