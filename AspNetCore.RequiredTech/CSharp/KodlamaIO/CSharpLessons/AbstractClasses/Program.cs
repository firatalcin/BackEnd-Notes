internal abstract class Person
{
    public string Name { get; set; }
    public string Lastname { get; set; }

    public Person(string name, string lastname)
    {
        Name = name;
        Lastname = lastname;
    }

    public void Work()
    {
        Console.WriteLine(Name + " " + Lastname);
    }

    public abstract void OffDay();
}

internal class Worker : Person
{
    public Worker(string name, string lastname) : base(name, lastname)
    {
    }

    public override void OffDay()
    {
        Console.WriteLine("2 day");
    }
}

internal class Manager : Person
{
    public Manager(string name, string lastname) : base(name, lastname)
    {
    }

    public override void OffDay()
    {
        Console.WriteLine("3 day");
    }
}

//Abstract class'ların Interface'lerden farkı bir class içerisine yazılan somut ifadeleri içerisinde bulundurabilir.
//Abstract class'ların içerisinde soyut bir yapı oluşturulacaksa abstract keyword'ü alması gerekir.
//Abstract metodlar miras verdikleri sınıfın içerisinde ezilirler ve override keyword'ü alırlar.
//Abstract class'lardan instance yapılamaz ama miras almış classların referansını tutabilir.
//Abstract class'larda field, property ve metod tutulabilir.
//Abstract class'lar static olarak işaretlemez ama static yapılara sahip olabilir.

internal class Program
{
    public static void Main()
    {
        Manager manager = new Manager("fırat", "alcin");
        manager.Name = "Fırat";
        manager.OffDay();
    }
}