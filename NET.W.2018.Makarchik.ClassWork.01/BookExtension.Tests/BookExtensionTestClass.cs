using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLibrary;

namespace BookExtension.Tests
{
    [TestClass]
    public class BookExtensionTestClass
    {
        [TestMethod]
        public void NewFormatMethodTest()
        {
            Book book = new Book("Title", "Author", 2018, "PublishingHous",
                2005, 200, 50);

            string expected = "Book record: Title, Author, 200";

            Assert.Equals(book.NewFormat(), expected);
        }
    }
}
