using System;

namespace Task2Logic
{
    /// <summary>
    /// Average index of sum left and right array ranges
    /// </summary>
    public class AverageIndexSumsOfArray
    {
        #region Public Methods

        /// <summary>
        /// Find average index of left and right array ranges
        /// </summary>
        /// <param name="array">Array for searching index</param>
        /// <returns>Average index or -1 if not found</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException">Array length >= 3 requared</exception>
        public int GetIndex(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length < 3)
            {
                throw new ArgumentException("array.Length < 3");
            }

            var left = array[0];
            var right = SumRightElements(array);

            for (int i = 1; i < array.Length - 1; i++)
            {
                if (left == right)
                    return i;

                left += array[i];
                right -= array[i + 1];
            }

            return -1;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Sum right range of array from index = 2
        /// </summary>
        /// <param name="array">Integer array for sum</param>
        /// <returns>Sum elements of array from index = 2</returns>
        private int SumRightElements(int[] array)
        {
            int summer = 0;
            for (int i = 2; i < array.Length; i++)
            {
                summer += array[i];
            }

            return summer;
        }

        #endregion
    }
}
