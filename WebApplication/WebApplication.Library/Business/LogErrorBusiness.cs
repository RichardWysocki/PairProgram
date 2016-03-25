using WebApplication.Library.DataAccess;
using WebApplication.Library.Models;

namespace WebApplication.Library.Business
{
    public static class LogErrorBusiness
    {

        /* General Variable Declarations */
        public static LogErrorDA _dac = new LogErrorDA();

        public static bool AddLogError(LogError newLogError)
        {
            bool returnvalue;
            returnvalue = _dac.LogError_Insert(newLogError);
            return returnvalue;
        }

        public static bool AddLogError(
            string _logErrorMethod,
            string _logErrorMessage,
            string _logErrorSource
            )
        {
            bool returnvalue;

            LogError addError = new LogError();
            addError.LogErrorMethod = _logErrorMethod;
            addError.LogErrorMessage = _logErrorMessage;
            addError.LogErrorSource = _logErrorSource;

            returnvalue = _dac.LogError_Insert(addError);
            return returnvalue;
        }
    }
}
