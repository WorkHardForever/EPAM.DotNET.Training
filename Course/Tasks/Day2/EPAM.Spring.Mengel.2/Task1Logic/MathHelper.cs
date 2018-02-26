using System;
using static System.Math;

namespace Task1Logic
{
    /// <summary>
    /// Additional math class helper for double variables
    /// </summary>
    public static class MathHelper
    {
        /// <summary>
        /// Find root of number
        /// </summary>
        /// <param name="A">Value for finding root</param>
        /// <param name="n">Power of root</param>
        /// <param name="x">Start init approximation</param>
        /// <param name="delta">Epsilon-delta value (should strive for zero)</param>
        /// <returns>Root of 'A' number</returns>
        public static double SqrtByNewton(this double A, int n, double x, double delta = 1E-10)
        {
            if (A < 0)
            {
                throw new ArgumentOutOfRangeException($"Variable {nameof(A)} should be more than zero");
            }
            
            if (n < 1)
            {
                throw new ArgumentOutOfRangeException($"Variable {nameof(n)} should be more than one");
            }

            if (x < 0)
            {
                throw new ArgumentOutOfRangeException($"Variable {nameof(x)} should be more than zero");
            }

            if (delta < 0)
            {
                throw new ArgumentOutOfRangeException($"Variable {nameof(delta)} should be more than zero");
            }

            return RunNewtonAlgorithm(A, n, x, delta);
        }

        /// <summary>
        /// Newton algorithm for searching root of number
        /// </summary>
        /// <param name="A">Value for finding root</param>
        /// <param name="n">Power of root</param>
        /// <param name="x">Start init approximation</param>
        /// <param name="delta">Epsilon-delta value (should strive for zero)</param>
        /// <returns>Root of 'A' number</returns>
        private static double RunNewtonAlgorithm(double A, int n, double x, double delta = 1E-10)
        {
            var x1 = (1.0 / n) * ((n - 1) * x + A / Pow(x, n - 1));
            return Abs(x1 - x) < delta ? x1 : RunNewtonAlgorithm(A, n, x1, delta);
        }
    }
}
