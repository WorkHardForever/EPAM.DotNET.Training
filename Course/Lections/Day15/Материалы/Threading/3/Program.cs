using System;
using System.Threading;

namespace _3
{
    class ThreadTest
    {
        //Вместе с тем потоки разделяют данные, 
        //относящиеся к тому же экземпляру объекта, что и сами потоки
        private bool done;

        static void Main(string[] args)
        {
            var tt = new ThreadTest(); // Создаем общий объект
            new Thread(tt.Go).Start();
            tt.Go();
            //Так как оба потока вызывают метод Go() одного и того же экземпляра ThreadTest,
            //они разделяют поле done. Результат – 'Done', напечатанное один раз вместо двух

            Console.ReadKey();
        }

        // Go сейчас – экземплярный метод
        private void Go()
        {
            if (!done)
            {
                //done = true;
                Console.WriteLine("Done"); done = true;
            }
        }
    }
}

//class ThreadTest
//{
//    static void Main()
//    {
//        bool done = false;
          //Локальные переменные, захваченные лямбда-выражением или анонимным методом, преобразуются в поля,
          //поэтому также могут быть рзделяемыми между потоками
//        ThreadStart action = () =>
//        {
//            if (!done) { done = true; Console.WriteLine("Done"); }
//        };
//        new Thread(action).Start();
//        action();
//    }
//}