﻿using EFCore.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SaleHistory> SaleHistories { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }
        public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=MAKINA\\SQLEXPRESS01; database= UdemyEFCore; integrated security=true;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(x => new { x.Number, x.Name });

            modelBuilder.Entity<Product>().Property(x => x.Name).HasColumnName("product_name");
            modelBuilder.Entity<Product>().Property(x => x.Name).HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Product>().HasIndex(x => x.Name).IsUnique(true);
            modelBuilder.Entity<Product>().Property(x => x.CreateDate).HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Product>().Property(x => x.Id).HasColumnName("product_id");
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnName("product_price");
            modelBuilder.Entity<Product>().Property(x => x.Price).HasPrecision(18, 3);

            //modelBuilder.Entity<Product>().HasMany(x => x.SaleHistories).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
            modelBuilder.Entity<SaleHistory>()
                .HasOne(x => x.Product)
                .WithMany(x => x.SaleHistories)
                .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<Product>()
                .HasOne(x => x.ProductDetail)
                .WithOne(x => x.Product)
                .HasForeignKey<ProductDetail>(x => x.ProductId);

            modelBuilder.Entity<Product>()
                .HasMany(x => x.ProductCategories)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<Category>()
                .HasMany(x => x.ProductCategories)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<ProductCategory>().HasKey(x => new { x.ProductId, x.CategoryId });

        }
    }
}
