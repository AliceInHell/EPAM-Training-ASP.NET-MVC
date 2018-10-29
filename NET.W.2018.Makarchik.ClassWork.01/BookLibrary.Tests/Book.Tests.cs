using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;

namespace BookLibrary.Tests
{
    public class Class1
    {
        public void ToStringMethodTest()
        {
            Book book = new Book("Title", "Author", 2018, "PublishingHous",
                 2005, 200, 50);

            string expected = "Book record: Title, Author";

            Assert.Equals(book.ToString(new TitleAndAuthorFormat()), expected);
        }
    }
}
