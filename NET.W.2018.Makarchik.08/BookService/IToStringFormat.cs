using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookService
{
    public interface IToStringFormat
    {
        string ToString(Book b);
    }
}
