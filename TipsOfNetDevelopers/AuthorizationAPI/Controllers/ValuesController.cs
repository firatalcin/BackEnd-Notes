using AuthorizationAPI.Attributes;
using DataAccess.Context;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        AppDbContext db  = new AppDbContext();

        [HttpGet("[action]")]
        public async Task<IActionResult> Get(string userName, CancellationToken cancellationToken)
        {
            User? user = await db.Users.Where(p => p.UserName == userName).FirstOrDefaultAsync(cancellationToken);

            string token = JwtProvider.CreateToken(user);
            return Ok(new { Token = token });
        }

        [RoleAttibute("GetAll")]
        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetAll()
        {
            IList<string> list = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                list.Add("Name " + i);
            }

            return Ok(list);    
        }
    }
}
