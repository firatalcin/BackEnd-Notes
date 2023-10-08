using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialClasses
{
    partial class Product : IA
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public void AMethod()
        {
            throw new NotImplementedException();
        }
    }

    partial class Product : IB
    {
        public void A()
        {
            Console.WriteLine("Adı: " + Name + " Soyadı: " + LastName + " Yaşı: " + Age);
        }

        public void B()
        {

        }

        public void BMethod()
        {
            throw new NotImplementedException();
        }
    }

    public interface IA
    {
        void AMethod();
    }

    public interface IB
    {
        void BMethod();
    }


    public partial interface PartialInterface
    {
        void AMethod();
    }

    public partial interface PartialInterface
    {
        void BMethod();
    }
}
