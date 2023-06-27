using SimpleRealEstateApi.Models;

namespace SimpleRealEstateApi.Interfaces
{
    public interface IUserRepository
    {
        bool CreateUser(User user);
        User? UserExistsByEmail(string email);
        bool UserExistsById(int id);
        bool Save();
    }
}
