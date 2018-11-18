using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixGenerator
{
    /// <summary>
    /// Matrix generator
    /// </summary>
    public class Generator<T>
    {
        /// <summary>
        /// Square matrix generation
        /// </summary>
        /// <param name="n">Rows and columns count</param>
        /// <returns>New square matrix</returns>
        public Matrix<T> GenerateSquareMatrix(int n)
        {
            if (n == 0)
            {
                throw new ArgumentException();
            }

            return new Matrix<T>(n);
        }

        /// <summary>
        /// Diagonal matrix generation
        /// </summary>
        /// <param name="n">Rows and columns count</param>
        /// <returns>New diagonal matrix</returns>
        public Matrix<T> GenearteDiagonalMatrix(int n, IEnumerable<T> elements)
        {
            if (elements == null || n == 0 || elements.Count() != n)
            {
                throw new ArgumentException();
            }

            Matrix<T> newMatrix = new Matrix<T>(n);
            List<T> values = elements.ToList();
            for (int i = 0; i < n; i++)
            {
                newMatrix[i, i] = values[i];
            }

            return newMatrix;
        }

        /// <summary>
        /// Symmetrical matrix generation
        /// </summary>
        /// <param name="n">Rows and columns count</param>
        /// <returns>New symmetrical matrix</returns>
        public Matrix<T> GenerateSymmetricalMatrix(int n, IEnumerable<T> elements)
        {
            if (elements == null || n == 0 || elements.Count() != Sum(n))
            {
                throw new ArgumentException();
            }

            Matrix<T> newMatrix = new Matrix<T>(n);
            List<T> values = elements.ToList();
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    newMatrix[i, j] = values[k];
                    if (i != j)
                    {
                        newMatrix[j, i] = values[k];
                    }

                    k++;
                }
            }

            return newMatrix;
        }

        /// <summary>
        /// Get factorial
        /// </summary>
        /// <param name="n">value</param>
        /// <returns>N-factorial</returns>
        private int Sum(int n)
        {
            int result = 1;
            for (int i = 2; i <= n; i++)
            {
                result += i;
            }

            return result;
        }
    }
}
