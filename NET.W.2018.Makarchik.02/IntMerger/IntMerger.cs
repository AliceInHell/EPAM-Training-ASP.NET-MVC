using System;

namespace IntMerger
{
    /// <summary>
    /// static class provides method for number merging
    /// </summary>
    public static class IntMerger
    {
        /// <summary>
        /// merge two integer
        /// </summary>
        /// <param name="a">first integer</param>
        /// <param name="b">second integer</param>
        /// <param name="i">merging left byte position</param>
        /// <param name="j">merging right byte position</param>
        /// <returns>new number</returns>
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
