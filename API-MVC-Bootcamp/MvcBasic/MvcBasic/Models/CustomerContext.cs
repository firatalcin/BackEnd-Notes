namespace MvcBasic.Models
{
    public static class CustomerContext
    {
        public static List<Customer> Customers = new List<Customer>()
        {
            new Customer() { FirstName = "Fırat", LastName = "Kahraman", Age = 25},
            new Customer(){ FirstName = "Enes", LastName = "Çiçek", Age=25}
        };
    }
}
