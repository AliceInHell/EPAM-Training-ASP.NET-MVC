using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookService.Comparators
{
    public class PublishignOfficeComparator : IComparer<Book>
    {
        public int Compare(Book a, Book b)
        {
            return a.PublishingOffice.CompareTo(b.PublishingOffice);
        }
    }
}
