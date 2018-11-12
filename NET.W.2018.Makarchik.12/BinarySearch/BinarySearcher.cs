using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySearch
{
    /// <summary>
    /// Provides method for binary searching
    /// </summary>
    public class BinarySearcher<T>
    {
        /// <summary>
        /// Value container
        /// </summary>
        private readonly IEnumerable<T> _collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearcher{T}"/> class
        /// </summary>
        /// <param name="collection"></param>
        public BinarySearcher(IEnumerable<T> collection)
        {
            _collection = collection;
        }

        /// <summary>
        /// Binary searching
        /// </summary>
        /// <param name="value">Value for searching</param>
        /// <returns>index if contains</returns>
        public int BinarySearch(T value)
        {
            if (_collection == null)
            {
                throw new NullReferenceException();
            }

            if ((value as IComparable<T>) == null)
            {
                throw new ArgumentException();
            }

            return Search(value, 0, _collection.Count() - 1);
        }

        /// <summary>
        /// Recursive sercher part
        /// </summary>
        /// <param name="value">Searching value</param>
        /// <param name="left">Left border</param>
        /// <param name="right">Right border</param>
        /// <returns>Index if collection contains value</returns>
        private int Search(T value, int left, int right)
        {
            int middle = left + (right - left) / 2;

            if (((IComparable<T>)value).CompareTo(_collection.ToList<T>()[middle]) < 0 && left != middle)
            {
                return Search(value, left, middle);
            }
            else
            {
                if (((IComparable<T>)value).CompareTo(_collection.ToList<T>()[middle]) > 0 && left != middle)
                {
                    return Search(value, middle + 1, right);
                }
                else
                {
                    if (((IComparable<T>)value).CompareTo(_collection.ToList<T>()[middle]) == 0)
                    {
                        return middle;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }
    }
}
