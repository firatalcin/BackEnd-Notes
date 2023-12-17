using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public sealed class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.; database=TipsForNetDevelopers; Trusted_Connection=True; Integrated Security=true;trustServerCertificate=true");
        }

        public DbSet<Product> Products { get; set; } 
    }
}
