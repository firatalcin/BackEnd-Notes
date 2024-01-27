namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    interface IMyInterface
    {
        void X();
        void Y(int a);
        int Z {  get; set; }
    }

    interface IMyInterface2
    {
        void T();
    }

    abstract class MyAbstractClass
    {
        public abstract void X();
        public abstract void Y(int a);
        public abstract int Z { get; set; }
    }

    class MyClass : IMyInterface, IMyInterface2 
    {
        public int Z { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void T()
        {
            throw new NotImplementedException();
        }

        public void X()
        {
            throw new NotImplementedException();
        }

        public void Y(int a)
        {
            throw new NotImplementedException();
        }
    }
}
