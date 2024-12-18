using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> _products;

        public ProductsController()
        {
            _products = new List<Product>()
            {
                new Product(){Id = 1, Name = "IPhone X", Price = 60000, Status = true},
                new Product(){Id = 2, Name = "IPhone 16", Price = 90000, Status = true},
                new Product(){Id = 3, Name = "IPhone 16 Pro Plus", Price = 10000, Status = true},
            };
        }
        
        [HttpGet]
        public IActionResult GetProducts()
        {
            if (_products == null)
            {
                return NotFound();
            }
            return Ok(_products);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var product = _products?.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();  
            }
            
            return Ok(product);
        }
    }
}
