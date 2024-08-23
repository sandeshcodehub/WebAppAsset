using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppAsset.Models;
using WebAppAsset.Models.Entities;

namespace WebAppAsset.Data
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {            
        }
        public DbSet<MainCategory> MainCategories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Asset> Assets { get; set; }

    }
}
