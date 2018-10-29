using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class TitleAndAuthorFormat : IToStringFormat
    {
        public string ToString(Book b)
        {
            return string.Format("{0} record: {1}, {2}", b.GetType().Name, b.Author, b.Title);
        }
    }
}
