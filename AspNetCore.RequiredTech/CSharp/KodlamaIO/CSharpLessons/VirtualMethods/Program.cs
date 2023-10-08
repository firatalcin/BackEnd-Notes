public abstract class BaseClass
{
    public abstract string GetProduct();

    public virtual void SetProduct()
    {
        Console.WriteLine("Ürün Eklendi");
    }
}

public class SubClass : BaseClass
{
    public override string GetProduct()
    {
        return "Ürün Listelendi";
    }

    public override void SetProduct()
    {
        Console.WriteLine("SubÜrün Eklendi");
    }
}

//Virtual methodlar base class'ta oluşturularak içerisi default olarak doldurulur.,
//Virtual methodların mutlaka gövdesi olmak zorunda.
//Virtual methodları alt classlarda çağırmak zorunda değilsiniz.
//Alt classlarda çalışması durumunda override anahtar kelimesi kullanılarak method ezilir.
//Alt class'ta base class'ta ki içeriği değiştirilibilir.

internal class Program
{
    public static void Main()
    {
        SubClass subClass = new SubClass();
        Console.WriteLine(subClass.GetProduct());
        subClass.SetProduct();
    }
}