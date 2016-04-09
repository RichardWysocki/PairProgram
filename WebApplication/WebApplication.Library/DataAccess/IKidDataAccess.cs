using WebApplication.Library.Models;

namespace WebApplication.Library.DataAccess
{
    public interface IKidDataAccess
    {
        bool Insert(Kid kid);
        bool Update(Kid updateKid);
        bool Delete(int deleteId);
    }
}