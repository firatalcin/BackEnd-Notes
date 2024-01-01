using DataAccess.Context;
using DataAccess.Models;

namespace IQueryable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new AppDbContext();

            IQueryable<Product> products = context.Products.AsQueryable();

            IList<Product> productsList = products.Where(x => x.Id > 990000).ToList();
        }
    }
}
