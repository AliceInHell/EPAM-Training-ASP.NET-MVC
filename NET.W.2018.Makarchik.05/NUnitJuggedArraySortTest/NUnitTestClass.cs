using System;
using NUnit.Framework;
using JaggedArraySort;

namespace NUnitJuggedArraySortTest
{
    [TestFixture]
    public class NUnitTestClass
    {
        private int[][] intArray;

        [SetUp]
        public void SetUp()
        {
            intArray = new int[][]
            {
                new int[] {1, 6, 9 },
                new int[] { -1, -5, 2, 7, 9},
                new int[] { },
                new int[] {0, 11, 12},
                new int[] {-10, 6, 4, 50},
                new int[] {0}
            };
        }

        [Test]
        public void DescendingSortByMaxElementTest()
        {
            JuggedArray array = new JuggedArray(intArray);

            int[][] expected = new int[][]
            {
                new int[] {-10, 6, 4, 50},
                new int[] {0, 11, 12},
                new int[] {1, 6, 9 },
                new int[] { -1, -5, 2, 7, 9},
                new int[] {0},
                new int[] {}
            };

            CollectionAssert.AreEqual(expected, array.DescendingSortByMaxElement());
        }

        [Test]
        public void AscendingSortByMaxElementTest()
        {
            JuggedArray array = new JuggedArray(intArray);

            int[][] expected = new int[][]
            {
                new int[] {},
                new int[] {0},
                new int[] { -1, -5, 2, 7, 9},
                new int[] {1, 6, 9 },
                new int[] {0, 11, 12},
                new int[] {-10, 6, 4, 50}
            };

            CollectionAssert.AreEqual(expected, array.AscendingSortByMaxElement());
        }

        [Test]
        public void DescendingSortByMinElementTest()
        {
            JuggedArray array = new JuggedArray(intArray);

            int[][] expected = new int[][]
            {
                new int[] {},
                new int[] {1, 6, 9 },
                new int[] {0, 11, 12},
                new int[] {0},
                new int[] { -1, -5, 2, 7, 9},
                new int[] {-10, 6, 4, 50}
            };

            CollectionAssert.AreEqual(expected, array.DescendingSortByMinElement());
        }

        [Test]
        public void AscendingSortByMinElementTest()
        {
            JuggedArray array = new JuggedArray(intArray);

            int[][] expected = new int[][]
            {
                new int[] {-10, 6, 4, 50},
                new int[] { -1, -5, 2, 7, 9},
                new int[] {0},
                new int[] {0, 11, 12},
                new int[] {1, 6, 9 },
                new int[] {}
            };

            CollectionAssert.AreEqual(expected, array.AscendingSortByMinElement());
        }

        [Test]
        public void DescendingSortByStringSumTest()
        {
            JuggedArray array = new JuggedArray(intArray);

            int[][] expected = new int[][]
            {
                new int[] {-10, 6, 4, 50},
                new int[] {0, 11, 12},
                new int[] {1, 6, 9 },
                new int[] { -1, -5, 2, 7, 9},
                new int[] {},
                new int[] {0}
            };

            CollectionAssert.AreEqual(expected, array.DescendingSortByStringSum());
        }

        [Test]
        public void AscendingSortByStringSumTest()
        {
            JuggedArray array = new JuggedArray(intArray);

            int[][] expected = new int[][]
            {
                new int[] {0},
                new int[] {},
                new int[] { -1, -5, 2, 7, 9},
                new int[] {1, 6, 9 },
                new int[] {0, 11, 12},
                new int[] {-10, 6, 4, 50}
            };

            CollectionAssert.AreEqual(expected, array.AscendingSortByStringSum());
        }
    }
}