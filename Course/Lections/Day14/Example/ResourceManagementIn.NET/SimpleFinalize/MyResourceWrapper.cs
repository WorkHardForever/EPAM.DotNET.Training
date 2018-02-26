using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleFinalize
{
    //Переопределение System.Object.Finalize() с использованием синтаксиса финализатора. 
    class MyResourceWrapper
    {
        ~MyResourceWrapper()
        {
            // Здесь производится очистка неуправляемых ресурсов. 

            // Обеспечение подачи звукового сигнала при 
            // уничтожении объекта (только в целях тестирования). 
            for (int i = 0; i < 5; i++)
            {
                 Console.Beep();
            }
        }
    }
}
