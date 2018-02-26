using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XML_DEMO;

namespace ConsoleXML_DEMO
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle tr1 = new Triangle(3,5,6);
            tr1.GetArea();




            TriangleXML tr2 = new TriangleXML(4, 5, 6);
            tr2.GetArea();
        }
    }
}
