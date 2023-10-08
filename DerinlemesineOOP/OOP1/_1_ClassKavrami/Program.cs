class MyClass2
{

}

namespace OOP1
{
    class Program
    {
        //Bir class tanımlamasında tanımlanan yerde(namespace/dışı, class) aynı isimde birden fazla class tanımlanamaz 
    }

    class OrnekModel
    {
        int a;
        int b;

        public void X()
        {
            Console.WriteLine(a + " " + b);
        }

        public int Y()
        {
            return a * b;
        }
    }

    class MyClass
    {
        class MyClass3
        {

        }
    }
}
