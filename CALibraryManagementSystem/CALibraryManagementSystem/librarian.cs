using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALibraryManagementSystem
{
    internal class Librarian : User
    {
        public int EmpId { get; set; }
        private LibrarySystem library;

       public Librarian(int empid, string name,LibrarySystem library) : base(name)
        {
            EmpId = empid;
           this.library = library;
        }
        public void DisplayBooks() =>  library.DisplayBooks();
       
        public void AddBook(Book book) => library.AddBooks(book);
        
        public void RemoveBook(Book book) => library.RemoveBooks(book);
        
    }
}
