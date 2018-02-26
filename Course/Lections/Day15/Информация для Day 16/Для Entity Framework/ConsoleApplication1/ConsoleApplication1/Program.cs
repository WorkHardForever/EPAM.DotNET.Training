using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //F1();

           //F2();
            F3();

        }
        #region F1
        private static void F1()
        {
            using (var db = new SchoolDBEntities())
            {
                db.Students
                    .Where(c => c.StudentID > 1)
                    .ToList()
                    .ForEach(c => Console.WriteLine(c));
                Console.ReadKey();

                //var query = from c in db.Standard select c;
                //Console.WriteLine("\n\n" + query);
                //Console.ReadKey();

                //int customersCount = query.Count();
                //Console.WriteLine("\n\nTotal number of records:{0}", customersCount);
                //Console.ReadKey();
            }
        }
        #endregion
        #region F2
        private static void F2()
        {
            using (var context = new SchoolDBEntities())
            {
                //context.Configuration.LazyLoadingEnabled = true;
                var query = (from s in context.Students
                             where s.StudentName == "Student2"
                             select s).FirstOrDefault();

                Console.WriteLine(query);


               // var ordersList = query.ToList();

                //foreach (var s in ordersList)
                //{
                //    if (s.Course != null)
                //        Console.WriteLine(s.StudentName + "\t" + s.Course.Count);
                //}

                Console.ReadKey();
            }
        }
        #endregion
        #region F3
        private static void F3()
        {
            using (var context = new SchoolDBEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;
                var query = from order in context.Students.Include("Courses")
                            select order;

                Console.WriteLine(query);


                var ordersList = query.ToList();

                foreach (var s in ordersList)
                {
                    if (s.Courses != null)
                        Console.WriteLine(s.StudentName + "\t" + s.Courses.Count);
                }

                Console.ReadKey();
            }
        }
        #endregion
    }

}
