using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;

namespace BookExtension
{
    public static class BookFormatExtension
    {
        /// <summary>
        /// add smth to book ToString method
        /// </summary>
        /// <param name="b">context</param>
        /// <returns>book to string</returns>
        public static string NewFormat(this Book b)
        {
            return b.ToString(new TitleAndAuthorFormat()) + ", " + b.PagesCount;
        }
    }
}
