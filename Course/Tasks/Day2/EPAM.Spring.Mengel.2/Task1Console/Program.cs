using Task1Logic;
using static System.Console;
using static System.Math;

namespace Task1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 117649;
            int n = 6;
            double startX = 2;
            double delta = 1E-10;
            var resultX = a.SqrtByNewton(n, startX, delta);

            WriteLine($"By Newton we get: {a} = {resultX} ^ {n}");

            var checkA = Pow(resultX, n);

            WriteLine($"Math.Pow({resultX}, {n}) = {checkA}");

            if (checkA == a)
                WriteLine($"Sqrt method work fine: {checkA} == {a}");
            else
                WriteLine($"Get a mistake: {checkA} != {a}");
            
            ReadKey();
        }
    }
}
