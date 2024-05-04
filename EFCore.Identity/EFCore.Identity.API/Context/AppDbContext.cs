using EFCore.Identity.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Identity.API.Context
{
    public class AppDbContext : 
        IdentityDbContext
        <
        AppUser, 
        AppRole, 
        Guid, 
        IdentityUserClaim<Guid>,
        AppUserRole,
        IdentityUserLogin<Guid>,
        IdentityRoleClaim<Guid>,
        IdentityUserToken<Guid>
        >
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
