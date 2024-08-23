using BlogApp.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Web.Data.Concrete.EFCore
{
    public static class SeedData
    {
        public static void LoadToSeedData(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag { Text = "web programlama" },
                        new Tag { Text = "backend" },
                        new Tag { Text = "frontend" },
                        new Tag { Text = "fullstack" },
                        new Tag { Text = "php" }
                        );
                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { UserName = "firatalcin" },
                        new User { UserName = "sadikturan" }
                        );
                    context.SaveChanges();
                }

                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post
                        {
                            Title = "Asp.Net Core",
                            Content = "Asp.Net Core Dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            UserId = 1
                        },
                        new Post
                        {
                            Title = "Php",
                            Content = "Php Dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-20),
                            Tags = context.Tags.Take(3).ToList(),
                            UserId = 1
                        },
                        new Post
                        {
                            Title = "Django",
                            Content = "Django Dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-5),
                            Tags = context.Tags.Take(4).ToList(),
                            UserId = 2
                        }
                        );
                    context.SaveChanges();
                }
            }
        }
    }
}
