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


        public bool DeleteProperty(Property property)
        {
            _context.Remove(property);
            return Save();
        }

        public ICollection<Property> GetProperties()
        {
            return _context.Properties.ToList();
        }

        public Property? GetProperty(int id)
        {
            return _context.Properties.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Property> GetPropertiesByCategory(int categoryId)
        {
            return _context.Properties.Where(p => p.CategoryId == categoryId).ToList();
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

        public bool UpdateProperty(int userId, Property property)
        {
            property.UserId = userId;
            _context.Properties.Update(property);
            return Save();
        }

        public bool PropertyExists(int id)
        {
            return _context.Properties.Any(p => p.Id == id);
        }
    }
}
