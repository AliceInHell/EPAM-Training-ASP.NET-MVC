using System;

namespace FibonacciNumbers
{
    /// <summary>
    /// Class which generates Fibonacci numbers
    /// </summary>
    public static class FibonacciNumbersGenerator
    {
        /// <summary>
        /// Generate array of Fibonacci numbers
        /// </summary>
        /// <param name="numbersCount">Number count</param>
        /// <returns>Generated numbers</returns>
        public static int[] Generate(int numbersCount)
        {
            if (numbersCount < 2)
            {
                throw new ArgumentException();
            }

            int[] numbers = new int[numbersCount];

            numbers[0] = 0;
            numbers[1] = 1;
            for (int i = 2; i < numbers.Length; i++)
            {
                numbers[i] = numbers[i - 1] + numbers[i - 2];
            }

            return numbers;
        }
    }
}
