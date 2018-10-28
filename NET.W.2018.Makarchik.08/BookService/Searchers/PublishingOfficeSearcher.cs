using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookService.Searchers
{
    public class PublishingOfficeSearcher : ISearcher
    {
        public bool IsMatch(Book b, string tag)
        {
            return b.PublishingOffice.Equals(tag);
        }
    }
}
