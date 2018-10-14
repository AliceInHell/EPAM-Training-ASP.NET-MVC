using System;
using NthRootSearcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitRootSearcherTest
{
    [TestClass]
    public class UnitTestClass
    {
        [TestMethod]
        public void RootSeacherTest1()
        {
            double actual = RootCalculator.FindNthRoot(1, 5, 0.0001);
            double expected = 1;

            Assert.IsTrue(Math.Abs(expected - actual) < 0.0001);
        }

        [TestMethod]
        public void RootSeacherTest2()
        {
            double actual = RootCalculator.FindNthRoot(8, 3, 0.0001);
            double expected = 2;

            Assert.IsTrue(Math.Abs(expected - actual) < 0.0001);
        }

        [TestMethod]
        public void RootSeacherTest3()
        {
            double actual = RootCalculator.FindNthRoot(0.0279936, 7, 0.0001);
            double expected = 0.6;

            Assert.IsTrue(Math.Abs(expected - actual) < 0.0001);
        }

        [TestMethod]
        public void RootSeacherTest4()
        {
            double actual = RootCalculator.FindNthRoot(-0.008, 3, 0.1);
            double expected = -0.2;

            Assert.IsTrue(Math.Abs(expected - actual) < 0.1);
        }

        [TestMethod]
        public void RootSeacherTest5()
        {
            double actual = RootCalculator.FindNthRoot(0.004241979, 9, 0.00000001);
            double expected = 0.545;

            Assert.IsTrue(Math.Abs(expected - actual) < 0.00000001);
        }

        [TestMethod]
        public void RootSeacherTest6()
        {
            double actual = RootCalculator.FindNthRoot(0.04100625, 4, 0.0001);
            double expected = 0.45;

            Assert.IsTrue(Math.Abs(expected - actual) < 0.0001);
        }

        [TestMethod]
        public void RootSeacherTest7()
        {
            try
            {
                double actual = RootCalculator.FindNthRoot(0.04100625, 4, -7);
                Assert.Fail("No Exception(");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentOutOfRangeException);
            }
        }
    }
}
