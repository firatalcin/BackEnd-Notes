namespace _01.Delege
{
    // Delegate'ler sırasıyla methodları tetikleyen yapılardır
    delegate void myDelegate(int sayi1, int sayi2);

    internal class Program
    {
        static void Main(string[] args)
        {
            myDelegate myDelegate = new myDelegate(Topla);
            myDelegate += Carp;
            myDelegate.Invoke(1, 2);

        }

        static void Topla(int number1, int number2)
        {
            Console.WriteLine(number1+number2);
        }

        static void Carp(int number1, int number2)
        {
            Console.WriteLine(number1*number2);
        }

        static void Cıkar(int number1, int number2)
        {
            Console.WriteLine(number1-number2);
        }
    }
}
