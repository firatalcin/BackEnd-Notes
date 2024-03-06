using EFCore.Query.Data.Configurations;
using EFCore.Query.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Query.Data.Context
{
    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=MAKINA\\SQLEXPRESS01; database= UdemyEFCoreQuery; integrated security=true;TrustServerCertificate=True");
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
        }
    }
}
