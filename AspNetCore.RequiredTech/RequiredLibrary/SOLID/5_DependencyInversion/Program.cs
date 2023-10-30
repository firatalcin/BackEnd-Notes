//High level nesnelerin low level nesnelere direkt bağlantısı olmamalıdır.


using _5_DependencyInversion;

ProductService productService = new ProductService(new ProductRepositoryFromOracle());

productService.GetAll().ForEach(x => Console.WriteLine(x));
