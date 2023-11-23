using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Constructor
{
	public class MyClass
	{

        /// <summary>
        /// Bu bir constructor metottur
        /// </summary>
        public MyClass(int a) { 
            Console.WriteLine("Bir adet constructor oluşturulmuştur" + a);
        }

		public MyClass() {

            Console.WriteLine("Boş constructor çalıştı");
        }

		public MyClass(string a) : this()
		{
            Console.WriteLine(a);
        }
	}
}
