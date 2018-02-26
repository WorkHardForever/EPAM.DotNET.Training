using System;
using System.Collections.Generic;
using System.IO;

namespace Task2Logic
{
    /// <summary>
    /// File storage for enumerables
    /// </summary>
    /// <typeparam name="T">List item type</typeparam>
    public class FileListStorageController<T> : IStorageController<T>
    {
        #region Constructor

        /// <summary>
        /// Try exist file by filepath and initialize values
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="data"></param>
        public FileListStorageController(string filePath, IDataSaver<T> data)
        {
            CheckFilePath(filePath);
            Data = data;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Path of working file
        /// </summary>
        public string FilePath { get; private set; }
        /// <summary>
        /// Class for write/read data from file
        /// </summary>
        public IDataSaver<T> Data { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get list of items from file
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetItems() =>
            GetListFromFile();

        /// <summary>
        /// Add item to file
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(T item)
        {
            if (item == null)
                throw new ArgumentNullException();

            AddItemToFile(item);
        }

        /// <summary>
        /// Clear file from data
        /// </summary>
        public void Clear() =>
            File.WriteAllText(FilePath, string.Empty);

        /// <summary>
        /// Save list of data to file
        /// </summary>
        /// <param name="list"></param>
        public void SaveList(IEnumerable<T> list) =>
            SaveListToFile(list);

        #endregion

        #region Private Methods

        /// <summary>
        /// Try exist file by filepath
        /// </summary>
        /// <param name="filePath"></param>
        private void CheckFilePath(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("Argument is null or empty");

            if (!File.Exists(filePath))
                throw new FileNotFoundException(nameof(FilePath));

            FilePath = filePath;
        }

        /// <summary>
        /// Get list of items from file
        /// </summary>
        /// <returns></returns>
        private IEnumerable<T> GetListFromFile()
        {
            var list = new List<T>();
            var fileStream = File.Open(FilePath, FileMode.Open, FileAccess.Read);
            using (var reader = new BinaryReader(fileStream))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    list.Add(Data.LoadFileData(reader));
                }
            }

            return list;
        }

        /// <summary>
        /// Add item to file
        /// </summary>
        /// <param name="item"></param>
        private void AddItemToFile(T item)
        {
            var fileStream = File.Open(FilePath, FileMode.Append, FileAccess.Write);
            using (var writer = new BinaryWriter(fileStream))
            {
                Data.SaveFileData(writer, item);
            }
        }

        /// <summary>
        /// Save list of data to file
        /// </summary>
        /// <param name="list"></param>
        public void SaveListToFile(IEnumerable<T> list)
        {
            var fileStream = File.Open(FilePath, FileMode.Truncate, FileAccess.Write);
            using (var writer = new BinaryWriter(fileStream))
            {
                foreach (var item in list)
                {
                    Data.SaveFileData(writer, item);
                }
            }
        }

        #endregion
    }
}
