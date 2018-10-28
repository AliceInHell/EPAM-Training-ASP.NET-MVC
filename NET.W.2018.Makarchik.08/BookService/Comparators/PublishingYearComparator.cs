using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookService.Comparators
{
    public class PublishingYearComparator : IComparer<Book>
    {
        public int Compare(Book a, Book b)
        {
            return a.PublishingYear.CompareTo(b.PublishingYear);
        }
    }
}
