using static System.Console;
using static Task1Logic.JaggedArrayHelper;
using static Task1Logic.JaggedArrayHelperCompareMethods;

namespace Task1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[][]
            {
                new[] { 1, 2, 3, 4, 5 },
                new[] { 9, -10, 11, -12 },
                new[] { 0 },
                null,
                new[] { -15, 15 }
            };

            PrintJeggedArray(array);

            SortBy(array, CompareRowSum);

            WriteLine("---");
            PrintJeggedArray(array);

            ReadKey();
        }

        public static void PrintJeggedArray(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                WriteLine(string.Format("{{ {0} }}", array[i] == null ? "null" : string.Join(", ", array[i])));
            }
        }
    }
}
