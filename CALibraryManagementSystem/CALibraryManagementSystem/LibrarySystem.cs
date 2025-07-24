using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALibraryManagementSystem
{
    internal class LibrarySystem
    {
        private List<Book> books;
      

        public LibrarySystem()
        {
            books = new List<Book>();
        }
        public int BorrowedBooks { get; private set; }
        public void AddBooks(Book book)
        {
            books?.Add(book);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"The {book.Title} has been added successfully..");
        }
        public void RemoveBooks(Book book)
        {
            if (books?.Count != 0)
            {
                if (books.Remove(book))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{book.Title} removed successfully..");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"The {book.Title} book is not found");
                }

            }
            else
            {
                Console.WriteLine("There are no books to remove the library is empty"); 
            }
        }
        public void BorrowBooks(Book book)
        {
            var foundBook = books?.Find(b => b.Title == book.Title && b.AuthorName == book.AuthorName);
            if ( foundBook is null)
            {
                Console.WriteLine("Sorry the book is not exist");
            }    
            if(foundBook.Status != BookStatus.Borrowed)
            {
                foundBook.Status = BookStatus.Borrowed;
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"The {book.Title} has been borrowed successfully..");
            }
            else
            {
                Console.WriteLine("The book is already borrowed..");
            }
        }
        public void DisplayBooks()
        {
            Console.WriteLine($"\tTitle\t\tAuthorName\t\tStatus");
            Console.WriteLine("---------------------------------------------");
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
