using CompositeCustomService;
using RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryFactory.Creator;

namespace CompositeCustomService_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomService custom = 
                new CustomService(new CreatorSqlRepository());
            custom.DoSomething();
#region
            //CustomService custom =
            //    new CustomService(RepositoryEnum.SqlRepository);
            //custom.DoSomething();
#endregion

            Console.ReadLine();
        }
    }
}
