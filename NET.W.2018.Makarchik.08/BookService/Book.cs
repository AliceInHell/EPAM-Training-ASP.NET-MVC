using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookService
{
    public class Book
    {
        public Book(
            string isbn, 
            string title, 
            string author, 
            string publicsingOffice,
            short publishingYear, 
            int pagesCount, 
            int price)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            PublishingOffice = publicsingOffice;
            PublishingYear = publishingYear;
            PagesCount = pagesCount;
            Price = price;
        }

        #region Properties

        /// <summary>
        /// book isbn
        /// </summary>
        public string ISBN { get; }

        /// <summary>
        /// books title
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// book author
        /// </summary>
        public string Author { get; }

        /// <summary>
        /// book publishing office
        /// </summary>
        public string PublishingOffice { get; }

        /// <summary>
        /// book publishing year
        /// </summary>
        public short PublishingYear { get; }

        /// <summary>
        /// book pages
        /// </summary>
        public int PagesCount { get; }

        /// <summary>
        /// book price
        /// </summary>
        public int Price { get; set; }

        #endregion

        #region methods

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
            return string.Format(
                "{0} record: {1}, {2}, {3}, {4}, {5}, {6}", 
                GetType().Name,
                Title, 
                Author, 
                PublishingOffice, 
                PublishingYear,              
                PagesCount, 
                Price);
        }

        /// <summary>
        /// overridden Equals method
        /// </summary>
        /// <param name="obj">comparing object</param>
        /// <returns>true if equals</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            if (obj.GetType().Equals(GetType()))
            {
                Book tmp = (Book)obj;
                return tmp.Author.Equals(Author) && tmp.ISBN.Equals(ISBN) && tmp.PagesCount.Equals(PagesCount)
                    && tmp.Price.Equals(Price) && tmp.PublishingOffice.Equals(PublishingOffice)
                        && tmp.PublishingYear.Equals(PublishingYear) && tmp.Title.Equals(Title);
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
