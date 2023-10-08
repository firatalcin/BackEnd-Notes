namespace GenelSoruVeCevaplar_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //1 - Namespace nedir : İçerisinde belirli sınıfları taşıyan gerektiğinde kodumuzda kullanarak yararlanacağımız yapılardır.

            //namespace kavramı bizim projelerimizde dahil ettiğimiz 3. parti kütüphanelerdir.

            //2 - Strongly-Typed : C#'ta farklı veri türleriyle matematiksel işlemler yapılamaz

            string a = "5";
            int b = 10;
            //int topla = a + b; yapılamaz

            //3 - Data Type sınıflandırılması : C#'ta iki tip veri sınıflandırması vardır. İlki gömülü olarak gelen tipler, ikincisi kullanıcının tanımladığı tipler

            int c = 20; // gömülü olarak gelen

            //class Ornek  = Kulanıcının tanımladığı

            //4 - Int ile Int32 arasında fark var mıdır : Herhangi bir fark yoktur. Int, Int32'nin kısaltılmış halidir.

            Console.WriteLine(typeof(int));
            Console.WriteLine(typeof(Int32));

            //5 - Value Types ve Reference Types arasındaki fark nedir ? : value types stack'te tutulurken, reference types heap'te tutularak stack'te referansı tutulur.

            int v = 5; // Stack'te tutulan veriler genellikte tek bir variable tutumunda kullanılır.
            string r = "reference"; // Heap'te tutulan veriler genellikle bir veri kümesine sahip nesnelerdir. Bu nesnelerin referansı ile stack'te bir değişken oluşturulabilir.

            //6 - Property Nedir ? : Bir class'taki private değerleri hep okuyup hem değiştirebileceğimiz encapsulation uygulayabileceğimiz yapılardır.

            Ogrenci ogrenci = new();
            ogrenci.FirstName = "Fırat";

            //7 - Access Modifiers : Erişim belirleyiciler field, property veya bir class'ın görünümünü kısıtlayabilir.

            //public : Bütün classlardan ulaşılabilir
            //private : Sadece oluşturulduğu class'ta erişilebilir
            //internal : Sadece oluşturulduğu proje içerisinde erişilebilir
            //protected : Sadece oluşturulduğu class ve miras alınan class'ta erişilir.

            //8 - Kaç çeşit tip dönüşümü vardır ? : Implicit(kapalı) Conversion ve Explicit(açık) Conversion

            //implicit

            int sayi = 100;
            long sayi2 = sayi;

            //explicit

            long sayi3 = 500;
            int sayi4 = ((int)sayi3);

            //9 - Boxing ve UnBoxing nedir ? :  value tipi reference tipe dönüştürmeye boxing, reference tipi value tipe dönüştürmeye unboxing denir.

            int deger = 100;
            object deger2 = deger;

            object deger3 = 100;
            int deger4 = (int)deger3;

            //10 - int.Parse() ile int.tryParse() farkı ? : int.Parse dönüştüremezse hata fırlatır, int.tryParse geriye bool döner

            string sayi5 = "10";
            int sayi6 = int.Parse(sayi5); //Convert.ToInt32()

            int result;
            bool isSuccess = Int32.TryParse(sayi5, out result);
            Console.WriteLine(isSuccess);

            //11 - is ve as operatörleri : Is bir tipin başka bir tipe dönüştürül mü sorgular bool döner, As dönüştürebiliyorsa dönüştürür dönüştüremezse null döner

            Object[] dizin = { "fırat", 5, 5.4, false, "Mehmet", true, 40 };
            foreach (var item in dizin)
            {
                //if (item is string)
                //{
                //    Console.WriteLine(item);
                //}

                string veri = item as string; // string olmayanlara null atar
                Console.WriteLine(veri);
            }

            //12 - Const ve readonly arasında ki fark ? : const oluşturulan anda değeri verilir ve değiştirilemez , readonly ilk anda veya constructor de değer atanır başka bir zamanda sadece okunur

            const double PI = 3.14;
            //readonly int KDV;
        }
    }

    internal class Ogrenci
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int Number { get; set; }
    }
}