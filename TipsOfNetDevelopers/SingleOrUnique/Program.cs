using DataAccess.Context;
using DataAccess.Models;

namespace SingleOrUnique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new AppDbContext();

            Product product1 = context.Products.Where(x => x.Name == "Product 0").FirstOrDefault();

            Product product2 = context.Products.Where(x => x.Name == "Product 0").SingleOrDefault();

            Console.WriteLine("Hello, World!");
        }
    }
}
