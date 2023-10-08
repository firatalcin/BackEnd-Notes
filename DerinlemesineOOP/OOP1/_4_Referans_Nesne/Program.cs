namespace OOP1
{
    //Referans Nedir ? 
    //RAM'in Stack bölgesinde tanımlanan ve Heap bölgesindeki nesneleri işaretleyen/referans eden değişkenlerdir.
    //Referanslar bir nesne referans etmek zorunda değillerdir.
    //Eger ki bir referans herhangi bir nesne işaretlemiyorsa null değerini alır.

    class Program
    {
        static void Main(string[] args)
        {

            //MyClass m = new MyClass();
            //m.MyProperty = 10;

            //MyClass m2 = null;
            //m2.MyProperty = 20;

            //Eğer bir nesne referanssızsa Garbage Collector yardımıyla silinir.
            //new MyClass();

            MyClass m = new MyClass()
            {
                MyProperty = 10
            };
        }
    }

    class MyClass
    {
        public int MyProperty { get; set; }
    }

}

