using System;
using System.Collections.Generic;
using System.IO;
using NLog;

namespace Task1Logic
{
    /// <summary>
    /// File storage for enumerables
    /// </summary>
    /// <typeparam name="T">List item type</typeparam>
    public class FileListStorageController<T> : IStorageController<T>
    {
        #region Private Readonly Fields

        private readonly Logger _logger;

        #endregion

        #region Constructor

        /// <summary>
        /// Try exist file by filepath and initialize values
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="data"></param>
        public FileListStorageController(string filePath, IDataSaver<T> data)
        {
            _logger = LogManager.GetCurrentClassLogger();

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
        public IEnumerable<T> GetItems()
        {
            IEnumerable<T> result;
            try
            {
                result = GetListFromFile();
            }
            catch (FileNotFoundException ex)
            {
                _logger.Error($"Try open file from {FilePath} but not found: {ex}");
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// Add item to file
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(T item)
        {
            if (item == null)
                throw new ArgumentNullException();

            try
            {
                AddItemToFile(item);
            }
            catch (NotSupportedException ex)
            {
                _logger.Error($"If read fail: {ex}");
                throw;
            }
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
            _logger.Debug("Start CheckFilePath method");

            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("Argument is null or empty");

            if (!File.Exists(filePath))
                throw new FileNotFoundException(nameof(FilePath));

            _logger.Debug("End CheckFilePath method");

            FilePath = filePath;
        }

        /// <summary>
        /// Get list of items from file
        /// </summary>
        /// <returns></returns>
        private IEnumerable<T> GetListFromFile()
        {
            _logger.Debug("Start GetListFromFile method");

            var list = new List<T>();
            var fileStream = File.Open(FilePath, FileMode.Open, FileAccess.Read);
            using (var reader = new BinaryReader(fileStream))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    list.Add(Data.LoadFileData(reader));
                }
            }

            _logger.Debug("End GetListFromFile method");

            return list;
        }

        /// <summary>
        /// Add item to file
        /// </summary>
        /// <param name="item"></param>
        private void AddItemToFile(T item)
        {
            _logger.Debug("Start AddItemToFile method");

            var fileStream = File.Open(FilePath, FileMode.Append, FileAccess.Write);
            using (var writer = new BinaryWriter(fileStream))
            {
                Data.SaveFileData(writer, item);
            }

            _logger.Debug("End AddItemToFile method");
        }

        /// <summary>
        /// Save list of data to file
        /// </summary>
        /// <param name="list"></param>
        public void SaveListToFile(IEnumerable<T> list)
        {
            _logger.Debug("Start SaveListToFile method");

            var fileStream = File.Open(FilePath, FileMode.Truncate, FileAccess.Write);
            using (var writer = new BinaryWriter(fileStream))
            {
                foreach (var item in list)
                {
                    Data.SaveFileData(writer, item);
                }
            }

            _logger.Debug("End SaveListToFile method");
        }

        #endregion
    }
}
