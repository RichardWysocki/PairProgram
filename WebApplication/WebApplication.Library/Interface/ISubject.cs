using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
