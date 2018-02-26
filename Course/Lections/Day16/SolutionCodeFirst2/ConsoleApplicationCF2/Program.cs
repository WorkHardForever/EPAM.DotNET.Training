using CF.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationCF2
{
    class Program
    {
        static void Main(string[] args)
        {
            F2();

        }

        public static void F1() 
        {
            using (var ctx = new CodeContext())
            {
                var attendeesQuery = ctx.Attendees.Select(c => c);
                Console.WriteLine(attendeesQuery.Count());

                Console.WriteLine(attendeesQuery);
            }

            Console.ReadKey();
        }

        public static void F2()
        {
             Database.SetInitializer(new DropCreateAttendeeDB());

            using (var ctx = new CodeContext())
            {
                ctx.Database.Initialize(false);
                
                var attendeesQuery = ctx.Attendees.Select(c => c);
                Console.WriteLine(attendeesQuery.Count());

                Console.WriteLine(attendeesQuery);
            }

            Console.ReadKey();

        }
    }
}
