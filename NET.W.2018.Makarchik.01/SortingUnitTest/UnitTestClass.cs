using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting;

namespace SortingUnitTest
{
    [TestClass]
    public class UnitTestClass
    {
        private bool IsSorted(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
                if (array[i] > array[i + 1])
                    return false;

            return true;
        }

        [TestMethod]
        public void MergeSortEmptyArrayTest()
        {
            int[] testArray = { };

            MergeSort.Sort(testArray);

            bool expected = IsSorted(testArray);

            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void MergeSortSortedArrayTest()
        {
            int[] testArray = {1, 4, 5, 7, 8, 9, 11, 11};

            MergeSort.Sort(testArray);

            bool expected = IsSorted(testArray);

            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void MergeSortReverceSortedArrayTest()
        {
            int[] testArray = { 14, 12, 8, 5, 4, 3, 1};

            MergeSort.Sort(testArray);

            bool expected = IsSorted(testArray);

            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void MergeSortUnsortedArrayTest()
        {
            int[] testArray = { -4, 2, 7, 4, 9, 11, 0, 2, 1};

            MergeSort.Sort(testArray);

            bool expected = IsSorted(testArray);

            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void QuickSortEmptyArrayTest()
        {
            int[] testArray = { };

            QuickSort.Sort(testArray);

            bool expected = IsSorted(testArray);

            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void QuickSortSortedArrayTest()
        {
            int[] testArray = { 1, 4, 5, 7, 8, 9, 11, 11 };

            QuickSort.Sort(testArray);

            bool expected = IsSorted(testArray);

            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void QuickSortReverceSortedArrayTest()
        {
            int[] testArray = { 14, 12, 8, 5, 4, 3, 1 };

            QuickSort.Sort(testArray);

            bool expected = IsSorted(testArray);

            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void QuickSortUnsortedArrayTest()
        {
            int[] testArray = { -4, 2, 7, 4, 9, 11, 0, 2, 1 };

            QuickSort.Sort(testArray);

            bool expected = IsSorted(testArray);

            Assert.IsTrue(expected);
        }
    }
}
