using WebUI.Models;

namespace WebUI.FakeDb
{
    public static class Repository
    {
        private static readonly List<Product> _products = new List<Product>();
        private static readonly List<Category> _categories = new List<Category>();

        static Repository()
        {
            _categories.Add(new Category { Id=1, Name = "Telefon"});
            _categories.Add(new Category { Id = 2, Name = "Bilgisayar" });

            _products.Add(new Product { Id = 1, Name = "IPhone 14", Price = 40000, IsActive = true, Image = "1.jpg", CategoryId = 1 });
            _products.Add(new Product { Id = 2, Name = "IPhone 15", Price = 50000, IsActive = true, Image = "2.jpg", CategoryId = 1 });
            _products.Add(new Product { Id = 3, Name = "IPhone 16", Price = 60000, IsActive = true, Image = "3.jpg", CategoryId = 1 });
            _products.Add(new Product { Id = 4, Name = "IPhone 17", Price = 70000, IsActive = true, Image = "4.jpg", CategoryId = 1 });


            _products.Add(new Product { Id = 5, Name = "Macbook Air", Price = 80000, IsActive = true, Image = "5.jpg", CategoryId = 2 });
            _products.Add(new Product { Id = 6, Name = "Macbook Pro", Price = 90000, IsActive = true, Image = "6.jpg", CategoryId = 2 });

        }

        public static List<Product> GetProductList()
        {
            return _products;
        }

        public static List<Category> GetCategoryList()
        {
            return _categories;
        }

        public static void CreateProduct(Product entity)
        {
            _products.Add(entity);
        }
    }
}
