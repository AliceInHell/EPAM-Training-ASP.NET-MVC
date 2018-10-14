using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntMerger
{
    public static class IntMerger
    {
        public static int Merge(int a, int b, int i, int j)
        {
            string result = Convert.ToString(a, 2).PadLeft(32, '0');
            string source = Convert.ToString(b, 2).PadLeft(32, '0');

            result = result.Remove(31 - j, j - i + 1);
            result = result.Insert(result.Length - i, source.Substring(31 - j - i));

            return Convert.ToInt32(result, 2);
        }
    }
}
