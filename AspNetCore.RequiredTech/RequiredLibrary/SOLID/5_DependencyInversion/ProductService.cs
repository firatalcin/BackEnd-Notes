using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_DependencyInversion
{
	public class ProductService
	{
		private readonly IRepository _repository;

		public ProductService(IRepository repository)
		{
			_repository = repository;
		}

		public List<string> GetAll()
		{
			return _repository.GetAll();
		}
	}

	public class ProductRepositoryFromSQLServer : IRepository
	{
		public List<string> GetAll()
		{
			return new List<string>() { "SqlServer kalem1", "SqlServer kalem2"};
		}
	}

	public class ProductRepositoryFromOracle : IRepository
	{
		public List<string> GetAll()
		{
			return new List<string>() { "Oracle kalem1", "Oracle kalem2" };
		}
	}

	public interface IRepository
	{
		List<string> GetAll();
	}
}
