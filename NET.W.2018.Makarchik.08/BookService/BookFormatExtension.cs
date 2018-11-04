using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookService
{
    public static class BookFormatExtension
    {
        /// <summary>
        /// add something to book ToString method
        /// </summary>
        /// <param name="b">context</param>
        /// <returns>book to string</returns>
        public static string NewFormat(this Book b)
        {
            return b.ToString(new TitleAndAuthorFormat()) + ", " + b.PagesCount;
        }
    }
}
