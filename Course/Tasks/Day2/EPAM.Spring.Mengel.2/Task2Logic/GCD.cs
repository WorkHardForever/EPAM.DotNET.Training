using System;
using static System.Math;
using static System.Diagnostics.Stopwatch;

namespace Task2Logic
{
    /// <summary>
    /// Class for searching GCD by algorithms
    /// with checking time of working them
    /// </summary>
    public class GCD
    {
        #region Public Methods

        #region Euclidean Algorithm

        /// <summary>
        /// Get GCD using Euclidian algorithm and getting time of work this method
        /// </summary>
        /// <param name="time">Time of working algorithm</param>
        /// <param name="value1">First value</param>
        /// <param name="value2">Second value</param>
        /// <returns>GCD of those values</returns>
        public static int GetGcdByEuclideanAlgorithmWithCompleteTime(out long time, int value1, int value2)
        {
            int result;
            var timer = StartNew();
            result = GetGcdByEuclideanAlgorithm(value1, value2);
            timer.Stop();
            time = timer.ElapsedTicks;
            return result;
        }

        /// <summary>
        /// Get GCD using Euclidian algorithm and getting time of work this method
        /// </summary>
        /// <param name="time">Time of working algorithm</param>
        /// <param name="value1">First value</param>
        /// <param name="value2">Second value</param>
        /// <param name="value3">Third value</param>
        /// <returns>GCD of those values</returns>
        public static int GetGcdByEuclideanAlgorithmWithCompleteTime(out long time, int value1, int value2, int value3)
        {
            int result;
            var timer = StartNew();
            result = GetGcdByEuclideanAlgorithm(value1, value2, value3);
            timer.Stop();
            time = timer.ElapsedTicks;
            return result;
        }

        /// <summary>
        /// Get GCD using Euclidian algorithm and getting time of work this method
        /// </summary>
        /// <param name="time">Time of working algorithm</param>
        /// <param name="values">Array of values</param>
        /// <returns>GCD of those values</returns>
        public static int GetGcdByEuclideanAlgorithmWithCompleteTime(out long time, params int[] values)
        {
            int result;
            var timer = StartNew();
            result = GetGcdByEuclideanAlgorithm(values);
            timer.Stop();
            time = timer.ElapsedTicks;
            return result;
        }

        /// <summary>
        /// Get GCD using Euclidian algorithm
        /// </summary>
        /// <param name="value1">First value</param>
        /// <param name="value2">Second value</param>
        /// <returns>GCD of those values</returns>
        public static int GetGcdByEuclideanAlgorithm(int value1, int value2)
        {
            if (value1 == value2)
                return value1;

            if (value1 == 0 && value2 == 0)
                throw new ArgumentException("GCD tends to infinity and can't be contained to int");

            if (value1 == 0)
                return value2;

            if (value2 == 0)
                return value1;

            if (value1 < 0)
                value1 = Abs(value1);

            if (value2 < 0)
                value2 = Abs(value2);

            if (value1 > value2)
                return FindGcdUsingEuclideanAlgorithm(value1, value2);
            else
                return FindGcdUsingEuclideanAlgorithm(value2, value1);
        }

        /// <summary>
        /// Get GCD using Euclidian algorithm
        /// </summary>
        /// <param name="value1">First value</param>
        /// <param name="value2">Second value</param>
        /// <param name="value3">Third value</param>
        /// <returns>GCD of those values</returns>
        public static int GetGcdByEuclideanAlgorithm(int value1, int value2, int value3) =>
            GetGcdByEuclideanAlgorithm(value1, GetGcdByEuclideanAlgorithm(value2, value3));

        /// <summary>
        /// Get GCD using Euclidian algorithm
        /// </summary>
        /// <param name="values">Array of values</param>
        /// <returns>GCD of those values</returns>
        public static int GetGcdByEuclideanAlgorithm(params int[] values)
        {
            var result = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                result = GetGcdByEuclideanAlgorithm(result, values[i]);
            }

            return result;
        }

        #endregion

        #region Stain Algorithm

        /// <summary>
        /// Get GCD using Stain algorithm and getting time of work this method
        /// </summary>
        /// <param name="time">Time of working algorithm</param>
        /// <param name="value1">First value</param>
        /// <param name="value2">Second value</param>
        /// <returns>GCD of those values</returns>
        public static int GetGcdByStainAlgorithmWithCompleteTime(out long time, int value1, int value2)
        {
            int result;
            var timer = StartNew();
            result = GetGcdByStainAlgorithm(value1, value2);
            timer.Stop();
            time = timer.ElapsedTicks;
            return result;
        }

