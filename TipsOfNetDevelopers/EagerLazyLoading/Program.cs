
using DataAccess.Context;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EagerLazyLoading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new AppDbContext();
            //Lazy Loading - Tembel Yükleme
            IList<Product> products = context.Products.ToList();

            //Eager Loading
            IList<Product> productsWithCategory = context.Products.Include(p => p.Category).ToList();
            Console.WriteLine("Hello, World!");
        }
    }
}
