using System.IO;

namespace Task2Logic
{
    /// <summary>
    /// Helper for FileListStorageController
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataSaver<T>
    {
        /// <summary>
        /// Save data to file by binary reader
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        void SaveFileData(BinaryWriter writer, T value);
        /// <summary>
        /// Load data from file by binary reader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        T LoadFileData(BinaryReader reader);
    }
}
