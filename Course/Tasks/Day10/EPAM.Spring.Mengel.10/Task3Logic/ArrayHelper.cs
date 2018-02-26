namespace Task3Logic
{
    /// <summary>
    /// Class-helper for simple arrays
    /// </summary>
    public class ArrayHelper<T>
    {
        #region Public Method

        /// <summary>
        /// Swap arrays
        /// </summary>
        /// <param name="array1">First array</param>
        /// <param name="array2">Second array</param>
        public static void Swap(ref T array1, ref T array2)
        {
            var temp = array1;
            array1 = array2;
            array2 = temp;
        }

        #endregion
    }
}
