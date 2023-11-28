using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Inheritance
{
	public class Muhasebeci : Personel
	{
        public bool Musavir { get; set; }
    }

	public class Mudur : Personel
	{

	}

	public class Yazilimci : Personel
	{
        public string[] KullandigiDiller { get; set; }
    }

	public class Personel
	{
		public string Adi { get; set; }
		public string Soyadi { get; set; }
		public bool MedeniHal { get; set; }
	}

	public class MyClass
	{
        public MyClass(int a)
        {
            
        }
    }

	public class MyClass2 : MyClass
	{
		public MyClass2(int a) : base(a)
		{
		}
	}
}
