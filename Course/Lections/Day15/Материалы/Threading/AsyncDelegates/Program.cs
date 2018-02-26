using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace AsyncDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            ComparePages();
        }

        //static void ComparePages()
        //{
        //    var wc = new WebClient();
        //    string s1 = wc.DownloadString("http://www.rsdn.ru");
        //    string s2 = wc.DownloadString("http://rsdn.ru");
        //    Console.WriteLine(s1 == s2 ? "Одинаковые" : "Различные");
        //}

        static void ComparePages()
        {
            // создаем два экземпляра делегата DownloadString:
            Func<string, string> download1 = new WebClient().DownloadString;
            Func<string, string> download2 = new WebClient().DownloadString;

            // Стартуем загрузку:
            IAsyncResult cookie1 = download1.BeginInvoke("http://www.rsdn.ru", null, null);
            //BeginInvoke нужны два дополнительных параметра – метод обратного вызова и объект 
            //с данными; обычно в них нет необходимости и можно передать в них null. 
            //BeginInvoke возвращает объект IASynchResult, используемый как cookie для вызова EndInvoke.
            //У объекта IASynchResult есть также свойство IsCompleted, которое можно использовать
            //для проверки завершения операции.
            IAsyncResult cookie2 = download2.BeginInvoke("http://rsdn.ru", null, null);

            // Выполняем какие-то вычисления:
            double seed = 1.23;
            for (int i = 0; i < 1000000; i++)
                seed = Math.Sqrt(seed + 1000);
            Thread.Sleep(5000);

            // Получаем результат загрузки, ожидая в случае необходимости.
            string s1 = download1.EndInvoke(cookie1);
            //Если при исполнении асинхронного метода возникает необработанное исключение, 
            //оно будет повторно сгенерировано при вызове EndInvoke. 
            //Это позволяет аккуратно передавать исключения вызывающему коду
            string s2 = download2.EndInvoke(cookie2);

            //Даже если вызываемый асинхронно метод не возвращает никакого значения, 
            //чисто технически все равно необходимо вызывать EndInvoke. Однако на практике
            //возможны варианты. MSDN выдает противоречивые рекомендации на этот счет. 
            //Если не вызывается EndInvoke, то необходимо разрешить проблему
            //обработки исключений в вызываемом методе.

            Console.WriteLine(s1 == s2 ? "Одинаковые" : "Различные");
        }
    }
}
