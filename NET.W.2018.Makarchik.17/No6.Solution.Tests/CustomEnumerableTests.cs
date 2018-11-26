using System.Linq;
using No6.Solution;
using NUnit.Framework;

namespace No6.Solution.Tests
{
    [TestFixture]
    public class CustomEnumerableTests
    {
        [Test]
        public void Generator_ForSequence1()
        {
            int[] actual = SequenceGenerator.Generate<int>((int a, int b) => a + b, 10, 1, 1).ToArray();
            int[] expected = {1, 1, 2, 3, 5, 8, 13, 21, 34, 55};

            CollectionAssert.AreEqual(actual, expected);
        }

        [Test]
        public void Generator_ForSequence2()
        {
            int[] actual = SequenceGenerator.Generate<int>((int a, int b) => 6 * b - 8 * a, 10, 1, 2).ToArray();
            int[] expected = { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 };

            CollectionAssert.AreEqual(actual, expected);
        }

        [Test]
        public void Generator_ForSequence3()
        {
            double[] actual = SequenceGenerator.Generate<double>((double a, double b) => b + a / b, 10, 1, 2).ToArray();
            double[] expected = { 1, 2, 2.5, 3.3, 4.05757575757576, 4.87086926018965, 5.70389834408211, 6.55785277425587, 7.42763417076325, 8.31053343902137 };

            CollectionAssert.AreEqual(actual, expected);
        }
    }
}
