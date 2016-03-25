namespace WebApplication.Library.Interface
{
    public class Observer : IObserver
    {
        private string _AssemblyName;

        public Observer(string observerName)
        {
            _AssemblyName = observerName;
        }
        public void Update(string s)
        {
            System.Diagnostics.Debug.WriteLine(_AssemblyName+": " +s);
        }
    }
}