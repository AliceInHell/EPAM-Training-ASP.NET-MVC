using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sorting
{
    public static class MergeSort
    {
        /// <summary>
        /// reccurent part
        /// </summary>
        /// <param name="array">corting array</param>
        /// <param name="left">left edge of the array</param>
        /// <param name="right">right edge of the array</param>
        private static void _RecPart(int[] array, int left, int right)
        {
            if (right == -1)
                return;
            if (left == right)
                return;

            if (right - left == 1)
                if (array[left] > array[right])
                {
                    int buffer = array[left];
                    array[left] = array[right];
                    array[right] = buffer;
                }

            int middle = (left + right) / 2;
            _RecPart(array, left, middle);
            _RecPart(array, middle + 1, right);

            int[] tempArray = new int[right - left + 1];
            int i = left, j = middle + 1, tempArrayIndex = 0;

            while (tempArrayIndex != tempArray.Length)
            {
                if (i > middle)
                    tempArray[tempArrayIndex++] = array[j++];
                else
                if (j > right)
                    tempArray[tempArrayIndex++] = array[i++];
                else
                if (array[i] < array[j])
                    tempArray[tempArrayIndex++] = array[i++];
                else
                    tempArray[tempArrayIndex++] = array[j++];
            }

            for (i = 0; i < tempArray.Length; i++)
                array[i + left] = tempArray[i];
        }

        /// <summary>
        /// public sorting method
        /// </summary>
        /// <param name="array">given array</param>
        /// <returns>sorted array</returns>
        public static int[] Sort(int[] array)
        {
            if (array.Length < 2)
                return array;

            _RecPart(array, 0, array.Length - 1);

            return array;
        }
    }
}
