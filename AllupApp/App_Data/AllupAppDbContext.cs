using AllupApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AllupApp.App_Data
{
    public class AllupAppDbContext : DbContext
    {
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public AllupAppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
