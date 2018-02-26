using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XML_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Triangle(1, 2, 3);
            t.GetArea();
            var tr = new TriangleNew(1, 2, 5);
            tr.GetArea();
            Console.ReadKey();
        }
    }
}
