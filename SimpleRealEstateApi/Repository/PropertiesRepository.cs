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

        public Property CreateProperty(Property property)
        {
            throw new NotImplementedException();
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

        public Property UpdateProperty(Property property)
        {
            throw new NotImplementedException();
        }
    }
}
