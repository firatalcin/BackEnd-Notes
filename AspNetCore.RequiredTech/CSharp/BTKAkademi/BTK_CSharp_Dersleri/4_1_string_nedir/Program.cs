/*
   Strings: Karakter dizileri - reference => null
*/

Console.Write("adı: ");
var ad = Console.ReadLine();

Console.Write("Soyad: ");
var soyad = Console.ReadLine();

Console.Write("yaş: ");
var yas = Console.ReadLine();

// string concat
string mesaj1 = ad + " " + soyad + " isimli kişi " + yas + " yaşındadır.";
Console.WriteLine(mesaj1);

// string interpolation
string mesaj2 = $"{ad} {soyad} isimli kişi {yas} yaşındadır.";
Console.WriteLine(mesaj2);
