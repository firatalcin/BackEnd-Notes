namespace OOP1
{
    // Nesnelerimizde ki field'ların kontrollü bir şekilde dışarıya açılmasıdır.

    class Program
    {
        static void Main(string[] args)
        {
            MyClass m1 = new MyClass();
            m1.ASet(15);
            Console.WriteLine(m1.AGet());

        }
    }

    class MyClass
    {
        #region Eski tip encapsulation

        int a;

        public int AGet()
        {
            return this.a;
        }

        public void ASet(int value)
        {
            this.a = value;
        }

        #endregion

        public int b { get; set; }


    }
}
