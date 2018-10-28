using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookService
{
    public class TitleComparator : IComparer<Book>
    {
        public int Compare(Book a, Book b)
        {
            return a.Title.CompareTo(b.Title);
        }
    }
}
