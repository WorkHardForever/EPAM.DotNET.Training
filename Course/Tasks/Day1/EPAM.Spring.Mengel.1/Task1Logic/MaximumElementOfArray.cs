using System;
using static System.Math;

namespace Task1Logic
{
    /// <summary>
    /// Maximum element of unsorted array and methods with it
    /// </summary>
    public class MaximumElementOfArray
    {
        #region Public Method

        /// <summary>
        /// Find maximum element in unsorted integer array
        /// </summary>
        /// <param name="array">Unsorted integer array</param>
        /// <returns>Maximum element from input array></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int Find(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            return RecurseSearch(0, array);
        }

        #endregion

        #region Private Method

        /// <summary>
        /// Find element by recurse finding
        /// </summary>
        /// <param name="item">Current item of array</param>
        /// <param name="array">Array for searching max element</param>
        /// <returns>Last element or maximum of current and next searching elements</returns>
        private int RecurseSearch(int item, int[] array) =>
            item < array.Length - 1 ?
            Max(array[item], RecurseSearch(++item, array)) :
            array[item];

        #endregion
    }
}
