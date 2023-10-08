namespace OOP1
{
    class Program
    {
       static void Main(string[] args) {
            #region Field

            //Nesne içerisinde değer tutmamızı sağlayan alanlardır.

            MyClass m1 = new MyClass();
            m1.a = 1;
            MyClass m2 = new MyClass();
            m1.a = 5;

            #endregion

            #region Property

            MyClass myClass = new MyClass();
            Console.WriteLine(myClass.A);
            myClass.A = 65;

            #endregion
        }
    }
}


/// <summary>
/// Bu bir örnek class'tır
/// </summary>
class MyClass
{
    int a;
    string b;

    #region FullProperty
    // Property hangi türden bir field'ı temsil ediyorsa o türden olmalıdır..
    public int A {  
        get { 
            return a; 
        } 
        set { 
            a = value; 
        } 
    }

    #endregion

    #region PROP

    public int Yasi { get; set; }

    #endregion
}