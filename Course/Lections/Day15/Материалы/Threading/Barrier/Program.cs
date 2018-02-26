namespace Barrier
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    class Program
    {
        private static Barrier _barrier = new Barrier(3);//, barrier => Console.WriteLine());

        static void Main()
        {
            new Thread(Speak).Start();
            new Thread(Speak).Start();
            new Thread(Speak).Start();
        }

        static void Speak()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write(i + " ");
                _barrier.SignalAndWait();
            }
        }
    }
}
