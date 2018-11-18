using System;

namespace MatrixGenerator
{
    /// <summary>
    /// Matrix element argument
    /// </summary>
    public class MatrixElementChangeEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixElementChangeEventArgs{T}"/> class
        /// </summary>
        /// <param name="oldValue">old value</param>
        /// <param name="newValue">new value</param>
        /// <param name="i">row</param>
        /// <param name="j">column</param>
        public MatrixElementChangeEventArgs(T oldValue, T newValue, int i, int j)
        {
            this.OldValue = oldValue;
            this.NewValue = newValue;
            this.Row = i;
            this.Column = j;
        }

        #region Properties

        /// <summary>
        /// New value
        /// </summary>
        public T NewValue { get; }

        /// <summary>
        /// Old value
        /// </summary>
        public T OldValue { get; }

        /// <summary>
        /// Row index
        /// </summary>
        public int Row { get; }

        /// <summary>
        /// Column index
        /// </summary>
        public int Column { get; }        

        #endregion

        /// <summary>
        /// String representation
        /// </summary>
        /// <returns>Argument to string</returns>
        public override string ToString()
        {
            return string.Format("[{0}, {1}]    {2} -> {3}", Row, Column, OldValue, NewValue);
        }
    }
}
