using EFCore.Query.Data.Context;
using EFCore.Query.Data.Entities;
using Microsoft.EntityFrameworkCore;

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

            //var query = context.Blogs.AsQueryable();

            //var blogs1 = query.Where(x => x.Title.Contains("Blog 1") || x.Title.Contains("Blog 2")).AsEnumerable();

            //var blogs2 = blogs1.Where(x => x.Title.Contains("Blog 1"));

            //foreach (var item in blogs2)
            //{
            //    Console.WriteLine(item.Title);
            //}

            //var updatedBlog = context.Blogs.FirstOrDefault(x => x.Id == 1);

            //updatedBlog.Title = "Güncellendi";

            //var updatedBlogState = context.Entry(updatedBlog).State;

            //context.SaveChanges();

            //var updatedBlog = context.Blogs.AsNoTracking().FirstOrDefault(x => x.Id == 2);

            //updatedBlog.Title = "Güncellendi";

            //var updatedBlogState = context.Entry(updatedBlog).State;

            //context.SaveChanges();


            //lazy, eager, explicit

            //var blogs =context.Blogs.Include(x => x.Comments).ToList();

            //foreach (var blog in blogs)
            //{
            //    Console.WriteLine($"{blog.Title} blogun yorumları");
            //    foreach (var comment in blog.Comments)
            //    {
            //        Console.WriteLine($"     {comment.Content}");
            //    }
            //}

            var blog = context.Blogs.SingleOrDefault(x => x.Id == 1);

            context.Entry(blog).Collection(x => x.Comments).Load();


            Console.WriteLine("Hello, World!");
        }
    }
}
