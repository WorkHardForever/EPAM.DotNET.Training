using System;

namespace Task2Logic
{
    /// <summary>
    /// POCO Book class
    /// </summary>
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        #region Constructor

        /// <summary>
        /// Initialize all main features
        /// </summary>
        /// <param name="author"></param>
        /// <param name="name"></param>
        /// <param name="genre"></param>
        /// <param name="year"></param>
        /// <param name="pages"></param>
        public Book(string author, string name, string genre, int year, int pages)
        {
            Author = author;
            Name = name;
            Genre = genre;
            Year = year;
            Pages = pages;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Book's author
        /// </summary>
        public string Author { get; private set; }
        /// <summary>
        /// Name of this book
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Genre of the book
        /// </summary>
        public string Genre { get; private set; }
        /// <summary>
        /// Year edition
        /// </summary>
        public int Year { get; private set; }
        /// <summary>
        /// Number of pages
        /// </summary>
        public int Pages { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get equals of similar book
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Book other) =>
            IsEquals(other);

        /// <summary>
        /// Get equals of similar book
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) =>
            IsEquals(obj as Book);

        /// <summary>
        /// Returns the hash code for this instance
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() =>
            Author.GetHashCode() ^
            Name.GetHashCode() ^
            Genre.GetHashCode() ^
            Year.GetHashCode() ^
            Pages.GetHashCode();

        /// <summary>
        /// Get compare the book's names
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Book other) =>
            IsCompareTo(other);

        #endregion

        #region Operators

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book1"></param>
        /// <param name="book2"></param>
        /// <returns></returns>
        public static bool operator ==(Book book1, Book book2) =>
            book1.Equals(book2);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book1"></param>
        /// <param name="book2"></param>
        /// <returns></returns>
        public static bool operator !=(Book book1, Book book2) =>
            !(book1 == book2);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book1"></param>
        /// <param name="book2"></param>
        /// <returns></returns>
        public static bool operator >(Book book1, Book book2) =>
            book1.Name.CompareTo(book2.Name) == 1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book1"></param>
        /// <param name="book2"></param>
        /// <returns></returns>
        public static bool operator <(Book book1, Book book2) =>
            book1.Name.CompareTo(book2.Name) == -1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book1"></param>
        /// <param name="book2"></param>
        /// <returns></returns>
        public static bool operator >=(Book book1, Book book2) =>
            book1.Name.CompareTo(book2.Name) >= 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book1"></param>
        /// <param name="book2"></param>
        /// <returns></returns>
        public static bool operator <=(Book book1, Book book2) =>
            book1.Name.CompareTo(book2.Name) <= 0;

        #endregion

        #region Private Methods

        /// <summary>
        /// Get equals of similar book
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        private bool IsEquals(Book other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(other, this))
                return true;

            if (string.Equals(Author, other.Author) &&
                string.Equals(Name, other.Name) &&
                string.Equals(Genre, other.Genre) &&
                Year != other.Year &&
                Pages != other.Pages)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get compare the book's names
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        private int IsCompareTo(Book other) =>
            Name.CompareTo(other.Name);

        #endregion
    }
}
