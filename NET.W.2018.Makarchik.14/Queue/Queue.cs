using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue
{
    /// <summary>
    /// Provides simple Queue
    /// </summary>
    /// <typeparam name="T">Queue data type</typeparam>
    public class Queue<T> : IEnumerable<T>
    {
        #region Fields

        /// <summary>
        /// Length multiplier coefficient
        /// </summary>
        private const double _multiplierCoefficient = 1.5;

        /// <summary>
        /// Queue head
        /// </summary>
        private int _first;

        /// <summary>
        /// Queue tail
        /// </summary>
        private int _last;

        /// <summary>
        /// Queue element count
        /// </summary>
        private int _count;        

        /// <summary>
        /// Queue container
        /// </summary>
        private T[] _queue;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class
        /// </summary>
        /// <param name="initialLength">Initial length</param>
        public Queue(short initialLength)
        {
            _queue = new T[initialLength];
            _first = 0;
            _last = -1;
            _count = 0;
        }

        #region Properties

        /// <summary>
        /// Return queue element count
        /// </summary>
        public int Count => _count;        

        #endregion

        #region Methods

        #region Publick methods

        /// <summary>
        /// Add element to queue
        /// </summary>
        /// <param name="element">Added element</param>
        public void Push(T element)
        {
            if (_count == _queue.Length)
            {
                ExpandQueue();
            }

            _queue[++_last] = element;
            _count++;
        }

        /// <summary>
        /// Pop first element
        /// </summary>
        /// <returns>First queue element</returns>
        public T Pop()
        {
            if (!IsEmpty())
            {
                CompressQueue();
                _count--;
                return _queue[_first++];
            }
            else
            {
                throw new InvalidOperationException("Queue is empty");
            }
        }

        /// <summary>
        /// Get first element
        /// </summary>
        /// <returns>First queue element</returns>
        public T Peek()
        {
            if (!IsEmpty())
            {
                return _queue[_first];
            }
            else
            {
                throw new InvalidOperationException("Queue is empty");
            }
        }

        /// <summary>
        /// Checks if queue contains the element
        /// </summary>
        /// <param name="value">Checking value</param>
        /// <returns>True if contains</returns>
        public bool Contains(T value)
        {
            foreach (T item in this)
            {
                if (item.Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Get enumerator 
        /// </summary>
        /// <returns>This object will be like enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new CustomEnumerator(_queue, _first, _last);
        }

        /// <summary>
        /// NotImplemented IEnumerable method
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }        

        #endregion

        #region Private methods

        /// <summary>
        /// Check queue for empty
        /// </summary>
        /// <returns></returns>
        private bool IsEmpty()
        {
            return _count == 0;
        }

        /// <summary>
        /// Set new queue length
        /// </summary>
        private void ExpandQueue()
        {
            T[] tempQueue;

            if (_queue.Length == 0)
            {
                _queue = new T[1];
                return;
            }

            tempQueue = new T[(int)(_count * _multiplierCoefficient)];
            Array.Copy(_queue, _first, tempQueue, 0, _count);

            _queue = tempQueue;
            _last = _count - 1;
            _first = 0;            
        }

        /// <summary>
        /// Delete useless array elements
        /// </summary>
        private void CompressQueue()
        {
            if (_first != 0)
            {
                if ((_queue.Length / _first) <= _multiplierCoefficient)
                {
                    T[] tempQueue = new T[_queue.Length - _first];
                    Array.Copy(_queue, _first, tempQueue, 0, _count);

                    _queue = tempQueue;
                    _last = _count - 1;
                    _first = 0;
                }
            }
        }

        #endregion

        #endregion

        #region Iterator

        /// <summary>
        /// Custom iterator
        /// </summary>
        private class CustomEnumerator : IEnumerator<T>
        {
            /// <summary>
            /// Queue container
            /// </summary>
            private T[] _queue;

            /// <summary>
            /// Inner index
            /// </summary>
            private int _index;

            /// <summary>
            /// Queue head
            /// </summary>
            private int _first;

            /// <summary>
            /// Queue tail
            /// </summary>
            private int _last;

            /// <summary>
            /// Initializes a new instance of the <see cref="CustomEnumerator"/> class
            /// </summary>
            /// <param name="array">Queue</param>
            /// <param name="first">First element index</param>
            /// <param name="last">Last element index</param>
            public CustomEnumerator(T[] array, int first, int last)
            {
                _index = first - 1;
                _first = first;
                _last = last;
                _queue = array;
            }

            /// <summary>
            /// Get current element for iterator
            /// </summary>
            public T Current
            {
                get
                {
                    return _queue[_index];
                }
            }

            /// <summary>
            /// NotImplemented IEnumerator property
            /// </summary>
            object IEnumerator.Current
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            /// <summary>
            /// Dispose something
            /// </summary>
            public void Dispose()
            {
            }

            /// <summary>
            /// Decide can we get next element
            /// </summary>
            /// <returns></returns>
            public bool MoveNext()
            {
                if (_index == _last)
                {
                    Reset();
                    return false;
                }

                _index++;
                return true;
            }

            /// <summary>
            /// Reset enumerator
            /// </summary>
            public void Reset()
            {
                _index = _first - 1;
            }
        }

        #endregion
    }
}
