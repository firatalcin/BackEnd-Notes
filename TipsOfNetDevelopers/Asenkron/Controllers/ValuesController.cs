using DataAccess.Context;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asenkron.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetFirstAsync()
        {
            AppDbContext context = new AppDbContext();

            Product product = await context.Products.FirstOrDefaultAsync();
            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetFirst() 
        {
            AppDbContext context = new AppDbContext();

            Product product = context.Products.FirstOrDefault();
            return Ok(product);
        }
    }
}
