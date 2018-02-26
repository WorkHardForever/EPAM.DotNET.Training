namespace Task3Logic.Comparators
{
    /// <summary>
    /// Provides main methods
    /// </summary>
    public abstract class MainComparator
    {
        /// <summary>
        /// Check arrays for null arguments
        /// </summary>
        /// <param name="array1">First array</param>
        /// <param name="array2">Second array</param>
        /// <returns>Compare integers or null, if arrays not null</returns>
        public int? CheckNull(int[] array1, int[] array2) =>
            array1 == null && array2 == null ? 0 :
            array1 == null ? -1 :
            array2 == null ? 1 : (int?)null;
    }
}
