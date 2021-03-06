﻿using System;
using System.Collections.Generic;

namespace FilterDigit
{   
    /// <summary>
    /// static class provides select numbers with given digit
    /// </summary>
    public static class Filter
    {
        /// <summary>
        /// public method, select integer which contains some digit
        /// </summary>
        /// <param name="digit">given digit</param>
        /// <param name="numbers">given numbers</param>
        /// <returns>numbers which contain this digit</returns>
        public static List<int> FilterDigir(int digit, params int[] numbers)
        {
            List<int> resultList = new List<int>();

            foreach (int item in numbers)
            {
                if (Contains(item, digit))
                {
                    resultList.Add(item);
                }
            }

            return resultList;
        }

        /// <summary>
        /// check integer for containing some digit
        /// </summary>
        /// <param name="value">given number</param>
        /// <param name="digit">given digit</param>
        /// <returns>true if contains</returns>
        private static bool Contains(int value, int digit)
        {
            string stringValue = Convert.ToString(value, 10);

            for (int i = 0; i < stringValue.Length; i++)
            {
                if (stringValue[i] == Convert.ToChar(digit + 48))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
