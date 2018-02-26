using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4Logic
{
    /// <summary>
    /// Get additional math operation
    /// </summary>
    public class MathHelper
    {
        /// <summary>
        /// Get just positive Fibonacci numbers via yield
        /// </summary>
        /// <returns></returns>
        public IEnumerable<long> GetFibonacciNumber()
        {
            long previous = 0, current = 0;

            while (true)
            {
                var next = previous + current;
                yield return next;
                previous = current;
                current = next;
            }
        }
    }
}
