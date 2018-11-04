using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookService
{
    public class TitleAndAuthorFormat : IToStringFormat
    {
        public string ToString(Book b)
        {
            return string.Format("{0} record: {1}, {2}", b.GetType().Name, b.Author, b.Title);
        }
    }
}
