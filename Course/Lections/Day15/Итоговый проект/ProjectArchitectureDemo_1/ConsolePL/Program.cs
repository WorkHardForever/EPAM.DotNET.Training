using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using BLL.Interface.Services;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    class Program
    {
        public  static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolverConsole();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("1");
            var service = resolver.Get<IUserService>();
            var list = service.GetAllUserEntities().ToList();
            foreach (var user in list)
            {
                Console.WriteLine(user.UserName);
            }
            Console.WriteLine("2");
            Console.ReadLine();
        }
    }
}
