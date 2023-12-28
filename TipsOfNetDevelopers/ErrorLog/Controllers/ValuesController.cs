using DataAccess.Context;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ErrorLog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult Calculate(int x, int y) 
        {
            int result = x / y;
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetErrorLogs()
        {
            AppDbContext db = new AppDbContext();
            IList<DataAccess.Models.ErrorLog> errorLogs = await db.ErrorLoggers.OrderByDescending(p => p.CreatedDate).ToListAsync();
            return Ok(errorLogs);
        }
    }
}
