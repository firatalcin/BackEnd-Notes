namespace OOP1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region this keyword

            #region 1. Sınıfın Nesnesini Temsil Eder

            MyClass m1 = new MyClass();
            MyClass m2 = new MyClass();

            m1.X(10);

            #endregion

            #region 2. Aynı İsimde Field İle Metot Parametrelerini Ayırmak İçin Kullanılır

            //this keywordü ilgili class yapılanmasının o anki nesnesine karşılık gelir.
            //this kullanılmak zorunda değildir

            #endregion

            #region 3. Bir Constructer'dan Başka Bir Constructer'ı Çağırmak İçin Kullanılır
            #endregion

            #endregion


        }
    }

    class MyClass
    {
        int a;

        public void X(int a)
        {
            this.a = a;
        }
    }
}
