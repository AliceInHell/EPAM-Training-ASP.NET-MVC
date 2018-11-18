using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixGenerator;

namespace MatrixGeneratorUnitTest
{
    [TestClass]
    public class MatrixGeneratorUnitTestClass
    {
        private Generator<int> _intMatrixGenerator = new Generator<int>();

        [TestMethod]
        public void DiagonalMatrixValueTest()
        {
            int[] values = new int[5] { 1, 2, 3, 4, 5 };            

            int[,] expected = new int[5, 5]
            {
                {1, 0, 0, 0, 0 },
                {0, 2, 0, 0, 0 },
                {0, 0, 3, 0, 0 },
                {0, 0, 0, 4, 0 },
                {0, 0, 0, 0, 5 }
            };

            CollectionAssert.AreEqual(expected, _intMatrixGenerator.GenearteDiagonalMatrix(5, values).Grid);
        }

        [TestMethod]
        public void SymmeticalMatrixValueTest()
        {
            int[] values = new int[6] { 1, 2, 3, 4, 5, 6 };

            int[,] expected = new int[3, 3]
            {
                {1, 2, 3 },
                {2, 4, 5 },
                {3, 5, 6 }
            };

            CollectionAssert.AreEqual(expected, _intMatrixGenerator.GenerateSymmetricalMatrix(3, values).Grid);
        }
    }
}
