using System;
using System.Collections.Generic;

namespace Task2Logic
{
    /// <summary>
    /// Contract for book list service
    /// </summary>
    public interface IBookListService
    {
        /// <summary>
        /// Main list of books
        /// </summary>
        List<Book> ListOfBooks { get; }
        /// <summary>
        /// Storage for list of books
        /// </summary>
        IStorageController<Book> Storage { get; }
        /// <summary>
        /// Add book to list and storage
        /// </summary>
        /// <param name="book"></param>
        void AddBook(Book book);
        /// <summary>
        /// Remove book from list and storage
        /// </summary>
        /// <param name="book"></param>
        void RemoveBook(Book book);
        /// <summary>
        /// Get list of books which will found by tag
        /// </summary>
        /// <param name="tagSentese"></param>
        /// <returns></returns>
        List<Book> FindByTag(Predicate<Book> tagSentese);
        /// <summary>
        /// Sort books in list and storage
        /// </summary>
        /// <param name="tagSentese"></param>
        void SortBooksByTag(Comparison<Book> tagSentese);
    }
}
