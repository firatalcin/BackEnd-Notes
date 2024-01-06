using DataAccess.Context;
using DataAccess.Models;

namespace AsReadOnly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new AppDbContext();  
            IReadOnlyList<Product> products = context.Products.ToList().AsReadOnly();

            Console.WriteLine("Hello, World!");
        }
    }
}
