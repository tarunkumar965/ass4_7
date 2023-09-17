using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ass4_7
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
    }

    public class Bookshelf
    {
        private List<Book> books = new List<Book>();

        // Indexer to access books by title
        public Book this[string title]
        {
            get
            {
                Book book = books.FirstOrDefault(b => b.Title == title);
                if (book == null)
                {
                    throw new ArgumentException($"Book with title '{title}' not found.");
                }
                return book;
            }
            set
            {
                Book existingBook = books.FirstOrDefault(b => b.Title == title);
                if (existingBook != null)
                {
                    existingBook.Title = value.Title;
                    existingBook.Author = value.Author;
                }
                else
                {
                    books.Add(value);
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Bookshelf shelf = new Bookshelf();

            shelf["Book1"] = new Book { Title = "Book1", Author = "Author1" };
            shelf["Book2"] = new Book { Title = "Book2", Author = "Author2" };

            Book book1 = shelf["Book1"];
            Console.WriteLine($"Book Title: {book1.Title}, Author: {book1.Author}");

            Book book3 = shelf["Book3"]; 

            shelf["Book2"] = new Book { Title = "NewBook2", Author = "NewAuthor2" };
            Book updatedBook2 = shelf["NewBook2"];
            Console.WriteLine($"Updated Book Title: {updatedBook2.Title}, Author: {updatedBook2.Author}");
        }
    }
}
