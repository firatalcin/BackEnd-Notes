using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using IdentityApp.Web.Contexts;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Web.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "admin";
        private const string adminPassword = "Admin_123";

        public static async void IdentityTestUser(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

            if (context.Database.GetAppliedMigrations().Any())
            {
                context.Database.Migrate();
            }

            var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var user = await userManager.FindByNameAsync(adminUser);

            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = adminUser,
                    Email = "admin@gmail.com",
                    PhoneNumber = "44444444"
                };

                await userManager.CreateAsync(user, adminPassword);
            }
        }

    }
}
