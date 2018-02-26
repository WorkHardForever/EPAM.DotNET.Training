using System.IO;

namespace Task1Logic
{
    /// <summary>
    /// Class need for extend a FileStorageController
    /// </summary>
    public class BookFileStorageHelper : IDataSaver<Book>
    {
        #region Public Methods

        /// <summary>
        /// Read propties from file
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>Book's fields from file</returns>
        public Book LoadFileData(BinaryReader reader) =>
            new Book(
                author: reader.ReadString(),
                name: reader.ReadString(),
                genre: reader.ReadString(),
                year: reader.ReadInt32(),
                pages: reader.ReadInt32()
            );

        /// <summary>
        /// Save book's fields to file
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value">Book for saving</param>
        public void SaveFileData(BinaryWriter writer, Book value)
        {
            writer.Write(value.Author);
            writer.Write(value.Name);
            writer.Write(value.Genre);
            writer.Write(value.Year);
            writer.Write(value.Pages);
        }

        #endregion
    }
}
