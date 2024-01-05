using DataAccess.Context;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PerformansLogWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            AppDbContext context = new AppDbContext();
            IList<PerformanceLog> performanceLogs =
                await context.PerformanceLogs
                .OrderByDescending(p => p.Id)
                .ToListAsync(cancellationToken);

            return Ok(performanceLogs);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            AppDbContext context = new AppDbContext();
            IList<Product> products =
                await context.Products
                .ToListAsync(cancellationToken);

            return Ok(products.Take(10));
        }

    }
}
