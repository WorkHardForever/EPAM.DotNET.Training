using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalizableDisposableClass
{
    class MyResourceWrapper : IDisposable
    {
        private bool disposed = false;

        public void Dispose()
        {
            // Вызов вспомогательного метода. 
            // Значение true указывает на то, что очистка 
            // была инициирована пользователем объекта. 
            Dispose(true);

            // Подавление финализации. 
            GC.SuppressFinalize(this);
        }

        
        private void Dispose(bool disposing)
        {
            // Проверка, выполнялась ли очистка. 
            if (!this.disposed)
            {
                // Если disposing равно true, должно осуществляться 
                // освобождение всех управляемых ресурсов, 
                if (disposing)
                {
                    // Здесь осуществляется освобождение управляемых ресурсов. 

                }
                // Очистка неуправляемых ресурсов. 
            }
            disposed = true;
        }

        ~MyResourceWrapper()
        {
            Console.Beep();
            // Вызов вспомогательного метода. 
            // Значение false указывает на то, что 
            // очистка была инициирована сборщиком мусора. 
            Dispose(false);
        }

    }
}
