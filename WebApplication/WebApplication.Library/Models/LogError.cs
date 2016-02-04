using System;
using System.Runtime.Serialization;

namespace WebApplication.Library.Models
{
    [Serializable]
    [DataContract]
    public class LogError : ILogError
    {
        int    _logErrorID;
        string _logErrorMethod;
        string _logErrorMessage;
        string _logErrorSource;

        public LogError()
        {
        }

        public LogError(
            int logErrorID,
            string logErrorMethod,
            string logErrorMessage,
            string logErrorSource
            )
        {
            _logErrorID = logErrorID;
            _logErrorMethod = logErrorMethod;
            _logErrorMessage = logErrorMessage;
            _logErrorSource = logErrorSource;
        }


        [DataMember]
        public int LogErrorID
        {
            get { return _logErrorID; }
            set { _logErrorID = value; }
        }
        [DataMember]
        public string LogErrorMethod
        {
            get { return _logErrorMethod; }
            set { _logErrorMethod = value; }
        }
        [DataMember]
        public string LogErrorMessage
        {
            get { return _logErrorMessage; }
            set { _logErrorMessage = value; }
        }
        [DataMember]
        public string LogErrorSource
        {
            get { return _logErrorSource; }
            set { _logErrorSource = value; }
        }
    }
}
