using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Logic.Comparators
{
    /// <summary>
    /// Comparator for getting max element from jagged array
    /// </summary>
    public class ComparatorByMaxElement : MainComparator, IComparer<int[]>
    {
        /// <summary>
        /// Compare method for finding max of elements
        /// </summary>
        /// <param name="x">First array</param>
        /// <param name="y">Second array</param>
        /// <returns>Compare integers</returns>
        public int Compare(int[] x, int[] y) =>
            CheckNull(x, y) ?? x.Max().CompareTo(y.Max());
    }
}
