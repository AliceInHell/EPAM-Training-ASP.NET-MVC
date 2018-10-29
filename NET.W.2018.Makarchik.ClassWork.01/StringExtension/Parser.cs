using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension
{
    public static class Parser
    {
        /// <summary>
        /// store decimal value with keys
        /// </summary>
        private static Dictionary<char, int> digitDictionary;

        static Parser()
        {
            digitDictionary = new Dictionary<char, int>();
            digitDictionary['0'] = 0;
            digitDictionary['1'] = 1;
            digitDictionary['2'] = 2;
            digitDictionary['3'] = 3;
            digitDictionary['4'] = 4;
            digitDictionary['5'] = 5;
            digitDictionary['6'] = 6;
            digitDictionary['7'] = 7;
            digitDictionary['8'] = 8;
            digitDictionary['9'] = 9;
            digitDictionary['A'] = 10;
            digitDictionary['B'] = 11;
            digitDictionary['C'] = 12;
            digitDictionary['D'] = 13;
            digitDictionary['E'] = 14;
            digitDictionary['F'] = 15;
        }

        /// <summary>
        /// convert string to decimal
        /// </summary>
        /// <param name="source">string </param>
        /// <param name="@base">string base</param>
        /// <returns>decimal representation</returns>
        public static int ToDecimal(this string source, int @base)
        {
            //check parameters
            if (@base < 2 || @base > 16)
                throw new ArgumentOutOfRangeException();

            if (source == null || source.Equals(""))
                throw new ArgumentNullException();

            for (int i = 0; i < source.Length; i++)
            {
                if (digitDictionary.ContainsKey(char.ToUpper(source[i])))
                {
                    if (digitDictionary[char.ToUpper(source[i])] > @base)
                    {
                        throw new ArgumentException();
                    }
                }
                else
                    throw new ArgumentException();
            }
                
            int result = 0;

            //logic
            try
            {
                checked
                {
                    for (int i = source.Length - 1; i >= 0; i--)
                    {
                        int digit = digitDictionary[Char.ToUpper(source[i])];
                        result += (int)(Math.Pow(@base, source.Length - i - 1) * digit);
                    }
                }
            }
            catch(Exception e)
            {
                if (e.GetType().Equals( (new OverflowException()).GetType() ))
                    throw new OverflowException();
            }

            return result;
        }
    }
}
