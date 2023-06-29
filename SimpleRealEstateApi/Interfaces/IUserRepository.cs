using SimpleRealEstateApi.Models;

namespace SimpleRealEstateApi.Interfaces
{
    public interface IUserRepository
    {
        bool CreateUser(User user);
        User? GetUser(string email);
        bool UserExistsById(int id);
        bool Save();
    }
}
