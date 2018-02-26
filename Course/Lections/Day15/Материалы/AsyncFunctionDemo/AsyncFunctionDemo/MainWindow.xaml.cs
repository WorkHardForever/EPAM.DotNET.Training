using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Windows;

namespace AsyncFunctionDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string Uri = "http://img-fotki.yandex.ru/get/6503/307344.0/0_663fb_eb16b32e_orig";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            button1.IsEnabled = false;

            var client = new WebClient();
            client.DownloadFile(Uri, "picture1.jpg");
            Debug.WriteLine($"Sync: Thread Id: {Thread.CurrentThread.ManagedThreadId}" +
                            $" Is Thread Pool Thread {Thread.CurrentThread.IsThreadPoolThread}");
            button2.Visibility = Visibility.Visible;
            button1.IsEnabled = true;
        }

        //Программируем как при синхронном подходе, но вместо блокирования функций и их ожидания
        //вызываем асинхронные функции!!!!!!!!
        private async void Button2_Click(object sender, RoutedEventArgs e)
        {
            button2.IsEnabled = false;//избегаем повторного щелчка по кнопке

            var client = new WebClient();//HttpClient()
                                         //В рабочем потоке запускается только код внутри метода DownloadFileTaskAsync
                                         //код метода Button2_Click "арендует" время у потока пользовательского интерфейса
                                         //метод выполняется псевдопаралелльно с циклом сообщений (выполнение не пересекается с 
                                         //другими событиями, которые обрабатывает поток пользовательского интерфейса)
            Debug.WriteLine("Before async operation" +
                            $" Thread Id: {Thread.CurrentThread.ManagedThreadId}" +
                            $" Is Thread Pool Thread {Thread.CurrentThread.IsThreadPoolThread}");

            await client.DownloadFileTaskAsync(new Uri(Uri), "picture2.jpg");
            Debug.WriteLine("After async operation" +
                            $" Thread Id: {Thread.CurrentThread.ManagedThreadId}" +
                            $" Is Thread Pool Thread {Thread.CurrentThread.IsThreadPoolThread}");

            button3.Visibility = Visibility.Visible;
            button2.IsEnabled = true;
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            //var client = new WebClient();
            //client.DownloadFileTaskAsync(new Uri(Uri), "picture3.jpg")
            //    .ContinueWith(t => this.Dispatcher.BeginInvoke((Action)(() => button4.Visibility = Visibility.Visible)));
            ////обовить элементы пользовательского интерфейса может только поток их создавший
            ////.ContinueWith(t => button4.Visibility = Visibility.Visible);

            button3.IsEnabled = false;
            var client = new WebClient();
            var task = client.DownloadFileTaskAsync(new Uri(Uri), "picture3.jpg");
            Debug.WriteLine("Before async operation" +
                $" Thread Id: {Thread.CurrentThread.ManagedThreadId}" +
                $" Is Thread Pool Thread {Thread.CurrentThread.IsThreadPoolThread}");

            var awaiter = task.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                Debug.WriteLine("After async operation" +
                $" Thread Id: {Thread.CurrentThread.ManagedThreadId}" +
                $" Is Thread Pool Thread {Thread.CurrentThread.IsThreadPoolThread}");

                button4.Visibility = Visibility.Visible;
                button3.IsEnabled = true;
            });
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            button4.IsEnabled = false;
            Debug.WriteLine("Before create new Thread" +
                $" Thread Id: {Thread.CurrentThread.ManagedThreadId}" +
                $" Is Thread Pool Thread {Thread.CurrentThread.IsThreadPoolThread}");

            var worker = new Thread(() =>
            {
                Debug.WriteLine("In new Thread" +
                $" Thread Id: {Thread.CurrentThread.ManagedThreadId}" +
                $" Is Thread Pool Thread {Thread.CurrentThread.IsThreadPoolThread}");

                var client = new WebClient();
                client.DownloadFile(Uri, "picture4.jpg");
                this.Dispatcher.BeginInvoke((Action)(() => { button1.Visibility = Visibility.Hidden; button4.IsEnabled = true; }));
            });
            worker.Start();
        }
    }
}
