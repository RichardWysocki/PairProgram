namespace WebApplication.Library.Models
{
    public interface ILogError
    {
        int LogErrorID { get; set; }
        string LogErrorMessage { get; set; }
        string LogErrorMethod { get; set; }
        string LogErrorSource { get; set; }
    }
}