using System;
using static Task1Logic.ArrayHelper;

namespace Task1Logic
{
    /// <summary>
    /// Class for working with jagged array
    /// </summary>
    public class JaggedArrayHelper
    {
        #region Public Methods

        /// <summary>
        /// Sort jagged array using comparable method
        /// </summary>
        /// <param name="array">Array for sorting</param>
        /// <param name="compareRows">Method for compare inside arrays</param>
        public static void SortBy(int[][] array, CompareRowsMethod compareRows)
        {
            CheckArrayToNull(array);
            SortByMethod(array, compareRows);
        }

        #endregion

        #region Private Methods

        private static void CheckArrayToNull(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
        }

        /// <summary>
        /// Sort method which use delegate method for compare row elements
        /// </summary>
        /// <param name="array"></param>
        /// <param name="compareRows"></param>
        private static void SortByMethod(int[][] array, CompareRowsMethod compareRows)
        {
            for (int i = array.Length - 1; i > 0; i--)
                for (int j = 0; j < i; j++)
                    if (compareRows(array[j], array[j + 1]) > 0)
                        Swap(ref array[j], ref array[j + 1]);
        }

        #endregion

        #region Public delegate

        /// <summary>
        /// Use for compare row elements
        /// </summary>
        /// <remarks>You can use made methods from 'JaggedArrayHelperCompareMethods'</remarks>
        /// <param name="array1">First array</param>
        /// <param name="array2">Second array</param>
        /// <returns>Compare result</returns>
        public delegate int CompareRowsMethod(int[] array1, int[] array2);

        #endregion
    }
}
