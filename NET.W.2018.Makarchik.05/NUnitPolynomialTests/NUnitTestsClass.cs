using System;
using NUnit.Framework;

namespace Polynomial
{
    [TestFixture]
    public class NUnitTestsClass
    {
        [TestCase(new double[] { 0, 0, 0 }, ExpectedResult = 3)]
        public int CoefficientCountTest(double[] array)
        {
            Polynomial p = new Polynomial(array);
            return p.Coefficients.Length;
        }

        [TestCase(new double[] { 1, 4, 7 }, 0, ExpectedResult = 1)]
        [TestCase(new double[] { 1, 4, 7 }, 1, ExpectedResult = 4)]
        [TestCase(new double[] { 1, 4, 7 }, 5, ExpectedResult = 0)]
        public double IndexatorTest(double[] array, int factor)
        {
            Polynomial p = new Polynomial(array);
            return p[factor];
        }

        [TestCase(new double[] { 1, 4, 7 , 1.1}, new double[] { 0, 0.7, 0, 8, 10.3, 3.7 })]
        public void OverloadedPlusOperatorTest(double[] array1, double[] array2)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Polynomial p = p1 + p2;

            Polynomial expectedResult = new Polynomial(new double[] { 1, 4.7, 7, 9.1, 10.3, 3.7 });
            bool expected = true;

            for (int i = 0; i < expectedResult.Coefficients.Length; i++)
                if (Math.Abs(expectedResult[i] - p[i]) > 0.001)
                    expected = false;

            Assert.IsTrue(expected);
        }

        [TestCase(new double[] { 1, 4, 7, 1.1 }, new double[] { 0, 0.7, 0, 8, 10.3, 3.7 })]
        public void OverloadedMinusOperatorTest(double[] array1, double[] array2)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Polynomial p = p1 - p2;

            Polynomial expectedResult = new Polynomial(new double[] { 1, 3.3, 7, -6.9, -10.3, -3.7 });
            bool expected = true;

            for (int i = 0; i < expectedResult.Coefficients.Length; i++)
                if (Math.Abs(expectedResult[i] - p[i]) > 0.001)
                    expected = false;

            Assert.IsTrue(expected);
        }

        [TestCase(new double[] { 1, 4, 7, 1.1 }, 2)]
        public void OverloadedMultiplyOperatorTest(double[] array1, int m)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p = p1 * m;

            Polynomial expectedResult = new Polynomial(new double[] { 2, 8, 14, 2.2});
            bool expected = true;

            for (int i = 0; i < expectedResult.Coefficients.Length; i++)
                if (Math.Abs(expectedResult[i] - p[i]) > 0.001)
                    expected = false;

            Assert.IsTrue(expected);
        }

        [TestCase(new double[] { 1, 4, 7, 1.1 })]
        public void PolynomialCompareTest(double[] array)
        {
            Polynomial p = new Polynomial(new double[]{ 1, 4, 7, 1.1 });

            Assert.IsTrue(new Polynomial(array) == p);
        }

        [TestCase(new double[] { 0, 1, 2 }, ExpectedResult = "1*x^1 + 2*x^2")]
        [TestCase(new double[] { 1, 2, 0 }, ExpectedResult = "1 + 2*x^1")]
        [TestCase(new double[] { 1, 0, 2 }, ExpectedResult = "1 + 2*x^2")]
        public string PolynomialToStringTest(double[] array)
        {
            Polynomial p = new Polynomial(array);
            return p.ToString();
        }

        [TestCase(new double[] { 0, 1, 2 })]
        public void PolynomianEqualsTest(double[] array)
        {
            Polynomial p = new Polynomial(new double[] { 0, 1, 2 });

            Assert.AreEqual(new Polynomial(array), p);
        }
    }
}