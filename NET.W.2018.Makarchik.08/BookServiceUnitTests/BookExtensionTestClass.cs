using System;
using BookService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookServiceUnitTests
{
    [TestClass]
    public class BookExtensionTestClass
    {
        [TestMethod]
        public void BookExtensionTest()
        {
            Book book = new Book("ISBN", "Title", "Author", "PublishingHous",
                2005, 200, 50);

            string expected = "Book record: Author, Title, 200";

            Assert.IsTrue(book.NewFormat() == expected);
        }

        [TestMethod]
        public void BookToStringMethodTest()
        {
            Book book = new Book("ISBN", "Title", "Author", "PublishingHous",
                2005, 200, 50);

            string expected = "Book record: Author, Title";

            Assert.IsTrue(book.ToString(new TitleAndAuthorFormat()) == expected);
        }
    }
}