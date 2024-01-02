using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    //Sealed keyword'ü inherit edilemez demektir.
    public sealed class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.; database=TipsForNetDevelopers; Trusted_Connection=True; Integrated Security=true;trustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasIndex(x => x.Name).IsUnique();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ErrorLog> ErrorLoggers { get; set; }
    }
}
