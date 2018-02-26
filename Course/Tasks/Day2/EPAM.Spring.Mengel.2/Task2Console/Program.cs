using static Task2Logic.GCD;
using static System.Console;

namespace Task2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            long ticks;
            WriteLine("Stain algorithm:");
            WriteLine($"GCD(1071, 462) = {GetGcdByEuclideanAlgorithmWithCompleteTime(out ticks, 1071, 462).ToString()} => {ticks.ToString()} {nameof(ticks)}");
            WriteLine($"GCD(-2048, -19) = {GetGcdByStainAlgorithmWithCompleteTime(out ticks, -2048, -19).ToString()} => {ticks.ToString()} {nameof(ticks)}");
            WriteLine($"GCD(123, 333) = {GetGcdByEuclideanAlgorithmWithCompleteTime(out ticks, 123, 333).ToString()} => {ticks.ToString()} {nameof(ticks)}");
            WriteLine($"GCD(3208, 462) = {GetGcdByStainAlgorithmWithCompleteTime(out ticks, 3208, 462).ToString()} => {ticks.ToString()} {nameof(ticks)}");
            WriteLine($"GCD(0, 100) = {GetGcdByEuclideanAlgorithmWithCompleteTime(out ticks, 0, 100).ToString()} => {ticks.ToString()} {nameof(ticks)}");
            WriteLine($"GCD(0, 730) = {GetGcdByStainAlgorithmWithCompleteTime(out ticks, 0, 730).ToString()} => {ticks.ToString()} {nameof(ticks)}");
            WriteLine($"GCD(107, 1203544462, 2124982547) = {GetGcdByEuclideanAlgorithmWithCompleteTime(out ticks, 107, 1203544462, 2124982547).ToString()} => {ticks.ToString()} {nameof(ticks)}");
            WriteLine($"GCD(100, 1071541340, 2121234550) = {GetGcdByStainAlgorithmWithCompleteTime(out ticks, 100, 1071541340, 2121234550).ToString()} => {ticks.ToString()} {nameof(ticks)}");
            WriteLine($"GCD(543215, 486130, 784320) = {GetGcdByEuclideanAlgorithmWithCompleteTime(out ticks, 543215, 486130, 784320).ToString()} => {ticks.ToString()} {nameof(ticks)}");
            WriteLine($"GCD(153060, 952135, 320560) = {GetGcdByStainAlgorithmWithCompleteTime(out ticks, 153060, 952135, 320560).ToString()} => {ticks.ToString()} {nameof(ticks)}");

            ReadKey();
        }
    }
}
