using NLog;
using System;
using System.Collections.Generic;

namespace Task1Logic
{
    /// <summary>
    /// Book's collection
    /// </summary>
    public class BookListService : IBookListService
    {
        #region Private Readonly Fields

        private readonly Logger _logger;

        #endregion

        #region Constructor

        /// <summary>
        /// Initialize book's collection and storage for it
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="storage"></param>
        public BookListService(string filePath, IStorageController<Book> storage)
        {
            _logger = LogManager.GetCurrentClassLogger();

            Storage = storage;
            ListOfBooks = Storage.GetItems() as List<Book> ?? new List<Book>();

        }

        #endregion

        #region Properties

        /// <summary>
        /// Book's collection
        /// </summary>
        public List<Book> ListOfBooks { get; private set; }
        /// <summary>
        /// Storage for book's list
        /// </summary>
        public IStorageController<Book> Storage { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add book to collection and storage
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Book book)
        {
            if (hasFindedItem(book))
                throw new ArgumentException("Such book consist in the repositiry");

            AddItem(book);
        }

        /// <summary>
        /// Remove book from collection and storage
        /// </summary>
        /// <param name="book"></param>
        public void RemoveBook(Book book)
        {
            if (!hasFindedItem(book))
                throw new ArgumentException("Such book not consist in the repositiry");

            RemoveItem(book);
        }

        /// <summary>
        /// Find book by tag: name, author and ect. with value
        /// </summary>
        /// <param name="tagSentese">Use 'nameof()' with book's fields</param>
        /// <returns>Book of searching</returns>
        public List<Book> FindByTag(Predicate<Book> tagSentese) =>
            ListOfBooks.FindAll(tagSentese);

        /// <summary>
        /// Sort collection by book's field and hold this to storage
        /// </summary>
        /// <param name="tagSentese"></param>
        public void SortBooksByTag(Comparison<Book> tagSentese)
        {
            try
            {
                ListOfBooks.Sort(tagSentese);
            }
            catch (ArgumentException ex)
            {
                _logger.Fatal($"Not sorted such list by tagSentense: {ex}");
                throw ex;
            }
            WriteNewListToFile();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Try find item in collection
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        private bool hasFindedItem(Book book)
        {
            bool isExist;
            try
            {
                isExist = ListOfBooks.Exists(x => x.Equals(book));
            }
            catch (ArgumentNullException ex)
            {
                _logger.Error($"Can't check exist file: {ex}");
                throw ex;
            }

            return isExist;
        }

        /// <summary>
        /// Add book to collection and storage
        /// </summary>
        /// <param name="book"></param>
        private void AddItem(Book book)
        {
            try
            {
                ListOfBooks.Add(book);
                Storage.AddItem(book);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        /// <summary>
        /// Remove book from collection and storage
        /// </summary>
        /// <param name="book"></param>
        private void RemoveItem(Book book)
        {
            ListOfBooks.Remove(book);
            WriteNewListToFile();
        }

        /// <summary>
        /// Rewrite new list to file
        /// </summary>
        private void WriteNewListToFile()
        {
            Storage.Clear();
            Storage.SaveList(ListOfBooks);
        }

        #endregion
    }
}