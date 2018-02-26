using Task1Logic;
using static System.Console;

namespace Task1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new int[] { 1, 2, 3, 4, 5 };
            var b = new int[] { 999 };
            var c = new int[] { 5, 4, 3, 2, 1 };
            var d = new int[] { 1, -10, 2, 3, -4 };

            ShowConsoleResults(a, b, c, d);
            ReadKey();
        }

        private static void FormatedWriteLine(int[] array) => WriteLine($"Array: {{ { string.Join(", ", array) } }}");

        private static void ShowConsoleResults(params int[][] arrays)
        {
            for (int i = 0; i < arrays.Length; i++)
            {
                FormatedWriteLine(arrays[i]);
                SortArray.MergeSort(ref arrays[i]);
                FormatedWriteLine(arrays[i]);
            }
        }
    }
}
