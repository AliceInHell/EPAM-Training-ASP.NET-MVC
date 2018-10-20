using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaggedArraySort
{
    public class JuggedArray : IEnumerable, IEnumerator
    {
        private int[][] _array { set; get; }
        public int index;


        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="array">given array</param>
        public JuggedArray(int[][] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            _array = array;
        }


        //  Implement Interface method for tests
        public IEnumerator GetEnumerator()
        {
            return this;
        }


        //  Implement Interface method for tests
        public bool MoveNext()
        {
            if (index == _array.Length - 1)
            {
                Reset();
                return false;
            }

            index++;
            return true;
        }


        //  Implement Interface method for tests
        public void Reset()
        {
            index = -1;
        }


        //  Implement Interface method for tests
        public object Current
        {
            get
            {
                return _array[index];
            }
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
        /// <param name="array">int array</param>
        /// <returns>min value</returns>
        private int GetMinValue(int[] array)
        {
            int minValue = int.MaxValue;

            foreach (int i in array)
                if (i < minValue)
                    minValue = i;

            return minValue;
        }


        /// <summary>
        /// method fot getting max value
        /// </summary>
        /// <param name="array">array</param>
        /// <returns>max value</returns>
        private int GetMaxValue(int[] array)
        {
            int maxValue = int.MinValue;

            foreach (int i in array)
                if (i > maxValue)
                    maxValue = i;

            return maxValue;
        }


        /// <summary>
        /// int swap method
        /// </summary>
        /// <param name="a">first int</param>
        /// <param name="b">second int</param>
        private void Swap(ref int[] a, ref int[] b)
        {
            int[] tmp = a;
            a = b;
            b = tmp;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private int GetArraySum(int[] array)
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
                sum += array[i];

            return sum;
        }


        /// <summary>
        /// sort jugged array by stringSum
        /// </summary>
        /// <param name="comparisonCondition">condition(>/<)</param>
        /// <returns></returns>
        private int[][] Sort(Func<int[], int[], bool> comparisonCondition)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                for (int j = 0; j < _array.Length - 1 - i; j++)
                {
                    if(comparisonCondition(_array[j], _array[j + 1]))
                    {
                        Swap(ref _array[j], ref _array[j + 1]);
                    }
                }
            }

            return _array;
        }
    }
}
