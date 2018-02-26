using System.Collections.Generic;

namespace Task1Logic
{
    /// <summary>
    /// Contract for storage controllers
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IStorageController<T>
    {
        /// <summary>
        /// Returns all finding from list
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetItems();
        /// <summary>
        /// Add item to file
        /// </summary>
        /// <param name="item"></param>
        void AddItem(T item);
        /// <summary>
        /// Clear file from data
        /// </summary>
        void Clear();
        /// <summary>
        /// Save list of data to file
        /// </summary>
        /// <param name="list"></param>
        void SaveList(IEnumerable<T> list);
    }
}
