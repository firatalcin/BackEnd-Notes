using BlogApp.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete
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
                        new Entity.Tag { Text = "web programlama" },
                        new Entity.Tag { Text = "backend" },
                        new Entity.Tag { Text = "frontend" },
                        new Entity.Tag { Text = "fullstack" },
                        new Entity.Tag { Text = "php" }
                        );
                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new Entity.User { UserName = "firatalcin" },
                        new Entity.User { UserName = "sadikturan" }
                        );
                    context.SaveChanges();
                }

                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Entity.Post
                        {
                            Title = "Asp.Net Core",
                            Content = "Asp.Net Core Dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            UserId = 1
                        },
                        new Entity.Post
                        {
                            Title = "Php",
                            Content = "Php Dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-20),
                            Tags = context.Tags.Take(3).ToList(),
                            UserId = 1
                        },
                        new Entity.Post
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
