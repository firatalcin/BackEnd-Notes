using DataAccess.Context;
using DataAccess.Models;

namespace StartConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext db = new AppDbContext();
            IList<Product> products = new List<Product>();


            for (int i = 0; i < 1000000; i++) {

                Product product = new Product()
                {
                    Name = "Product " + i
                };

                products.Add(product);
            }

            db.Products.AddRange(products);

            db.SaveChanges();
        }
    }
}
