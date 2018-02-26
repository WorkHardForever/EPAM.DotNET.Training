using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AggregatedService;
using Repository;
namespace AggregatedCustomService_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            AggregatedCustomService custom = 
                new AggregatedCustomService(new SqlRepository());

            custom.DoSomething();
           
            Console.ReadLine();
        }
    }
}
