using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixGenerator
{
    /// <summary>
    /// Matrix
    /// </summary>
    public class Matrix<T>
    {
        /// <summary>
        /// Value container
        /// </summary> 
        private T[,] _grid;

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix{T}"/> class
        /// </summary>
        /// <param name="n"></param>
        public Matrix(int n)
        {
            Order = n;
            _grid = new T[n, n];
        }                      

        /// <summary>
        /// Delegate for matrix element changing
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Parameter</param>
        public delegate void MatrixElementChangeEventHandler(object sender, MatrixElementChangeEventArgs<T> e);

        /// <summary>
        /// Event for matrix element changing
        /// </summary>
        public event MatrixElementChangeEventHandler MatrixElementChangeEvent;

        /// <summary>
        /// Matrix order
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Get all values
        /// </summary>
        public T[,] Grid => _grid;

        /// <summary>
        /// Matrix indexer
        /// </summary>
        /// <param name="i">Row</param>
        /// <param name="j">Column</param>
        /// <returns>Value</returns>
        public T this[int i, int j]
        {
            get
            {
                return _grid[i, j];
            }

            set
            {
                MatrixElementChangeEventArgs<T> arg = new MatrixElementChangeEventArgs<T>(
                    _grid[i, j], 
                    value,
                    i, 
                    j);

                OnMatrixElementChange(this, arg);

                _grid[i, j] = value;
            }
        }

        #region Methods

        /*public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            int order = firstMatrix.Order;
            if (order != secondMatrix.Order)
            {
                throw new InvalidOperationException();
            }

            Matrix<T> resultMatrix = new Matrix<T>(order);
            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    resultMatrix[i, j] = firstMatrix[i, j] + secondMatrix[i, j]; //!!!!!!!!
                }
            }
        }*/

        /// <summary>
        /// Notify if some element changed
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Parameters</param>
        protected virtual void OnMatrixElementChange(object sender, MatrixElementChangeEventArgs<T> e)
        {
            if (MatrixElementChangeEvent != null)
            {
                MatrixElementChangeEvent.Invoke(sender, e);
            }
        }

        #endregion
    }
}
