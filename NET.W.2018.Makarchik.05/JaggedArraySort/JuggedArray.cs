namespace JaggedArraySort
{
    using System;
    using System.Collections;

    /// <summary>
    /// class which can sort jugged array
    /// </summary>
    public class JuggedArray : IEnumerable, IEnumerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JuggedArray"/> class
        /// </summary>
        /// <param name="array">given array</param>
        public JuggedArray(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            _array = array;
        }

        /// <summary>
        /// inner index
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Implement Interface method for tests
        /// </summary>
        public object Current
        {
            get
            {
                return _array[Index];
            }
        }

        /// <summary>
        /// private storage
        /// </summary>
        private int[][] _array { get; set; }

        /// <summary>
        ///  Implement Interface method for tests
        /// </summary>
        /// <returns>IEnumerator by Interface</returns>
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        /// <summary>
        /// Implement Interface method for tests
        /// </summary>
        /// <returns>true if can get next</returns>
        public bool MoveNext()
        {
            if (Index == _array.Length - 1)
            {
                Reset();
                return false;
            }

            Index++;
            return true;
        }

        /// <summary>
        /// Implement Interface method for tests
        /// </summary>
        public void Reset()
        {
            Index = -1;
        }

        /// <summary>
        /// Descending Sort By Max Element 
        /// </summary>
        /// <returns>sorted array</returns>
        public int[][] DescendingSortByMaxElement()
        {
            return Sort((a, b) => GetMaxValue(a) < GetMaxValue(b));
        }

        /// <summary>
        /// Ascending Sort By Max Element
        /// </summary>
        /// <returns>sorted array</returns>
        public int[][] AscendingSortByMaxElement()
        {
            return Sort((a, b) => GetMaxValue(a) >= GetMaxValue(b));
        }

        /// <summary>
        /// Descending Sort By Min Element
        /// </summary>
        /// <returns>sorted array</returns>
        public int[][] DescendingSortByMinElement()
        {
            return Sort((a, b) => GetMinValue(a) < GetMinValue(b));
        }

        /// <summary>
        /// Ascending Sort By Min Element
        /// </summary>
        /// <returns>sorted array</returns>
        public int[][] AscendingSortByMinElement()
        {
            return Sort((a, b) => GetMinValue(a) >= GetMinValue(b));
        }

        /// <summary>
        /// Descending Sort By String Sum
        /// </summary>
        /// <returns>sorted array</returns>
        public int[][] DescendingSortByStringSum()
        {
            return Sort((a, b) => GetArraySum(a) < GetArraySum(b));
        }

        /// <summary>
        /// Ascending Sort By String Sum
        /// </summary>
        /// <returns>sorted array</returns>
        public int[][] AscendingSortByStringSum()
        {
            return Sort((a, b) => GetArraySum(a) >= GetArraySum(b));
        }

        /// <summary>
        /// method for getting min array value
        /// </summary>
        /// <param name="array">integer array</param>
        /// <returns>minimal value</returns>
        private int GetMinValue(int[] array)
        {
            int minValue = int.MaxValue;

            foreach (int i in array)
            {
                if (i < minValue)
                {
                    minValue = i;
                }
            }

            return minValue;
        }

        /// <summary>
        /// method for getting maximal value
        /// </summary>
        /// <param name="array">given array</param>
        /// <returns>maximal value</returns>
        private int GetMaxValue(int[] array)
        {
            int maxValue = int.MinValue;

            foreach (int i in array)
            {
                if (i > maxValue)
                {
                    maxValue = i;
                }
            }

            return maxValue;
        }

        /// <summary>
        /// integer swap method
        /// </summary>
        /// <param name="a">first integer</param>
        /// <param name="b">second integer</param>
        private void Swap(ref int[] a, ref int[] b)
        {
            int[] tmp = a;
            a = b;
            b = tmp;
        }

        /// <summary>
        /// method which calculate array sum
        /// </summary>
        /// <param name="array">given array</param>
        /// <returns>array sum</returns>
        private int GetArraySum(int[] array)
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        /// <summary>
        /// sort jugged array by stringSum
        /// </summary>
        /// <param name="comparisonCondition">comparison condition</param>
        /// <returns>sorted array</returns>
        private int[][] Sort(Func<int[], int[], bool> comparisonCondition)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                for (int j = 0; j < _array.Length - 1 - i; j++)
                {
                    if (comparisonCondition(_array[j], _array[j + 1]))
                    {
                        Swap(ref _array[j], ref _array[j + 1]);
                    }
                }
            }

            return _array;
        }
    }
}
