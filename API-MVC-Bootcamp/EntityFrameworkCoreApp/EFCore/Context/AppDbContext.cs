using EFCore.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=MAKINA\\SQLEXPRESS01; database= UdemyEFCore; integrated security=true;TrustServerCertificate=True");
        }
    }
}
