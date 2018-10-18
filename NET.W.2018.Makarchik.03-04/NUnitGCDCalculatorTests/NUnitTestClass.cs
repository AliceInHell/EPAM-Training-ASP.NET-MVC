using System;
using NUnit.Framework;

namespace NUnitGCDCalculatorTests
{
    [TestFixture]
    public class NUnitTestClass
    {
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(0, 1, ExpectedResult = 1)]
        [TestCase(1, 15, 21, ExpectedResult = 1)]
        [TestCase(3, 6, 9, 21, ExpectedResult = 3)]
        [TestCase(2, 8, 16, 7, ExpectedResult = 1)]
        public int GCDEuclidCalculatorTest(params int[] args)
        {
            long time;
            return GCD.GCDCalculator.CalculateWithEuclid(out time, args);
        }

        [TestCase(-1, -2, 7, 9)]
        public void GCDEuclidCalculatorArgumentExceptionTest(params int[] args)
        {
            long time;
            Assert.Throws<ArgumentException>(() => GCD.GCDCalculator.CalculateWithEuclid(out time, args));
        }

        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(0, 1, ExpectedResult = 1)]
        [TestCase(1, 15, 21, ExpectedResult = 1)]
        [TestCase(3, 6, 9, 21, ExpectedResult = 3)]
        [TestCase(2, 8, 16, 7, ExpectedResult = 1)]
        public int GCDStainCalculatorTest(params int[] args)
        {
            long time;
            return GCD.GCDCalculator.CalculateWithStain(out time, args);
        }

        [TestCase(-1, -2, 7, 9)]
        public void GCDStainCalculatorArgumentExceptionTest(params int[] args)
        {
            long time;
            Assert.Throws<ArgumentException>(() => GCD.GCDCalculator.CalculateWithStain(out time, args));
        }
    }
}