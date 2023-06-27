using SimpleRealEstateApi.Models;

namespace SimpleRealEstateApi.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(int id);
        bool CreateUser(User user);
        bool UserExists(int id);
        bool Save();
    }
}
