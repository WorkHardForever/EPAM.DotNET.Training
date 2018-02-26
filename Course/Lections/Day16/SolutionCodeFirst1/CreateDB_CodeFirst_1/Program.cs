
using ClassLibrary1;
using System;
using System.Linq;

//Данный пример создает БД с одной таблицей Attendee.
//Но не пересоздает ее, когда мы меняем структуру таблицы.
//В случае, если мы будем изменять тип поля, или добавлять еще одну таблицу - 
//программа нам выдаст ошибку. Чтобы этого избежать нужно удалить старую БД и запустить программу.

namespace CreateDB_CodeFirst_1
{
    class Program
    {
        static void Main(string[] args)
        {
            F1();
            F2();
        }
        /*
 Создание БД с помощью конструктора по умолчанию
 */
        public static void F1()
        {
            using (var ctx = new CodeContext())
            {
                var attendees = ctx.Attendees.ToList();
                Console.WriteLine(attendees.Count());
            }
            Console.ReadKey();
        }
/*
 Создание БД с помощью конструктора с параметром
 */
        public static void F2()
        {
            using (var ctx = new CodeContext("dbAttendeeCF"))
            {
                var attendees = ctx.Attendees.ToList();
                Console.WriteLine(attendees.Count());
            }
            Console.ReadKey();
        }
   

    
     }
}
