internal interface ITest
{
    int Test1 { get; set; }
}

internal interface IIslem : ITest
{
    int GetItem { get; set; }

    void Ekle(string veri);

    void Sil(string veri);

    void Guncelle(string veri);

    void Listele(int[] list);
}

internal class Urun : IIslem
{
    public int GetItem { get; set; }
    public int Test1 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void Ekle(string veri)
    {
        throw new NotImplementedException();
    }

    public void Guncelle(string veri)
    {
        throw new NotImplementedException();
    }

    public void Listele(int[] list)
    {
        throw new NotImplementedException();
    }

    public void Sil(string veri)
    {
        throw new NotImplementedException();
    }
}

//Interface'ler bizi kod tekrarından ve kodların belirli disiplinlerle geliştirilmesini sağlayan soyut yapılardır.
//Interface'ler içerisinde field barındıramazlar.
//Interface'ler bir veya daha fazla interface'den miras alabilir.
//Interface'ler kendi isimleriyle bir instance oluşturamazlar ama implement oldukları classların referansını tutabilirler.

internal class Program
{
    public static void Main()
    {
        IIslem islem = new Urun();
        islem.Ekle("Hello");
    }
}