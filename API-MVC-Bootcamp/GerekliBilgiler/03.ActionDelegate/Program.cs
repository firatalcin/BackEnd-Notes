namespace _03.ActionDelegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Action action = new Action(SelamVer);

            Action action = new Action(() =>
            {
                Console.WriteLine("Selam");
            });

            action.Invoke();


            //Action<string> action1 = new Action<string>(SelamVer2);
            //action1.Invoke("Fırat");


            Action<string> action2 = new Action<string>(name =>
            {
                Console.WriteLine(name);
            });

            action2.Invoke("Selam");

            


            
            Console.WriteLine("Hello, World!");
        }

        private static void SelamVer2(string obj)
        {
            Console.WriteLine($"Daha Çok Selam {obj}");
        }

        private static void SelamVer()
        {
            Console.WriteLine("Selam Fırat");
        }
    }
}
