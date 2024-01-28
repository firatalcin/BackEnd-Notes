using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AuthorizationAPI.Attributes
{
    public sealed class RoleAttibute : Attribute, IAuthorizationFilter
    {
        private readonly string _role;

        public RoleAttibute(string role)
        {
            _role = role;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            AppDbContext _context = new AppDbContext();

            var userIdClaim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var userHasRole = _context.UserRoles
                .Where(p => p.UserId == Convert.ToInt32(userIdClaim.Value))
                .Include(p => p.Role)
                .Any(p => p.Role.Name == _role);

            if (!userHasRole)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}
