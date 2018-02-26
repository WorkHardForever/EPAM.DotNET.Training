namespace Task1Logic
{
    /// <summary>
    /// Class-helper for simple arrays
    /// </summary>
    public class ArrayHelper
    {
        #region Public Method

        /// <summary>
        /// Swap arrays
        /// </summary>
        /// <param name="array1">First array</param>
        /// <param name="array2">Second array</param>
        public static void Swap(ref int[] array1, ref int[] array2)
        {
            var temp = array1;
            array1 = array2;
            array2 = temp;
        }

        #endregion
    }
}
