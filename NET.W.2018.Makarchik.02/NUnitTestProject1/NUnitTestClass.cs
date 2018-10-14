using System;
using IntMerger;
using NUnit.Framework;

namespace NUnitIntMergerTest
{
    [TestFixture]
    public class NUnitTestClass
    {
        [Test]
        public void IntMergerTest1()
        {
            int actual = IntMerger.IntMerger.Merge(15, 15, 0, 0);
            int expected = 15;

            Assert.IsTrue(actual == expected);
        }

        [Test]
        public void IntMergerTest2()
        {
            int actual = IntMerger.IntMerger.Merge(8, 15, 0, 0);
            int expected = 9;

            Assert.IsTrue(actual == expected);
        }

        [Test]
        public void IntMergerTest3()
        {
            int actual = IntMerger.IntMerger.Merge(8, 15, 3, 8);
            int expected = 120;

            Assert.IsTrue(actual == expected);
        }
    }
}