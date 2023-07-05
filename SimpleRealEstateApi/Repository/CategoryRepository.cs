using SimpleRealEstateApi.Data;
using SimpleRealEstateApi.Interfaces;
using SimpleRealEstateApi.Models;

namespace SimpleRealEstateApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApiDbContext _context;

        public CategoryRepository(ApiDbContext context)
        {
            _context = context;
        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
