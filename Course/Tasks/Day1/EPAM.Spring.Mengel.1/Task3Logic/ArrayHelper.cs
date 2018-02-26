using System;
using System.Collections.Generic;
using System.Linq;
using static System.Array;

namespace Task3Logic
{
    /// <summary>
    /// Help for all array to release extension methods
    /// </summary>
    public static class ArrayHelper
    {
        #region Public Methods

        /// <summary>
        /// Divide array to sorted elements and recurse sort them
        /// </summary>
        /// <param name="array">Unsorted array of type T</param>
        /// <returns>Sorted array</returns>
        public static T[] SortByMergeMethod<T>(this T[] array)
            where T : IComparable =>
            DivideElements(array, SortByMergeArray);

        /// <summary>
        /// Sort all elements from array and remove repeated
        /// </summary>
        /// <param name="array">Unsorted array of type T</param>
        /// <returns>Sorted array with non repeated elements</returns>
        public static T[] SortToUnrepeatedItems<T>(this T[] array)
            where T : IComparable =>
            DivideElements(array, SortNotRepeatedArray);

        #endregion

        #region Private Methods

        /// <summary>
        /// Divide recurse array and make with elements function
        /// </summary>
        /// <typeparam name="T">IComparable type</typeparam>
        /// <param name="array">Array of T type</param>
        /// <param name="func">Function for working with elements</param>
        /// <returns>Result of 'func' parameter</returns>
        private static T[] DivideElements<T>(T[] array, Func<T[], T[], T[]> func)
            where T : IComparable
        {
            if (array.Length == 1)
                return array;

            var middleIndex = array.Length / 2;

            return func(
                DivideElements(array.Take(middleIndex).ToArray(), func),
                DivideElements(array.Skip(middleIndex).ToArray(), func));
        }

        /// <summary>
        /// Sort 2 arrays by merge them
        /// </summary>
        /// <param name="array1">Array 1</param>
        /// <param name="array2">Array 2</param>
        /// <returns>Sorted merged array</returns>
        private static T[] SortByMergeArray<T>(T[] array1, T[] array2)
            where T : IComparable =>
            MergeArrays(array1, array2, CompareElements);

        /// <summary>
        /// Sort 2 arrays by merge them and deleting repeated elements
        /// </summary>
        /// <param name="array1">Array 1</param>
        /// <param name="array2">Array 2</param>
        /// <returns>Sorted to merged array</returns>
        private static T[] SortNotRepeatedArray<T>(T[] array1, T[] array2)
            where T : IComparable =>
            MergeArrays(array1, array2, CompareWithNonRepeatedElements);

        /// <summary>
        /// Unit 2 arrays by 'func' parameter
        /// </summary>
        /// <typeparam name="T">IComparable type</typeparam>
        /// <param name="array1">Array 1</param>
        /// <param name="array2">Array 2</param>
        /// <param name="func">Function for working with elements</param>
        /// <returns>Sorted array</returns>
        private static T[] MergeArrays<T>(T[] array1, T[] array2, ItemOparationOfArrays<T> func)
            where T : IComparable
        {
            var sumLength = array1.Length + array2.Length;
            var sortedArray = new T[sumLength];
            var indexOfArray1 = 0;
            var indexOfArray2 = 0;
            var counter = 0;

            for (int i = 0; i < sumLength; i++, counter++)
            {
                var funcResult = func(array1, array2, ref indexOfArray1, ref indexOfArray2);
                if (!EqualityComparer<T>.Default.Equals(funcResult, default(T)))
                    sortedArray[counter] = funcResult;
                else
                    counter--;
            }

            if (counter != 0)
                Resize(ref sortedArray, counter);

            return sortedArray;
        }

        /// <summary>
        /// Compare elements and get ascending element by indexes of arrays
        /// </summary>
        /// <typeparam name="T">IComparable type</typeparam>
        /// <param name="array1">Array 1</param>
        /// <param name="array2">Array 2</param>
        /// <param name="indexOfArray1">Index of 'array1'</param>
        /// <param name="indexOfArray2">Index of 'array2'</param>
        /// <returns>Element of compare</returns>
        private static T CompareElements<T>(T[] array1, T[] array2, ref int indexOfArray1, ref int indexOfArray2)
            where T : IComparable
        {
            if (indexOfArray2.CompareTo(array2.Length) < 0 && indexOfArray1.CompareTo(array1.Length) < 0)
            {
                if (array1[indexOfArray1].CompareTo(array2[indexOfArray2]) > 0)
                    return array2[indexOfArray2++];
                else
                    return array1[indexOfArray1++];
            }
            else
            {
                if (indexOfArray2 < array2.Length)
                    return array2[indexOfArray2++];
                else
                    return array1[indexOfArray1++];
            }
        }

        /// <summary>
        /// Compare elements and get 'null' if elements by indexes of arrays are equivalent
        /// </summary>
        /// <typeparam name="T">IComparable type</typeparam>
        /// <param name="array1">Array 1</param>
        /// <param name="array2">Array 2</param>
        /// <param name="indexOfArray1">Index of 'array1'</param>
        /// <param name="indexOfArray2">Index of 'array2'</param>
        /// <returns>Element of compare or 'null'</returns>
        private static T CompareWithNonRepeatedElements<T>(T[] array1, T[] array2, ref int indexOfArray1, ref int indexOfArray2)
            where T : IComparable
        {
            if (indexOfArray2.CompareTo(array2.Length) < 0 && indexOfArray1.CompareTo(array1.Length) < 0)
            {
                if (array1[indexOfArray1].CompareTo(array2[indexOfArray2]) == 0)
                {
                    indexOfArray1++;
                    return default(T);
                }
                else if (array1[indexOfArray1].CompareTo(array2[indexOfArray2]) > 0)
                    return array2[indexOfArray2++];
                else
                    return array1[indexOfArray1++];
            }
            else
            {
                if (indexOfArray2 < array2.Length)
                    return array2[indexOfArray2++];
                else
                    return array1[indexOfArray1++];
            }
        }

        #endregion

        #region Private Delegate

        /// <summary>
        /// Requared for working with arrays and them elements
        /// </summary>
        /// <typeparam name="T">IComparable type</typeparam>
        /// <param name="array1">Array 1</param>
        /// <param name="array2">Array 2</param>
        /// <param name="indexOfArray1">Index of 'array1'</param>
        /// <param name="indexOfArray2">Index of 'array2'</param>
        /// <returns>Element or 'null'</returns>
        private delegate T ItemOparationOfArrays<T>(T[] array1, T[] array2, ref int indexOfArray1, ref int indexOfArray2)
            where T : IComparable;

        #endregion
    }
}
