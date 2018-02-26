using System.Collections.Generic;
using System.Linq;

namespace Task3Logic.Comparators
{
    /// <summary>
    /// Comparator for getting sum element from jagged array
    /// </summary>
    public class ComparatorBySum : MainComparator, IComparer<int[]>
    {
        /// <summary>
        /// Compare method for checking sum of elements
        /// </summary>
        /// <param name="x">First array</param>
        /// <param name="y">Second array</param>
        /// <returns>Compare integers</returns>
        public int Compare(int[] x, int[] y) =>
            CheckNull(x, y) ?? x.Sum().CompareTo(y.Sum());
    }
}
