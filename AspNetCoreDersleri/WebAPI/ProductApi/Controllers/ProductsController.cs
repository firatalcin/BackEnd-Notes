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
        public List<Product> GetProducts()
        {
            return _products;
        }
        
        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
    }
}
