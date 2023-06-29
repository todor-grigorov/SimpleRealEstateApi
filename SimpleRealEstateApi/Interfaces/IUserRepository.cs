using SimpleRealEstateApi.Models;

namespace SimpleRealEstateApi.Interfaces
{
    public interface IUserRepository
    {
        User? GetUser(string email);
        User? GetUserByEmailAndPassword(string email, string password);
        bool CreateUser(User user);
        bool UserExistsById(int id);
        bool Save();
    }
}
