using System.Linq;

namespace Task1Logic
{
    /// <summary>
    /// Compare methods for sorting in jagged array
    /// </summary>
    public class JaggedArrayHelperCompareMethods
    {
        #region Public Methods

        /// <summary>
        /// Compare method for checking sum of elements
        /// </summary>
        /// <param name="array1">First array</param>
        /// <param name="array2">Second array</param>
        /// <returns>Compare integers</returns>
        public static int CompareRowSum(int[] array1, int[] array2) =>
            CheckNull(array1, array2) ?? array1.Sum().CompareTo(array2.Sum());

        /// <summary>
        /// Compare method for finding max of elements
        /// </summary>
        /// <param name="array1">First array</param>
        /// <param name="array2">Second array</param>
        /// <returns>Compare integers</returns>
        public static int CompareRowMax(int[] array1, int[] array2) =>
            CheckNull(array1, array2) ?? array1.Max().CompareTo(array2.Max());

        /// <summary>
        /// Compare method for finding min of elements
        /// </summary>
        /// <param name="array1">First array</param>
        /// <param name="array2">Second array</param>
        /// <returns>Compare integers</returns>
        public static int CompareRowMin(int[] array1, int[] array2) =>
            CheckNull(array1, array2) ?? array1.Min().CompareTo(array2.Min());

        /// <summary>
        /// Check arrays for null arguments
        /// </summary>
        /// <param name="array1">First array</param>
        /// <param name="array2">Second array</param>
        /// <returns>Compare integers or null, if arrays not null</returns>
        public static int? CheckNull(int[] array1, int[] array2) =>
            array1 == null && array2 == null ? 0 :
            array1 == null ? -1 :
            array2 == null ? 1 : (int?)null;

        #endregion
    }
}
