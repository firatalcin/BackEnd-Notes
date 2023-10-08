/*
   String Methods
*/

string mesaj = "Fırat Alçın";

// Uzunluk
// var sonuc = mesaj.Length;
// küçük harf
// var sonuc = mesaj.ToLower();
// büyük harf
// var sonuc = mesaj.ToUpper();
// baştan ve sondan boşlukları siler
// var sonuc = mesaj.Trim();
// içindeki elemandan ayırarak diziye dönüştürür
// var sonuc = mesaj.Split(" ")[0];
// var sonuc = mesaj[0];
// var sonuc = mesaj.StartsWith("B");
// var sonuc = mesaj.EndsWith(".");
// var sonuc = mesaj.Contains("Ali");
// var sonuc = mesaj.IndexOf("abc");
var sonuc = mesaj.Substring(6, 2);

Console.WriteLine(sonuc);
