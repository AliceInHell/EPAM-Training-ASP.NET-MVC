using System;
using BiggerNubmerSearcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitBiggerNumberSearcherTest
{
    [TestClass]
    public class UnitTestClass
    {
        [TestMethod]
        public void BiggerNumberSearcherTest1()
        {
            long time;
            int actual = BiggerNubmerSearcher.BiggerNubmerSearcher.FindNextBiggerNumber(513, out time);
            int expected = 531;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void BiggerNumberSearcherTest2()
        {
            long time;
            int actual = BiggerNubmerSearcher.BiggerNubmerSearcher.FindNextBiggerNumber(2018, out time);
            int expected = 2081;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void BiggerNumberSearcherTest3()
        {
            long time;
            int actual = BiggerNubmerSearcher.BiggerNubmerSearcher.FindNextBiggerNumber(1234321, out time);
            int expected = 1241233;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void BiggerNumberSearcherTest4()
        {
            long time;
            int actual = BiggerNubmerSearcher.BiggerNubmerSearcher.FindNextBiggerNumber(1234126, out time);
            int expected = 1234162;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void BiggerNumberSearcherTest5()
        {
            long time;
            int actual = BiggerNubmerSearcher.BiggerNubmerSearcher.FindNextBiggerNumber(3456432, out time);
            int expected = 3462345;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void BiggerNumberSearcherTest6()
        {
            long time;
            int actual = BiggerNubmerSearcher.BiggerNubmerSearcher.FindNextBiggerNumber(20, out time);
            int expected = -1;

            Assert.IsTrue(actual == expected);
        }
    }
}
