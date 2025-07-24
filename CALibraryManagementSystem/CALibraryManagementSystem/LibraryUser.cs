using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALibraryManagementSystem
{
    internal class LibraryUser : User
    {
        private LibraryCard? Card { get; set; }
        private LibrarySystem? _librarySystem;
        private LibrarySystem library;
        public LibraryUser(LibraryCard? card, string name,LibrarySystem library) : base (name)
        {
            Card = card;
            this.library = library;
        }

        public void BorrowBook(Book book) => library.BorrowBooks(book);
        
    }
}
