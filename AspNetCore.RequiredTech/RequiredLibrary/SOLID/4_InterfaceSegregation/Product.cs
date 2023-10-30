using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_InterfaceSegregation
{
	public class Product
	{
        public int Id { get; set; }
        public string Name { get; set; }
    }

	public class ProductRead : IProductRepositoryRead
	{
		public List<Product> GetAll()
		{
			throw new NotImplementedException();
		}

		public Product GetById(int id)
		{
			throw new NotImplementedException();
		}
	}

	public class ProductWrite : IProductRepositoryWrite
	{
		public Product Create(Product p)
		{
			throw new NotImplementedException();
		}

		public Product Delete(Product p)
		{
			throw new NotImplementedException();
		}

		public Product Update(Product p)
		{
			throw new NotImplementedException();
		}
	}

	public interface IProductRepositoryRead
	{
		List<Product> GetAll();
		Product GetById(int id);
	}

	public interface IProductRepositoryWrite
	{
		Product Create(Product p);
		Product Update(Product p);
		Product Delete(Product p);
	}
}
