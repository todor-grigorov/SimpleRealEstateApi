using SimpleRealEstateApi.Models;

namespace SimpleRealEstateApi.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(int id);
        bool CreateUser(User user);
        bool UserExistsById(int id);
        bool Save();
    }
}
