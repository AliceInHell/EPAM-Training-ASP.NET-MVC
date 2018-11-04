using System;
using System.Text;

namespace DoubleToString
{
    /// <summary>
    /// this class provides double extension method
    /// </summary>
    public static class DoubleToStringConventor
    {
        /// <summary>
        /// maximal exponent length
        /// </summary>
        private const int MAXEXPONENTOFFSET = 1023;

        /// <summary>
        /// minimal exponent length
        /// </summary>
        private const int MINEXPONENTOFFSET = -1022;

        /// <summary>
        /// mantissa length
        /// </summary>
        private const int MANTISSALENGTH = 52;

        /// <summary>
        /// exponent length
        /// </summary>
        private const int EXPONENTLENGTH = 11;

        /// <summary>
        /// main calling method 
        /// </summary>
        /// <param name="value">given double</param>
        /// <returns>return binary resultString</returns>
        public static string ConvertDoubleToString(this double value)
        {
            // result sign
            string sign = GetSign(value);
            value = Math.Abs(value);

            int offset = GetOffset(ref value);

            // result intPart
            string binaryIntegerPart = ConvertDecimalToString(offset);

            // result fractionPart
            string binaryFractionPart = ConvertFractionToString(value - 1).Substring(0, MANTISSALENGTH);

            return $"{sign}{binaryIntegerPart}{binaryFractionPart}";
        }

        /// <summary>
        /// method to check input double
        /// </summary>
        /// <param name="value">given double</param>
        /// <returns>if value is correct, return true</returns>
        private static bool IsCorrect(double value)
        {
            return !double.IsNaN(value) && !double.IsInfinity(value);
        }

        /// <summary>
        /// method to get sign
        /// </summary>
        /// <param name="value">given double</param>
        /// <returns>binary sing representation</returns>
        private static string GetSign(double value)
        {
            return value < 0 || double.IsNegativeInfinity(1 / value) || double.IsNaN(value) ? 
                "1" : "0";
        }

        /// <summary>
        /// method to get offset
        /// </summary>
        /// <param name="value">given value</param>
        /// <returns>return offset </returns>
        private static int GetOffset(ref double value)
        {
            if (double.IsInfinity(value) || double.IsNaN(value))
            {
                return (int)Math.Pow(2, 11) - 1;
            }

            if (value == 0.0)
            {
                return 0;
            }

            int offset = 0;

            if (value < 1.0)
            {
                while (value < 1.0)
                {
                    value *= 2;
                    offset--;
                }
            }
            else
            {
                while (value > 2.0)
                {
                    value /= 2;
                    offset++;
                }
            }

            offset += MAXEXPONENTOFFSET;
            return offset < 0 ? 0 : offset;
        }

        /// <summary>
        /// convert decimal to binary string
        /// </summary>
        /// <param name="value">integer part</param>
        /// <returns>binary string</returns>
        private static string ConvertDecimalToString(long value)
        {
            StringBuilder result = new StringBuilder();
            if (value == 0)
            {
                result.Insert(0, "0", 11);
                return result.ToString();
            }
            else
            {
                for (int i = 0; value != 0; i++)
                {
                    result.Insert(0, value % 2);
                    value /= 2;
                }

                return result.ToString().TrimStart('0');
            }
        }

        /// <summary>
        /// convert fraction to binary string
        /// </summary>
        /// <param name="value">given fraction</param>
        /// <returns>binary string</returns>
        private static string ConvertFractionToString(double value)
        {
            if (value == 0)
            {
                value = Math.Pow(2, -MANTISSALENGTH);
            }

            if (double.IsInfinity(value))
            {
                value = 0;
            }

            if (double.IsNaN(value))
            {
                value = 0.01;
            }

            StringBuilder result = new StringBuilder();
            int integerOverflow = 0;
            for (int i = 0; i < MANTISSALENGTH + EXPONENTLENGTH; i++)
            {
                value *= 2;
                integerOverflow = (int)value % 2;
                value -= integerOverflow;
                result.Insert(result.Length, integerOverflow);
            }

            return result.ToString();
        }
    }
}
