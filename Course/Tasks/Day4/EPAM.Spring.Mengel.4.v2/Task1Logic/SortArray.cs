using System.Linq;
namespace Task1Logic {
    /// <summary>Class for sorting arrays</summary>
    public class SortArray {
        #region Public Method
        /// <summary>Sort array by Merge method</summary><param name="array">Unsorted array which will sort at once</param>
        public static void MergeSort(ref int[] array) {
            if (array == null) throw new System.ArgumentNullException(nameof(array));
            array = SortByMergeMethod(array);
        }
        #endregion
        #region Private Methods
        /// <summary>Divide array and merge its blocks to sorted array</summary><param name="array">Unsorted array</param><returns>Sorted array</returns>
        private static int[] SortByMergeMethod(int[] array) => array.Length == 1 ? array : MergeArrays(SortByMergeMethod(array.Take(array.Length / 2).ToArray()), SortByMergeMethod(array.Skip(array.Length / 2).ToArray()));
        /// <summary>Merge blocks of array by comparing elements</summary><param name="array1">Array 1</param><param name="array2">Array 2</param><returns>Merged new array</returns>
        private static int[] MergeArrays(int[] array1, int[] array2) {
            int[] sortedArray = new int[array1.Length + array2.Length];
            int index1 = 0, index2 = 0, counter = 0;
            for (int i = 0; i < array1.Length + array2.Length; i++, counter++)
                if (index1 < array1.Length)
                    if (index2 < array2.Length)
                        if (array1[index1] < array2[index2]) sortedArray[counter] = array1[index1++];
                        else sortedArray[counter] = array2[index2++];
                    else sortedArray[counter] = array1[index1++];
                else sortedArray[counter] = array2[index2++];
            return sortedArray;
        }
        #endregion
    }
}
