using Task2Logic;
using static System.Console;

namespace Task2Console
{
    public sealed class Program
    {
        public static void Main(string[] args)
        {
            var timer = new Timer();
            var firstListener = new Listener1(1);
            var secondListener = new Listener2(2);

            WriteLine("1. Add 2 listiners");
            timer.Dispatcher += firstListener.OnTimerTimeout;
            timer.Dispatcher += secondListener.OnTimerTimeout;
            timer.RunIfCan(3);
            System.Threading.Thread.Sleep(7777);

            WriteLine("2. Remove 2 listiners");
            timer.Dispatcher -= firstListener.OnTimerTimeout;
            timer.Dispatcher -= secondListener.OnTimerTimeout;
            timer.RunIfCan(3);
            System.Threading.Thread.Sleep(7777);

            WriteLine("3. Add 1 listiner");
            timer.Dispatcher += firstListener.OnTimerTimeout;
            timer.RunIfCan(3);
            System.Threading.Thread.Sleep(7777);

            ReadKey();
        }

        public static void ShowMessage(string sentence) =>
            WriteLine(sentence);
    }
}
