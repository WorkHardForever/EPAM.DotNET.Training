using Task2Logic;
using static System.Console;

namespace Task2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new int[] { 1, 2, 3, 4, 5 };
            var b = new int[] { 999, 2, 777, 1001 };
            var c = new int[] { 5, 4, 3, 2, 1 };
            var d = new int[] { 1, 0, 2, 20, 3 };
            var e = new int[] { 1, -10, 2, 3, -4 };

            var averageIndex = new AverageIndexSumsOfArray();

            ShowConsoleResults(averageIndex, a, b, c, d, e);

            ReadKey();
        }

        private static void FormatedWriteLine(int[] array, int average) =>
            WriteLine($"Array: {{ {string.Join(", ", array)} }} | Average Index: {average.ToString()}");

        private static void ShowConsoleResults(AverageIndexSumsOfArray averageIndex, params int[][] arrays)
        {
            for (int i = 0; i < arrays.Length; i++)
            {
                FormatedWriteLine(arrays[i], averageIndex.GetIndex(arrays[i]));
            }
        }
    }
}
