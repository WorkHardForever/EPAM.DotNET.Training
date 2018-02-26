using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Properties_1;
namespace Properties_1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Foo_1();
        }

        public static void Foo_1()
        {
            Employee employee = new Employee("Joe");
            Console.WriteLine(employee);
            
            employee.SetSalary(12000000);

            Console.WriteLine("name: " + employee.GetName());

            Console.WriteLine(employee);
            Console.ReadLine();
        }
    }
}
