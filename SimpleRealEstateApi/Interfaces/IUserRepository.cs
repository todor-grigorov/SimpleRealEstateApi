using SimpleRealEstateApi.Models;

namespace SimpleRealEstateApi.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);
        bool CreateUser(User user);
        bool UserExistsByEmail(string email);
        bool UserExistsById(int id);
        bool Save();
    }
}
