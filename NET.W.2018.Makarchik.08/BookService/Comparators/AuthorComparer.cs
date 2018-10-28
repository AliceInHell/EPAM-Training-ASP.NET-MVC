using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookService.Comparators
{
    public class AuthorComparer : IComparer<Book>
    {
        public int Compare(Book a, Book b)
        {
            return a.Author.CompareTo(b.Author);
        }
    }
}
