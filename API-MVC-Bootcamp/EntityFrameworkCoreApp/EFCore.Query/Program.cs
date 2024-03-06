using EFCore.Query.Data.Context;
using EFCore.Query.Data.Entities;

namespace EFCore.Query
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new BlogContext();

            //for (int i = 1; i <= 100; i++)
            //{
            //    context.Add(new Blog
            //    {
            //        Title = $"Blog {i}",
            //        Url = $"firat.com/Blog-{i}"
            //    });
            //}

            //context.SaveChanges();


            //IEnumerable & IQueryable
            
            var query = context.Blogs.AsQueryable();

            var blogs1 = query.Where(x => x.Title.Contains("Blog 1") || x.Title.Contains("Blog 2")).AsEnumerable();

            var blogs2 = blogs1.Where(x => x.Title.Contains("Blog 1"));

            foreach (var item in blogs2)
            {
                Console.WriteLine(item.Title);
            }


            Console.WriteLine("Hello, World!");
        }
    }
}
