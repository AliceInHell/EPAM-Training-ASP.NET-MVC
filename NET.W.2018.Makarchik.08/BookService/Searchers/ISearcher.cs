using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookService.Searchers
{
    public interface ISearcher
    {
        bool IsMatch(Book b, string tag);
    }
}
