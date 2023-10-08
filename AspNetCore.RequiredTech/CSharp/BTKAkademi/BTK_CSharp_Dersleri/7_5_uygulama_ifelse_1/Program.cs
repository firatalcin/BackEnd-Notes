// if/else Uygulamaları

// 1- Kullanıcıya sunulan bir menü içinden seçilecek olan 4 işlem tipine göre hesaplama yapınız.

Console.Write("1.sayı: ");
var sayi1 = Convert.ToInt32(Console.ReadLine());

Console.Write("2.sayı: ");
var sayi2 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Toplama için: +");
Console.WriteLine("Çıkarma için: -");
Console.WriteLine("Çarpma için:  *");
Console.WriteLine("Bölme için:   /");

Console.Write("Seçiminiz: ");
var secim = Console.ReadLine();

double sonuc = 0;
bool ok = true;

if (secim == "+")
{
    sonuc = sayi1 + sayi2;
}
else if (secim == "-")
{
    sonuc = sayi1 - sayi2;
}
else if (secim == "*")
{
    sonuc = sayi1 * sayi2;
}
else if (secim == "/")
{

    if (sayi2 == 0)
    {
        ok = false;
        Console.WriteLine("bölen 0 olamaz.");
    }
    else
    {
        sonuc = sayi1 / sayi2;
    }

}
else
{
    ok = false;
    Console.WriteLine("yanlış seçim");
}
if (ok)
{
    Console.WriteLine($"işlem sonucu: {sayi1} {secim} {sayi2} = {sonuc}");
}

