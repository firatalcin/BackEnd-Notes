using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static readonly string[] Products = new []
        {
            "IPhone X", "IPhone 16 Pro", "IPhone 16 Pro Plus",
        };
        
        [HttpGet]
        public string[] GetProducts()
        {
            return Products;
        }
        
        [HttpGet("{id}")]
        public string GetProduct(int id)
        {
            return Products[id];
        }
    }
}
