using System;
using BinarySearch;
using NUnit.Framework;

namespace BinarySearcherNUnitTests
{
    [TestFixture]
    public class BinarySearcherNUnitTestsClass
    {
        private int[] _intArray;
        private string[] _stringArray;

        private BinarySearcher<int> _intSearcher;
        private BinarySearcher<string> _stringSearcher;

        [SetUp]
        public void SetUp()
        {
            _intArray = new int[6] { 1, 4, 7, 9, 11, 13 };
            _stringArray = new string[7]
            {
                "aaa",
                "bbb",
                "ccc",
                "ddd",
                "eee",
                "fff",
                "ggg"
            };

            _intSearcher = new BinarySearcher<int>(_intArray);
            _stringSearcher = new BinarySearcher<string>(_stringArray);
        }

        [TestCase(1, ExpectedResult = 0)]
        [TestCase(4, ExpectedResult = 1)]
        [TestCase(7, ExpectedResult = 2)]
        [TestCase(9, ExpectedResult = 3)]
        [TestCase(11, ExpectedResult = 4)]
        [TestCase(13, ExpectedResult = 5)]
        [TestCase(5, ExpectedResult = -1)]
        public int IntSearchMethodTest(int value)
        {
            return _intSearcher.BinarySearch(value);
        }

        [TestCase("aaa", ExpectedResult = 0)]
        [TestCase("bbb", ExpectedResult = 1)]
        [TestCase("ccc", ExpectedResult = 2)]
        [TestCase("ddd", ExpectedResult = 3)]
        [TestCase("eee", ExpectedResult = 4)]
        [TestCase("fff", ExpectedResult = 5)]
        [TestCase("xxx", ExpectedResult = -1)]
        public int StringSearchMethodTest(string value)
        {
            return _stringSearcher.BinarySearch(value);
        }
    }
}