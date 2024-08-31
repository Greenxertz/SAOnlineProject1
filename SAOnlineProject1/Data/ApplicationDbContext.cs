using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SAOnlineProject1.Models;

namespace SAOnlineProject1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<ApplicationUser> applicationUser { get; set; }

        public DbSet<Product> Products { get; set; } 
        public DbSet<Inventory> inventories { get; set; } 
        public DbSet<PImages> PImages { get; set; } 
        public DbSet<UserCart> UserCarts { get; set; }

    }
}
