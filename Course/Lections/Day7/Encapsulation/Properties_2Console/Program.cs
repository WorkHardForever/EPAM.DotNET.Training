using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties_2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            F2();
        }

        static void F2()
        {
            EmployeeService ob = new EmployeeService();

            Console.WriteLine(ob["Joe"]);
            Console.ReadLine();
        }
    }
}
