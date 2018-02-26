using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace BackgroundWorker_2
{
    class Program
    {
        static BackgroundWorker bw;

        static void Main()
        {
            bw = new BackgroundWorker { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += (sender, args) => Console.WriteLine("Обработано " + args.ProgressPercentage + "%"); ;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;

            bw.RunWorkerAsync(null);

            Console.WriteLine("Нажмите Enter в течении следующих 10 секунд, чтобы прервать работу");
            Console.ReadLine();

            if (bw.IsBusy)
            {
                bw.CancelAsync();
                Console.ReadLine();
            }
        }

        static void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i += 20)
            {
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                bw.ReportProgress(i);
                Thread.Sleep(2000);
            }

            e.Result = 123;    // будет передано в RunWorkerComрleted
        }

        static void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                Console.WriteLine("Работа BackgroundWorker была прервана пользователем!");
            else if (e.Error != null)
                Console.WriteLine("Worker exception: " + e.Error);
            else
                Console.WriteLine("Работа закончена успешно. Результат - " + e.Result + ". ");

            Console.WriteLine("Нажмите Enter для выхода из программы...");
        }
    }
}
