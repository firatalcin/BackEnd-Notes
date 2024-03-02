namespace _03_LiskovSubstitution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new PartTimeEmployee();
            Console.WriteLine("Hello, World!");
        }
    }

    class Employee
    {
        public int Id { get; set; }
        public string FirtName { get; set; }
        public string LastName { get; set; }
    }

    class PartTimeEmployee : Employee
    {
        public decimal DailyWage { get; set; }
    }

    class FullTimeEmployee 
    {
        public decimal HourlyWage { get; set; }
    }
}
