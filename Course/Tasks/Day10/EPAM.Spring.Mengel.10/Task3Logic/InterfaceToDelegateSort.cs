using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3Logic
{
    /// <summary>
    /// Simple release interface to delegate
    /// </summary>
    public class InterfaceToDelegateSort
    {
        #region Public Method

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="comparer"></param>
        public static void SortBy<T>(T[] array, IComparer<T> comparer)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            SortBy(array, comparer.Compare);
        }

        #endregion

        #region Private Method

        private static void SortBy<T>(T[] array, Comparison<T> compare)
        {
            for (int i = array.Length - 1; i > 0; i--)
                for (int j = 0; j < i; j++)
                    if (compare(array[j], array[j + 1]) > 0)
                        ArrayHelper<T>.Swap(ref array[j], ref array[j + 1]);
        }

        #endregion
    }
}
