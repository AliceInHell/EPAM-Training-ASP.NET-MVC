using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace GCD
{
    public static class GCDCalculator
    {
        /// <summary>
        /// array check
        /// </summary>
        /// <param name="array">input array</param>
        /// <returns>true if array is correct</returns>
        private static bool isValid(int[] array)
        {
            if (array.Length < 2)
                return false;

            for (int i = 0; i < array.Length; i++)
                if (array[i] < 0)
                    return false;

            return true;
        }


        /// <summary>
        /// EucldAlgorythm
        /// </summary>
        /// <param name="a">the first number</param>
        /// <param name="b">the secont number</param>
        /// <returns>gcd of two numbers</returns>
        private static int EuclidAlgorithm(int a, int b)
        {
            while (a != 0 && b != 0)
                if (a > b)
                    a %= b;
                else
                    b %= a;

            return a + b;
        }


        /// <summary>
        /// calulate GCD using Euclid algorithm
        /// </summary>
        /// <param name="time">spent time</param>
        /// <param name="args">numbers</param>
        /// <returns></returns>
        public static int CalculateWithEuclid(out long time, params int[] args)
        {
            return CalculateGCD(out time, (a, b) => EuclidAlgorithm(a, b), args);
        }


        /// <summary>
        /// calulate GCD using Stains algorithm
        /// </summary>
        /// <param name="time">spent time</param>
        /// <param name="args">numbers</param>
        /// <returns></returns>
        public static int CalculateWithStain(out long time, params int[] args)
        {
            return CalculateGCD(out time, (a, b) => StainAlgorithm(a, b), args);
        }


        /// <summary>
        /// StainAlgotythm 
        /// </summary>
        /// <param name="a">the first number</param>
        /// <param name="b">the secont number</param>
        /// <returns>gcd of two numbers</returns>
        private static int StainAlgorithm(int a, int b)
        {
            if (a == 0 || b == 0)
                return a + b;

            int shift;
            for (shift = 0; ((a | b) & 1) == 0; shift++)
            {
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
                a >>= 1;

            while(b != 0)
            {
                while ((b & 1) == 0)
                    b >>= 1;

                if (a < b)
                    b -= a;
                else
                {
                    int difference = a - b;
                    a = b;
                    b = difference;
                }

                b >>= 1;
            }

            return a << shift;
        }


        /// <summary>
        /// method which calculate gcd of more than 2 nubmers given algorithm
        /// </summary>
        /// <param name="time">var to return spent time</param>
        /// <param name="algorithm">calculating algorithm</param>
        /// <param name="args">input values</param>
        /// <returns>gcd of given nubmers</returns>
        /// <exception cref="ArgumentException">if at least one of given numbers 
        ///     is less then 0 </exception>
        private static int CalculateGCD(out long time, Func<int, int, int> algorithm, params int[] args)
        {
            if (!isValid(args))
                throw new ArgumentException();

            Stopwatch locStopwatch = new Stopwatch();
            locStopwatch.Start();

            int gcd = EuclidAlgorithm(args[0], args[1]);
            for (int i = 2; i < args.Length && gcd != 1; i++)
                gcd = algorithm(gcd, args[i]);

            locStopwatch.Stop();
            time = locStopwatch.ElapsedMilliseconds;

            return gcd;
        }
    }
}
