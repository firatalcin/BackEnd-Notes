namespace _1_SingleResponsibility
{
	public class ProductRepository
	{
		private static List<Product> products = new List<Product>();

		public List<Product> GetProducts => products;

		public ProductRepository()
		{
			products = new(){
				 new Product() { Id = 1, Name = "Kalem1" },
				 new Product() { Id = 2, Name = "Kalem2" },
				 new Product() { Id = 3, Name = "Kalem3" },
				 new Product() { Id = 4, Name = "Kalem4" },
				 new Product() { Id = 5, Name = "Kalem5" }
				 };

		}


		public void SaveOrUpdate(Product product)
		{
			var hasProduct = products.Any(p => p.Id == product.Id);

			if (!hasProduct)
			{
				products.Add(product);
			}
			else
			{
				var index = products.FindIndex(x => x.Id == product.Id);

				products[index] = product;
			}
		}

		public void Delete(int id)
		{
			var hasProduct = products.Find(p => p.Id == id);

			if (hasProduct == null)
			{
				throw new Exception("Ürün bulunamadı");
			}

			if (hasProduct != null)
			{
				products.Remove(hasProduct);
			}
		}
	}
}
