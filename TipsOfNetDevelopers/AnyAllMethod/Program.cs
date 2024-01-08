using DataAccess.Context;

namespace AnyAllMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new AppDbContext();

            bool result = context.Products.Any();

            bool result2 = context.Products.Any(p => p.Name == "Product 1");

            bool result3 = context.Products.All(p => p.Name.Contains("P"));


        }
    }
}
