using Inheritance_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass b = new BaseClass(7);
            Console.WriteLine(b.Square());
            Console.WriteLine(b.ToString());

            DerivedClass d1 = new DerivedClass(7, -67, "Tom");
            Console.WriteLine(d1.Square());
            d1.Foo();
            Console.WriteLine(d1.ToString());

            BaseClass d2 = new DerivedClass(8, 2345, "Petr");
           







        }
    }
}
