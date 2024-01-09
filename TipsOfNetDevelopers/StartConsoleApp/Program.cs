using DataAccess.Context;
using DataAccess.Models;

namespace StartConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext db = new AppDbContext();

            IList<Category> categories = new List<Category>();

            for (int i = 0; i < 10; i++)
            {
                Category category = new Category()
                {
                    Name = "Category " + i
                };

                categories.Add(category);
            }


            IList<Product> products = new List<Product>();


            for (int i = 0; i < 1000000; i++) {

                Random rand = new Random();

                Product product = new Product()
                {
                    Name = "Product " + i,
                    CategoryId = rand.Next(1, 9)
                };

                products.Add(product);
            }
            db.Categories.AddRange(categories);
            db.Products.AddRange(products);

            db.SaveChanges();
        }
    }
}
