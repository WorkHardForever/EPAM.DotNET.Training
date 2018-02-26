using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SimpleDispose
{
    // Реализация интерфейса IDisposable. 
    class MyResourceWrapper : IDisposable
    {
        // После окончания работы с объектом пользователь 
        // объекта должен вызывать этот метод. 
        public void Dispose()
        {
            // Освобождение неуправляемых ресурсов. . . 

            // Избавление от других содержащихся внутри 
            //и пригодных для очистки объектов. 

            // Только для целей тестирования. 
            Debug.WriteLine("***** In Dispose! *****");
        }
    }
}
