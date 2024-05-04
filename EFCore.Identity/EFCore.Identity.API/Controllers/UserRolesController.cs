using EFCore.Identity.API.Context;
using EFCore.Identity.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EFCore.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public UserRolesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid userId, Guid roleId, CancellationToken cancellationToken)
        {
            AppUserRole appUserRole = new()
            {
                RoleId = roleId,
                UserId = userId
            };

            await _appDbContext.UserRoles.AddAsync(appUserRole);

            await _appDbContext.SaveChangesAsync(cancellationToken);
            
            return NoContent(); 
        }
    }
}
