using System;
using System.Collections.Generic;

namespace Task3Logic
{
    /// <summary>
    /// Simple release delegate to interface
    /// </summary>
    public class DelegateToInterfaceSort
    {
        #region Public Method

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="compare"></param>
        public static void SortBy<T>(T[] array, Comparison<T> compare)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (compare == null)
                throw new ArgumentNullException(nameof(compare));

            SortBy(array, Comparer<T>.Create(compare));
        }

        #endregion

        #region Private Method
        
        private static void SortBy<T>(T[] array, IComparer<T> comparator)
        {
            for (int i = array.Length - 1; i > 0; i--)
                for (int j = 0; j < i; j++)
                    if (comparator.Compare(array[j], array[j + 1]) > 0)
                        ArrayHelper<T>.Swap(ref array[j], ref array[j + 1]);
        }

        #endregion
    }
}
