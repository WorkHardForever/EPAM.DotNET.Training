using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

//насколько существенная задержка может разделять "Понеслась..." от "Готово" – другими словами,
//может ли цикл в методе Wait продолжать крутиться после того, как флаг endIsNigh был установлен 
//в true? И еще, может ли метод Wait напечатать "Готово, false"?

//Ответ на оба вопроса – теоретически да, может, на многопроцессорной машине, если планировщик
//потоков назначит эти два потока на разные CPU. Поля repented и endIsNigh могут кэшироваться 
//в регистрах CPU для повышения производительности и записываться назад в память с некоторой 
//задержкой. И порядок, в каком регистры записываются в память, необязательно совпадет с порядком обновления полей.

namespace ConsoleApplication1
{
    class Unsafe
    {
        static bool endIsNigh;
        static bool repented;

        static void Main()
        {
            // Запустить поток, ждущий изменения флага в цикле...
            new Thread(Wait).Start();
            Thread.Sleep(10000); // Дадим секунду на «прогрев»!
            repented = true;
            endIsNigh = true;
            Console.WriteLine("Понеслась...");
        }

        static void Wait()
        {

            while (!endIsNigh);// Крутимся в ожидании изменения значения endIsNigh
                

            Console.WriteLine("Готово, " + repented);
        }
    }
}
