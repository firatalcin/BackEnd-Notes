internal class BaseClass
{
    public string Name { get; set; }

    public virtual string GetName()
    {
        return Name;
    }
}

internal sealed class BaseClass2
{
}

internal class ChildClass : BaseClass
{
    public override sealed string GetName()
    {
        return Name.ToUpper();
    }
}

internal class Child2Class : ChildClass
{
}

//Sealed keyword'ü bir class'a miras alınamama özelliği katar.
//Sealed methodlar miras verdiği classlarda erişilemezler
internal class Program
{
    public static void Main()
    {
        Child2Class child2Class = new Child2Class();
        child2Class.Name = "Fırat";
        Console.WriteLine(child2Class.GetName());
    }
}