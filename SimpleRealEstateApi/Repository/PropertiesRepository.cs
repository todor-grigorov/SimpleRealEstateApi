using SimpleRealEstateApi.Data;
using SimpleRealEstateApi.Interfaces;
using SimpleRealEstateApi.Models;

namespace SimpleRealEstateApi.Repository
{
    public class PropertiesRepository : IPropertiesRepository
    {
        private readonly ApiDbContext _context;

        public PropertiesRepository(ApiDbContext context)
        {
            _context = context;
        }


        public bool DeleteProperty(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Property> GetProperties()
        {
            throw new NotImplementedException();
        }

        public Property GetProperty(int id)
        {
            throw new NotImplementedException();
        }

        public Property GetPropertyByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Property> GetSearchProperties(string address)
        {
            throw new NotImplementedException();
        }

        public ICollection<Property> GetTrendingProperties()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool CreateProperty(int userId, Property property)
        {
            property.IsTrending = false;
            property.UserId = userId;
            _context.Properties.Add(property);
            return Save();
        }

        public bool UpdateProperty(Property property)
        {
            throw new NotImplementedException();
        }

    }
}
