using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Casino
{
    /// <summary>
    /// Represent simple roulette value/color set
    /// </summary>
    public class RouletteSetEventArgs : EventArgs
    {
        #region Fields

        /// <summary>
        /// Contains random color red/black
        /// </summary>
        private readonly Color _color;

        /// <summary>
        /// Contains random value from 1 to 36
        /// </summary>
        private readonly int _value;

        /// <summary>
        /// Contains set creation time
        /// </summary>
        private readonly DateTime _dateTime;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="RouletteSetEventArgs"/> class
        /// </summary>
        /// <param name="color">Random color</param>
        /// <param name="value">Random value</param>
        /// <param name="dateTime">Creation time</param>
        public RouletteSetEventArgs(Color color, int value, DateTime dateTime) : base()
        {
            _color = color;
            _value = value;
            _dateTime = dateTime;
        }

        #region Properties

        /// <summary>
        /// Return color
        /// </summary>
        public Color Color
        {
            get { return _color; }
        }

        /// <summary>
        /// Return value
        /// </summary>
        public int Value
        {
            get { return _value; }
        }

        /// <summary>
        /// Return dateTime
        /// </summary>
        public DateTime DateTime
        {
            get { return _dateTime; }
        }

        #endregion

        /// <summary>
        /// Roulette set to string 
        /// </summary>
        /// <returns>Set to string</returns>
        public override string ToString()
        {
            return string.Format("{0}  {1}  {2}", Value, Color, DateTime);
        }
    }
}
