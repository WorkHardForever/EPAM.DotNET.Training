using System.Collections.Generic;

namespace Task1Tests.BinarySearchTreeTestAddons
{
    public class Book : IComparer<Book>
    {
        public string Name;
        public int Cost;

        public Book(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        public int Compare(Book x, Book y) =>
            x.Name.CompareTo(y.Name);
    }
}
