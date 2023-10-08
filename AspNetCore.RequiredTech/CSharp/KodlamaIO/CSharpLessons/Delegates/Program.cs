public delegate void FullNameDelegate(string name, string lastname);

internal class Program
{
    public static void Main(string[] args)
    {
        FullNameDelegate fullNameDelegate1 = new FullNameDelegate(FullNameMethod1);
        FullNameDelegate fullNameDelegate2 = new FullNameDelegate(FullNameMethod2);
        FullNameDelegate fullNameDelegate3 = new FullNameDelegate(FullNameMethod3);


        FullNameDelegate zincirDelegate =  fullNameDelegate1 + fullNameDelegate2 + fullNameDelegate3;

        zincirDelegate("Fırat", "Alçın");
        
    }

    public static void FullNameMethod1(string name, string lastname)
    {
        Console.WriteLine(name + " - " + lastname);
    }

    public static void FullNameMethod2(string name, string lastname) 
    {
        Console.WriteLine(name.ToUpper() + " " + lastname.ToUpper());
    }

    public static void FullNameMethod3(string name, string lastname)
    {
        Console.WriteLine(lastname.ToUpper() + " " + name.ToUpper());
    }
}
