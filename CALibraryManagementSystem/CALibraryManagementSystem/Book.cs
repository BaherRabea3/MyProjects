using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALibraryManagementSystem
{
    internal class Book
    {
        public string? Title { get; set; }
        public string? AuthorName { get; set; }
        public BookStatus Status { get; set; }
        
        public Book(string title, string authorName)
        {
            Title = title;
            AuthorName = authorName;
            Status = BookStatus.available;
        }
    
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Title.GetHashCode();
            hash = hash * 91 + AuthorName.GetHashCode();
            return hash;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            Book? other = obj as Book;

            if (other is null) return false;
            
            return this.Title.Equals(other.Title) && this.AuthorName.Equals(other.AuthorName);
        }
        public override string ToString()
        {
            return $"\n\t{Title}\t\t{AuthorName}\t\t{Status}";
                
        }
    }
}
