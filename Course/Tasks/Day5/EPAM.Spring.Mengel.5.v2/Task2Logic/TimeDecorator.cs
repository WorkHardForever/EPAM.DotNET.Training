using static System.Diagnostics.Stopwatch;

namespace Task2Logic
{
    /// <summary>
    /// Get working time of some method by delegate
    /// </summary>
    public class TimeDecorator
    {
        #region Public Methods

        /// <summary>
        /// Get time in ticks of working method
        /// </summary>
        /// <param name="time">Time of work</param>
        /// <param name="method">Method for timing</param>
        /// <param name="value1">First value for method</param>
        /// <param name="value2">Second value for method</param>
        /// <returns>Method result</returns>
        public static int GetTimeOfMethodWork(out long time, GetMethodForTime method, int value1, int value2)
        {
            int resultOfMethod;
            var timer = StartNew();
            resultOfMethod = method(value1, value2);
            timer.Stop();
            time = timer.ElapsedTicks;
            return resultOfMethod;
        }

        #endregion

        #region Public Delegate

        /// <summary>
        /// Delegate for time controlling
        /// </summary>
        /// <param name="values">Arguments for method</param>
        /// <returns>Result of method</returns>
        public delegate int GetMethodForTime(params int[] values);

        #endregion
    }
}
