using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace BiggerNubmerSearcher
{
    public static class BiggerNubmerSearcher
    {
        /// <summary>
        /// swap array items
        /// </summary>
        /// <param name="array">array</param>
        /// <param name="i">first element index</param>
        /// <param name="j">second element index</param>
        private static void Swap(char[] array, int i, int j)
        {
            char tmp;
            tmp = array[j];
            array[j] = array[i];
            array[i] = tmp;
        }

        /// <summary>
        /// bubble sort
        /// </summary>
        /// <param name="array">array</param>
        /// <param name="i">start index</param>
        private static void DecimalSwapAndSort(char[] array, int i)
        {
            Swap(array, i - 1, i);

            for(int j = i; j < array.Length - 1; j++)
                for(int k = j + 1; k < array.Length; k++)
                {
                    if (array[j] > array[k])
                        Swap(array, j, k);
                }
        }

        /// <summary>
        /// convert char array to int
        /// </summary>
        /// <param name="array">chars</param>
        /// <param name="i">start index</param>
        /// <returns></returns>
        private static int GetNewNumber(char[] array, int i)
        {
            char[] tempArray = new char[array.Length];
            Array.Copy(array, tempArray, array.Length);

            if (tempArray[i] > tempArray[i - 1])
            {
                DecimalSwapAndSort(tempArray, i);

                return int.Parse(Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(tempArray)));
                ;
            }
            else
                return -1;
        }

        /// <summary>
        /// public method, find next bigger number contains same digits
        /// </summary>
        /// <param name="number">current number</param>
        /// <param name="time">working time</param>
        /// <returns></returns>
        public static int FindNextBiggerNumber(int number, out long time)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            string stringNumber = Convert.ToString(number);
            char[] decimalArray = stringNumber.ToArray();

            int i = stringNumber.Length - 1;

            while(i >= 1)
            {
                int newNumber = GetNewNumber(decimalArray, i);
                if (newNumber > number)
                {
                    timer.Stop();
                    time = timer.ElapsedMilliseconds;

                    return newNumber;
                }
                else
                    i--;
            }

            timer.Stop();
            time = timer.ElapsedMilliseconds;

            return -1;
        }
    }
}