        /// <summary>
        /// Get GCD using Stain algorithm and getting time of work this method
        /// </summary>
        /// <param name="time">Time of working algorithm</param>
        /// <param name="value1">First value</param>
        /// <param name="value2">Second value</param>
        /// <param name="value3">Third value</param>
        /// <returns>GCD of those values</returns>
        public static int GetGcdByStainAlgorithmWithCompleteTime(out long time, int value1, int value2, int value3)
        {
            int result;
            var timer = StartNew();
            result = GetGcdByStainAlgorithm(value1, value2, value3);
            timer.Stop();
            time = timer.ElapsedTicks;
            return result;
        }

        /// <summary>
        /// Get GCD using Stain algorithm and getting time of work this method
        /// </summary>
        /// <param name="time">Time of working algorithm</param>
        /// <param name="values">Array of values</param>
        /// <returns>GCD of those values</returns>
        public static int GetGcdByStainAlgorithmWithCompleteTime(out long time, params int[] values)
        {
            int result;
            var timer = StartNew();
            result = GetGcdByStainAlgorithm(values);
            timer.Stop();
            time = timer.ElapsedTicks;
            return result;
        }

        /// <summary>
        /// Get GCD using Stain algorithm
        /// </summary>
        /// <param name="value1">First value</param>
        /// <param name="value2">Second value</param>
        /// <returns>GCD of those values</returns>
        public static int GetGcdByStainAlgorithm(int value1, int value2)
        {
            if (value1 == 0 && value2 == 0)
                throw new ArgumentException("GCD tends to infinity and can't be contained to int");

            if (value1 < 0)
                value1 = Abs(value1);

            if (value2 < 0)
                value2 = Abs(value2);

            return FindGcdUsingStainAlgorithm(value1, value2);
        }

        /// <summary>
        /// Get GCD using Stain algorithm
        /// </summary>
        /// <param name="value1">First value</param>
        /// <param name="value2">Second value</param>
        /// <param name="value3">Third value</param>
        /// <returns>GCD of those values</returns>
        public static int GetGcdByStainAlgorithm(int value1, int value2, int value3) =>
            GetGcdByStainAlgorithm(value1, GetGcdByStainAlgorithm(value2, value3));

        /// <summary>
        /// Get GCD using Stain algorithm
        /// </summary>
        /// <param name="values">Array of values</param>
        /// <returns>GCD of those values</returns>
        public static int GetGcdByStainAlgorithm(params int[] values)
        {
            var result = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                result = GetGcdByStainAlgorithm(result, values[i]);
            }

            return result;
        }

        #endregion

        #endregion

        #region Private Methods

        /// <summary>
        /// Euclidean algorithm for searching GCD
        /// </summary>
        /// <param name="value1">First value</param>
        /// <param name="value2">Second value</param>
        /// <returns>Get GCD of those values</returns>
        private static int FindGcdUsingEuclideanAlgorithm(int value1, int value2)
        {
            var remainder = value1 % value2;
            return remainder == 0 ? value2 : FindGcdUsingEuclideanAlgorithm(value2, remainder);
        }

        /// <summary>
        /// Stain algorithm for searching GCD
        /// </summary>
        /// <param name="value1">First value</param>
        /// <param name="value2">Second value</param>
        /// <returns>Get GCD of those values</returns>
        private static int FindGcdUsingStainAlgorithm(int value1, int value2) =>
            value1 == value2 ? value1 :
            value1 == 0 ? value2 :
            value2 == 0 ? value1 :
            value1 == 1 || value2 == 1 ? 1 :
            (value1 % 2 == 0) && (value2 % 2 == 0) ? FindGcdUsingStainAlgorithm(value1 >> 1, value2 >> 1) << 1 :
            (value1 % 2 == 0) && (value2 % 2 != 0) ? FindGcdUsingStainAlgorithm(value1 >> 1, value2) :
            (value1 % 2 != 0) && (value2 % 2 == 0) ? FindGcdUsingStainAlgorithm(value1, value2 >> 1) :
            value1 > value2 ? FindGcdUsingStainAlgorithm((value1 - value2) >> 1, value2) :
            FindGcdUsingStainAlgorithm(value1, (value2 - value1) >> 1);

        #endregion
    }
}
