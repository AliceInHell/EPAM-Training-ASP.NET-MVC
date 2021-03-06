﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class TitleAuthorAndPriceFormat : IToStringFormat
    {
        public string ToString(Book b)
        {
            return string.Format("{0} record: {1}, {2}, {3}", b.GetType().Name, b.Author, b.Title, b.Price);
        }
    }
}
