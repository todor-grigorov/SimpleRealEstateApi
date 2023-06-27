using SimpleRealEstateApi.Models;

namespace SimpleRealEstateApi.Interfaces
{
    public interface IUserRepository
    {
        User GetUser();
        bool Register(User user);
        bool Save();
    }
}
