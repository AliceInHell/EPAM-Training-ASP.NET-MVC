using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NthRootSearcher
{
    public static class RootCalculator
    {
        /// <summary>
        /// this method finds root
        /// </summary>
        /// <param name="value">given value</param>
        /// <param name="pow">given power</param>
        /// <param name="eps">some precision</param>
        /// <returns>root</returns>
        public static double FindNthRoot(double value, double pow, double eps)
        {
            if (eps > 0)
            {
                double x0 = value / pow;
                double x1 = (1 / pow) * ((pow - 1) * x0 + value / Math.Pow(x0, pow - 1));

                while (Math.Abs(x1 - x0) > eps)
                {
                    x0 = x1;
                    x1 = (1 / pow) * ((pow - 1) * x0 + value / Math.Pow(x0, pow - 1));
                }


                return x1;
            }
            else
                throw new ArgumentOutOfRangeException();
        }
    }
}
