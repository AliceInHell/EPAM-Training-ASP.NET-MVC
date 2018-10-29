using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public short Year { get; set; }
        public string PublishingHous { get; set; }
        public short Edition { get; set; }
        public int PagesCount { get; set; }
        public int Price { get; set; }

        public Book(string title, string author, short year, string publicsingHous,
            short edition, int pagesCount, int price)
        {
            Title = title;
            Author = author;
            Year = year;
            PublishingHous = publicsingHous;
            Edition = edition;
            PagesCount = pagesCount;
            Price = price;
        }

        /// <summary>
        /// convert book to string with formatter
        /// </summary>
        /// <param name="formatter">formatter</param>
        /// <returns>book to string</returns>
        public string ToString(IToStringFormat formatter)
        {
            return formatter.ToString(this);
        }

        /// <summary>
        /// override Object's method
        /// </summary>
        /// <returns>book to string</returns>
        public override string ToString()
        {
            return string.Format("{0} record: {1}, {2}, {3}, {4}, {5}, {6}, {7}", GetType().Name, 
                Title, Author, Year, PublishingHous, Edition, PagesCount, Price);
        }
    }
}
