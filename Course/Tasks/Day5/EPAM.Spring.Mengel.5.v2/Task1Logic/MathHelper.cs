using System;
using static System.Math;

namespace Task1Logic
{
    /// <summary>
    /// Additional math class helper for double variables
    /// </summary>
    public class MathHelper
    {
        #region Public Method

        /// <summary>
        /// Find root of number
        /// </summary>
        /// <param name="A">Value for finding root</param>
        /// <param name="n">Power of root</param>
        /// <param name="x">Start init approximation</param>
        /// <param name="delta">Epsilon-delta value (should strive for zero)</param>
        /// <returns>Root of 'A' number</returns>
        public static double Sqrt(double A, int n, double x, double delta = 1E-10)
        {
            CheckArguments(A, n, x, delta);
            return RunNewtonAlgorithm(A, n, x, delta);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Check arguments for sqrt method
        /// </summary>
        /// <param name="A">Value for finding root</param>
        /// <param name="n">Power of root</param>
        /// <param name="x">Start init approximation</param>
        /// <param name="delta">Epsilon-delta value (should strive for zero)</param>
        private static void CheckArguments(double A, int n, double x, double delta = 1E-10)
        {
            if (A < 0)
                throw new ArgumentOutOfRangeException($"Variable {nameof(A)} should be more then zero");

            if (n < 1)
                throw new ArgumentOutOfRangeException($"Variable {nameof(n)} should be more then one");

            if (x < 0)
                throw new ArgumentOutOfRangeException($"Variable {nameof(x)} should be more then zero");

            if (delta < 0)
                throw new ArgumentOutOfRangeException($"Variable {nameof(delta)} should be more then zero");
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

        #endregion
    }
}
