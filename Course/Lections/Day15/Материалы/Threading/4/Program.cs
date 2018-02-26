using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _4
{
    //Оба примера демонстрируют также другое ключевое понятие – потоковую безопасность (или скорее её отсутствие)
    class ThreadTest
    {
        private static bool done;    // Статическое поле, разделяемое потоками

        static void Main(string[] args)
        {
            var tt = new ThreadTest(); // Создаем общий объект
            new Thread(tt.Go).Start();
            tt.Go();
            //Фактически результат исполнения программы не определен: возможно (хотя и маловероятно), 
            //"Done" будет напечатано дважды
            Console.ReadKey();
        }

        // Go сейчас – экземплярный метод
        private void Go()
        {
            if (!done)
            {
                //"Done" будет напечатано один раз (вероятнее всего!)
                //done = true;
                //Console.WriteLine("Done");

                //Однако если мы поменяем порядок вызовов в методе Go(), 
                //шансы увидеть “Done” напечатанным два раза повышаются радикально
                //Проблема состоит в том, что один поток может выполнить оператор if, 
                //пока другой поток выполняет WriteLine, т.е. до того как done будет установлено в true
                Console.WriteLine("Done");
                done = true;
                //Console.WriteLine("Done");
            }
        }
    }
}
