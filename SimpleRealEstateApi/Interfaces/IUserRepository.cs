using SimpleRealEstateApi.Models;

namespace SimpleRealEstateApi.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);
        bool CreateUser(User user);
        bool UserExistsById(int id);
        bool Save();
    }
}
