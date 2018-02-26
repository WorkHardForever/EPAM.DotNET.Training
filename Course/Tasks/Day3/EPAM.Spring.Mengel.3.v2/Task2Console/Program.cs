using Task2Logic;
using static System.Console;

namespace Task2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var formatter = new ConvertFormatter();

            formatter.Value = (byte)124;
            WriteLine("{0} => {0:h}", formatter);
            formatter.Value = (int)23045;
            WriteLine("{0} => {0:h}", formatter);
            formatter.Value = (ulong)31906574882;
            WriteLine("{0} => {0:h}", formatter);

            ReadKey();
        }
    }
}
