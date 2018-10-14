using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilterDigit
{
    public static class Filter
    {
        private static bool Contains(int value, int digit)
        {
            string stringValue = Convert.ToString(value, 10);

            for (int i = 0; i < stringValue.Length; i++)
                if (stringValue[i] == Convert.ToChar(digit + 48))
                    return true;

            return false;
        }

        public static List<int> FilterDigir(int digit, params int[] numbers)
        {
            List<int> resultList = new List<int>();

            foreach(int item in numbers)
            {
                if (Contains(item, digit))
                    resultList.Add(item);
            }

            return resultList;
        }
    }
}
