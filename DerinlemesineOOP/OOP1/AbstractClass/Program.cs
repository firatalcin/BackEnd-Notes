namespace AbstractClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    abstract class MyAbstractClass
    {
        int a;

        public void X()
        {

        }

        public int MyProperty { get; set; }

        abstract public void Z();
        abstract public void W(string a, int b);
        abstract public int Y { get; set; }
        abstract public bool H();
    }

    class MyClass : MyAbstractClass
    {
        public override int Y { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override bool H()
        {
            throw new NotImplementedException();
        }

        public override void W(string a, int b)
        {
            throw new NotImplementedException();
        }

        public override void Z()
        {
            throw new NotImplementedException();
        }
    }
}
