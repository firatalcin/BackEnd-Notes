using System.Xml.Linq;

namespace MyAspNetCoreApp.Web.Models
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>()
        {

                new Product() { Id = 1, Name = "Kalem 1", Price = 100, Stock = 200 },
                new Product() { Id = 2, Name = "Kalem 2", Price = 200, Stock = 300 },
                new Product() { Id = 3, Name = "Kalem 3", Price = 300, Stock = 400 }
        };



        public List<Product> GetAll()
        {
            return _products;
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Remove(int id)
        {
            var hasProduct = _products.FirstOrDefault(p => p.Id == id);

            if (hasProduct == null)
            {
                throw new Exception($"Bu id({id})'ye sahip ürün bulunmamaktadır");
            }

            _products.Remove(hasProduct);
        }

        public void Update(Product product)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == product.Id);

            if (hasProduct != null)
            {
                throw new Exception($"Bu id({product.Id})'ye sahip ürün bulunmamaktadır");
            }

            hasProduct.Name = product.Name;
            hasProduct.Price = product.Price;
            hasProduct.Stock = product.Stock;

            var index = _products.FindIndex(x => x.Id == product.Id);
            _products[index] = hasProduct;
        }

        public Product GetById(int id)
        {
            var value = _products.FirstOrDefault(x => x.Id == id);

            return value;
        }
    }
}
