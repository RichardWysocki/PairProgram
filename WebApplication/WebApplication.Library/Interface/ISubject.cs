namespace WebApplication.Library.Interface
{
    public interface ISubject
    {
        void Add(IObserver o);
        void Remove(IObserver o);
        void NotifyObserver();

    }

    public interface IObserver
    {        
        void Update(string s);
    }
}
