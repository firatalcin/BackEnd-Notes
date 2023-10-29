namespace _1_SingleResponsibility
{
	public class ProductPresenter
	{
		public void WriteToConsole(List<Product> products)
		{
			products.ForEach(x =>
			{
				Console.WriteLine($"{x.Id} - {x.Name}");
			});
		}
	}
}
