using System;
using Task3Logic;
using static System.Console;

namespace Task3Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new int[] { 1, 2, 3, 4, 5 };
            var b = new int[] { 999 };
            var c = new int[] { 5, 4, 3, 2, 1 };
            var d = new int[] { 1, -10, 2, 3, -4 };
            var e = new string[] { "cba", "aaa", "rgb", "bgr", "hello" };

            var sort = new SortArray<int>();

            ShowConsoleResults(sort, a, b, c, d);
            FormatedWriteLine(e, new SortArray<string>().MergeSort(e));

            ReadKey();
        }

        private static void FormatedWriteLine<T>(T[] array, T[] sortedArray) =>
            WriteLine($"Array: {{ {string.Join(", ", array)} }} | Sorted: {{ {string.Join(", ", sortedArray)} }}");

        private static void ShowConsoleResults<T>(SortArray<T> sort, params T[][] arrays)
            where T: IComparable
        {
            for (int i = 0; i < arrays.Length; i++)
            {
                FormatedWriteLine(arrays[i], sort.MergeSort(arrays[i]));
            }
        }
    }
}
