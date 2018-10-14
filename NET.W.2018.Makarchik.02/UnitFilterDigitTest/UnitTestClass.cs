using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitFilterDigitTest
{
    [TestClass]
    public class UnitTestClass
    {
        [TestMethod]
        public void FilterDigitMethodTest()
        {
            List<int> actual = FilterDigit.Filter.FilterDigir(7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17);
            List<int> expected = new List<int>();
            expected.Add(7);
            expected.Add(70);
            expected.Add(17);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
