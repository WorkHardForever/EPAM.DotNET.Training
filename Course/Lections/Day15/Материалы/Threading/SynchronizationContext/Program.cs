using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;//!!!
using System.Text;
using System.Threading;

//атрибут Synchronization – System.Runtime.Remoting.Contexts. 
//О ContextBoundObject можно думать как об "удаленном" объекте, перехватывающем все вызовы методов.
//Чтобы сделать этот перехват возможным, CLR, когда создается AutoLock, фактически возвращает 
//прокси-объект со всеми методами и свойствами AutoLock, который работает как посредник. 
//Именно через это посредничество и работает автоблокировка. В целом перехват добавляет 
//около микросекунды к вызову каждого метода.
//Автоматическая синхронизация не может быть использована для защиты членов статических типов и 
//классов, не являющихся наследниками ContextBoundObject (например, Windows Form).


namespace SynchronizationContext
{
    [Synchronization]
    public class AutoLock : ContextBoundObject
    {
        public void Demo()
        {
            Console.Write("Старт...");
            //Console.WriteLine("Id = " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);        // Поток не может быть вытеснен здесь
            Console.WriteLine("стоп"); // спасибо автоматической блокировке!
        }
    }

    public class Test
    {
        public static void Main()
        {
            // CLR гарантирует, что только один поток сможет одновременно исполнять код в safeInstance.
            //CLR делает это, создавая отдельный объект синхронизации и блокируя его при каждом вызове 
            //метода или свойства safeInstance. Область блокировки, в данном случае – объект safeInstance,
            //называют контекстом синхронизации
            AutoLock safeInstance = new AutoLock();
            new Thread(safeInstance.Demo).Start(); // Запустить метод 
            new Thread(safeInstance.Demo).Start(); // Demo 3 раза
            safeInstance.Demo();                   // одновременно.
        }
    }
}
