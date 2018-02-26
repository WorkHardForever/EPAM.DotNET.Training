using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Net;
using System.ComponentModel;

namespace Demo_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private readonly SynchronizationContext context;
        public MainWindow()
        {
            InitializeComponent();
            //context = SynchronizationContext.Current;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            btnOne.IsEnabled = false;
            Task<int> primeNumberTask = Task.Run(
                () => Enumerable.Range(2, 1000000)
                                .Count(n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1)
                                                      .All(i => n % i > 0)));
            var awaiter = primeNumberTask.GetAwaiter();
            //признак продолжения возвращается обратно потоку пользовательского интерфейса
            //var awaiter = primeNumberTask.ConfigureAwait(false).GetAwaiter();
            try
            {
                awaiter.OnCompleted(() =>
                {
                    int result = awaiter.GetResult();
                    lblResult.Content = "Result : " + result;
                    btnOne.IsEnabled = true;
                });
            }
            catch (AggregateException aexException)
            {
                lblResult.Content = "Result : " + aexException.Message;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            btnTwo.IsEnabled = false;
            Task<int> primeNumberTask = Task.Run(() =>
                Enumerable.Range(2, 1000000)
                    .Count(n => Enumerable.Range(2, (int) Math.Sqrt(n) - 1)
                        .All(i => n%i > 0)));

            primeNumberTask.ContinueWith(antecedent =>
            {
                int result = antecedent.Result;
                lblResult.Content += result.ToString();
            });//не обновляет пользовательский интерфейс
            //primeNumberTask.ContinueWith(antecedent => Dispatcher.BeginInvoke(
            //    (Action) (() =>
            //    {
            //        lblResult.Content = "Result : " + antecedent.Result;
            //        btnTwo.IsEnabled = true;

            //    })));
        }

        // Mark the event handler with async so you can use await in it.
        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // Call and await separately.
            //Task<int> getLengthTask = AccessTheWebAsync();
            //// You can do independent work here.
            //int contentLength = await getLengthTask;

            int contentLength = await AccessTheWebAsync();

            lblResult.Content +=
                String.Format("\r\nLength of the downloaded string: {0}.\r\n", contentLength);
        }

        //http://msdn.microsoft.com/ru-ru/library/hh191443.aspx
        private async Task<int> AccessTheWebAsync()
        {
            // You need to add a reference to System.Net.Http to declare client.
            //HttpClient предоставляет базовый класс для отправки HTTP-запросов и получения 
            //HTTP-ответов от ресурса с заданным URI. .NET Framework 4.5 

            var client = new HttpClient();

            // GetStringAsync returns a Task<string>. That means that when you await the
            // task you'll get a string (urlContents).
            Task<string> getStringTask = client.GetStringAsync("http://msdn.microsoft.com");

            // You can do work here that doesn't rely on the string from GetStringAsync.
            DoIndependentWork();

            // The await operator suspends AccessTheWebAsync.
            //  - AccessTheWebAsync can't continue until getStringTask is complete.
            //  - Meanwhile, control returns to the caller of AccessTheWebAsync.
            //  - Control resumes here when getStringTask is complete. 
            //  - The await operator then retrieves the string result from getStringTask.
            string urlContents = await getStringTask;

            // The return statement specifies an integer result.
            // Any methods that are awaiting AccessTheWebAsync retrieve the length value.
            return urlContents.Length;
        }

        private void DoIndependentWork()
        {
            lblResult.Content += "Working . . . . . . .\r\n";
        }
    }
}
