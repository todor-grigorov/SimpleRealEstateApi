using SimpleRealEstateApi.Models;

namespace SimpleRealEstateApi.Interfaces
{
    public interface IPropertiesRepository
    {
        ICollection<Property> GetProperties();
        Property? GetProperty(int id);
        ICollection<Property> GetPropertiesByCategory(int categoryId);
        ICollection<Property> GetTrendingProperties();
        ICollection<Property> GetSearchProperties(string address);
        bool CreateProperty(int userId, Property property);
        bool UpdateProperty(int userId, Property property);
        bool DeleteProperty(Property property);
        bool PropertyExists(int id);
        bool Save();
    }
}
