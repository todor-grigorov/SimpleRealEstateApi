using Microsoft.EntityFrameworkCore;
using SimpleRealEstateApi.Models;

namespace SimpleRealEstateApi.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RealEstateDb");
        }
    }
}
