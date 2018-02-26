using System;
using Task2Logic;
using static System.Console;

namespace Task2Console
{
    public sealed class Program
    {
        public static void Main(string[] args)
        {
            Write("Write file name: (write: \'fortask.txt\')");
            var filePath = ReadLine();
            IBookListService bookListService = new BookListService(
                Environment.CurrentDirectory + '\\'.ToString() + filePath,
                new FileListStorageController<Book>(filePath, new BookFileStorageHelper()));
            var book = new Book("Jeffrey Richter", "CLR via C#", "Science", 2013, 670);
            bookListService.AddBook(book);
            bookListService.AddBook(new Book("Albahari J and B", "C# 5.0 in a Nutshell 5th Edition", "Science", 2013, 540));
            bookListService.AddBook(new Book("Alex Devis", "Asinkhronnoe programmirovanie v C# 5.0", "Science", 2015, 270));
            WriteLine(bookListService.FindByTag(b => b.Pages == 540));
            WriteLine(bookListService.FindByTag(b => b.Author == "Jeffrey Richter"));
            bookListService.SortBooksByTag((b1, b2) => string.Compare(b1.Author, b2.Author));
            bookListService.RemoveBook(book);

            foreach (var item in bookListService.ListOfBooks)
            {
                WriteLine(item.Name);
            }
            
            ReadKey();
        }
    }
}
