using DataAccess.Context;
using DataAccess.Models;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace Pagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        AppDbContext _context = new AppDbContext();

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize)
        {
            //PaginationDto<Product> result = new PaginationDto<Product>();

            //IList<Product> products =
            //    _context.Products
            //    .Skip((pageNumber - 1) * pageSize)
            //    .Take(pageSize)
            //    .ToList();

            //int count = _context.Products.Count();

            //result.PageNumber = pageNumber;
            //result.PageSize = pageSize;
            //result.IsFirstPage = pageNumber == 1 ? true : false;
            //result.Datas = products;
            //result.TotalPageCount = (int)Math.Ceiling(count / (double)pageSize);
            //result.IsLastPage = pageNumber == result.TotalPageCount ? true : false;

            //return Ok(result);

            PaginationResult<Product> result = await _context.Products.ToPagedListAsync(pageNumber, pageSize);

            return Ok(result);
        }
    }
}
