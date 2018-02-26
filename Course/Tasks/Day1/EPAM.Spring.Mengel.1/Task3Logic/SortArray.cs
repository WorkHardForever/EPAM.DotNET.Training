using System;

namespace Task3Logic
{
    /// <summary>
    /// Class for sorting array
    /// </summary>
    public class SortArray<T> where T : IComparable
    {
        #region Public Method

        /// <summary>
        /// Sort array by Merge method
        /// </summary>
        /// <param name="array">Unsorted array of type T</param>
        /// <returns>Sorted array</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public T[] MergeSort(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            return array.SortByMergeMethod();
        }

        #endregion
    }
}
