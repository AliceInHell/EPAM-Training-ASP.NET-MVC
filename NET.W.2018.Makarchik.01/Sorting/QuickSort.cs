namespace Sorting
{
    /// <summary>
    /// static class provides mergeSort
    /// </summary>
    public static class QuickSort
    {
        /// <summary>
        /// public sorting method
        /// </summary>
        /// <param name="array">given array</param>
        /// <returns>sorted array</returns>
        public static int[] Sort(int[] array)
        {
            if (array.Length < 2)
            {
                return array;
            }

            _RecPart(array, 0, array.Length - 1);

            return array;
        }

        /// <summary>
        /// recurrent part
        /// </summary>
        /// <param name="array">sorting array</param>
        /// <param name="left">left edge of the array</param>
        /// <param name="right">right edge of the array</param>
        private static void _RecPart(int[] array, int left, int right)
        {
            int i, j, temp, border;
            border = array[right - ((right - left) / 2)];
            i = left;
            j = right;

            while (i < j)
            {
                while (array[i] < border)
                {
                    i++;
                }

                while (array[j] > border)
                {
                    j--;
                }

                if (i <= j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                _RecPart(array, left, j);
            }

            if (i < right)
            {
                _RecPart(array, i, right);
            }
        }
    }
}
