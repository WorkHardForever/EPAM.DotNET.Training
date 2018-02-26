using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FabrikamUserManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = null;

            //try
            //{
                user = Users.GetUserById(7);
                Console.WriteLine(user.UserName);

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            Console.ReadKey();
        }
    }
}