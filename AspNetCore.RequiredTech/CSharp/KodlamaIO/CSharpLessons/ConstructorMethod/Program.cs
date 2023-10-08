internal class MainClass
{
    public MainClass()
    {
        Console.WriteLine("Bu method nesne oluşturulurken çağırıldı");
    }
}

class DefaultConstructor
{
    //Default Constructor
    public DefaultConstructor()
    {

    }
}

class ParameterizedConstructor
{
    public string Name { get; set; }
    public int Age { get; set; }

    public ParameterizedConstructor(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
}

class CopyConstructor
{
	public string Name { get; set; }
	public int Age { get; set; }

	public CopyConstructor(string name, int age)
	{
		this.Name = name;
		this.Age = age;
	}

    public CopyConstructor(CopyConstructor copyConstructor)
    {
        this.Age=copyConstructor.Age;
        this.Name = copyConstructor.Name;
    }
}


class StaticConstructor
{
    public static string Name { get; set; }
    static StaticConstructor()
	{
        Name = "Fırat";
	}
}

class BaseClass
{
    public string Name { get; set; }
    public int Age { get; set; }

    public BaseClass()
    {

    }

	public BaseClass(string name, int age)
	{
		Name = name;
		Age = age;
	}
}

class SubClass : BaseClass
{
    public string LastName { get; set; }

    public SubClass(string name, int age, string lastName) : base(name, age)
    {
        LastName = lastName;
    }
}

internal class Program
{
    // Constructor'lar class'tan bir nesne oluşturulurken çalışan kurucu methodlardır.

    public static void Main()
    {
        MainClass mainClass = new MainClass();
		DefaultConstructor ornekClass = new DefaultConstructor();
        ParameterizedConstructor parameterizedConstructor = new ParameterizedConstructor("Fırat", 24);
        CopyConstructor copyConstructor1 = new CopyConstructor("Fırat", 24);
        CopyConstructor copyConstructor2 = new CopyConstructor(copyConstructor1);
        StaticConstructor staticConstructor = new StaticConstructor();
    }
}