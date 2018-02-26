using System;
using Task4Logic;
using static System.Console;

namespace Task4Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new string[] { "a", "b" };
            var b = new string[] { "abacaba", "foobarbaz" };
            var c = new string[] { "cbaaaa", "rgbbgr" };

            var concat = new ConcatStrings();

            ShowConsoleResults(concat, a, b, c);

            ReadKey();
        }

        private static void FormatedWriteLine(string array1, string array2, string resultArray) =>
            WriteLine($"Concat: '{array1}' and '{array2}' | Result by task: '{resultArray}'");

        private static void ShowConsoleResults(ConcatStrings concat, params string[][] arrays)
        {
            for (int i = 0; i < arrays.Length; i++)
            {
                FormatedWriteLine(
                    arrays[i][0],
                    arrays[i][1],
                    concat.SortByAlphabetWithoutRepeated(
                        arrays[i][0],
                        arrays[i][1]));
            }
        }
    }
}
