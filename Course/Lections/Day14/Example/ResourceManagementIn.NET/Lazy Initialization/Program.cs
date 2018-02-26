using System;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;

namespace Lazy_Initialization
{
    public class LogFile
    {
        public LogFile()
        {
            Debug.WriteLine("LogFile constructor");
        }

        public void AddToLog(string msg) { Debug.WriteLine("LogFile AddToLog(string msg)"); }
    }

    public class LazyLogDemo
    {
        private readonly Lazy<LogFile> _lazyLog = new Lazy<LogFile>(
            () =>
            {
                Debug.WriteLine("Code from delegate");
                return new LogFile();
            });
        // это операция инициализации помещается 

        public LazyLogDemo()
        {
            string msg = string.Empty;
            bool isError = false;

            // Do something

            if (isError) { _lazyLog.Value.AddToLog(msg); }
        }

        public void Execute()
        {
            string msg = string.Empty;
            bool isError = true;

            // Do something

            if (isError)
            {
                _lazyLog.Value.AddToLog(msg);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //В данном примере видно, что экземпляр класса LogFile не обязательно будет
            //использоваться в ходе выполнения программы. Поэтому его инициализация 
            //отложена до его первого вызова любого его метода или свойства. 
            //Доступ к самому экземпляру осуществляется через свойство Value 
            //класса Lazy<T>. Определить, был ли он инициализирован, 
            //поможет свойство IsValueCreated.
            var lazy = new LazyLogDemo();
            lazy.Execute();
        }
    }
}
