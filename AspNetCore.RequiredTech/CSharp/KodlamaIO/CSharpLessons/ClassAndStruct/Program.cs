internal class UyeClass
{
    public string deger;

    public UyeClass()
    {
        deger = "fırat";
    }
}

internal struct UyeStruct
{
    public int yas;

    public UyeStruct()
    {
        yas = 24;
    }
}

internal class Uye2Class : UyeClass
{
}

internal class Uye
{
    public string Name { get; set; }

    // Classlardan instance oluşturulurken default olarak boş constructor çalışır.
    // Eğer parametreli bir constructor oluşturulursa, boş constructor oluştulurmayana kadar boş instance oluşturulamaz.
    public Uye(string name)
    {
        Name = name;
    }

    // Nested Type Class
    public class Editor
    {
        public string EditorName { get; set; }
    }
}

internal class Program
{
    public static void Main()
    {
        UyeClass uyeClass = new UyeClass();
        UyeStruct uyeStruct = new UyeStruct();
        Console.WriteLine(uyeStruct.yas + uyeClass.deger);

        string name = "fırat";
        Uye uye = new Uye(name);

        Uye.Editor editor = new Uye.Editor();

        //Bir class sadece bir tane class'ı extend edebilir ama bir çok interface'i implement edebilir.
    }
}