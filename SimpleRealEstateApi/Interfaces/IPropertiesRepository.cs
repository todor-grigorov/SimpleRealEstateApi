using SimpleRealEstateApi.Models;

namespace SimpleRealEstateApi.Interfaces
{
    public interface IPropertiesRepository
    {
        ICollection<Property> GetProperties();
        Property? GetProperty(int id);
        Property GetPropertyByCategory(int categoryId);
        ICollection<Property> GetTrendingProperties();
        ICollection<Property> GetSearchProperties(string address);
        bool CreateProperty(int userId, Property property);
        bool UpdateProperty(int userId, Property property);
        bool DeleteProperty(int id);
        bool PropertyExists(int id);
        bool Save();
    }
}
