using SimpleRealEstateApi.Models;

namespace SimpleRealEstateApi.Interfaces
{
    public interface IUserRepository
    {
        User GetUser();
        bool CreateUser(User user);
        bool Save();
    }
}
