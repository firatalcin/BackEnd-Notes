using EFCore.Identity.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name, CancellationToken cancellationToken)
        {
            AppRole appRole = new()
            {
                Name = name
            };

            IdentityResult result =  await _roleManager.CreateAsync(appRole);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x => x.Description));
            }

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return Ok(roles);
        }
    }
}
