using System;
using System.IO;

namespace Casino
{
    /// <summary>
    /// Simple casino 
    /// </summary>
    public class Roulette : IDisposable
    {
        #region Fields

        /// <summary>
        /// Roulette log file path
        /// </summary>
        private readonly string _logFilePath = "./RouletteLogFile.txt";

        /// <summary>
        /// Private random
        /// </summary>
        private Random _rand;

        /// <summary>
        /// Streamwriter for log
        /// </summary>
        private StreamWriter _streamWriter;

        /// <summary>
        /// Filestream for log
        /// </summary>
        private FileStream _fileStream;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Roulette"/> class
        /// </summary>
        public Roulette()
        {
            _rand = new Random();
            File.Create(_logFilePath).Close();
            _fileStream = new FileStream(_logFilePath, FileMode.Append);
            _streamWriter = new StreamWriter(_fileStream);
        }

        #region Delegates

        /// <summary>
        /// Delegate for red color roulette set
        /// </summary>
        /// <param name="sender">Calling member</param>
        /// <param name="e">Transferred parameters</param>
        public delegate void NewRouletteRedSetEventHandler(object sender, RouletteSetEventArgs e);

        /// <summary>
        /// Delegate for black color roulette set
        /// </summary>
        /// <param name="sender">Calling member</param>
        /// <param name="e">Transferred parameters</param>
        public delegate void NewRouletteBlackSetEventHandler(object sender, RouletteSetEventArgs e);

        /// <summary>
        /// Delegate for even number roulette set
        /// </summary>
        /// <param name="sender">Calling member</param>
        /// <param name="e">Transferred parameters</param>
        public delegate void NewRouletteEvenSetEventHandler(object sender, RouletteSetEventArgs e);

        /// <summary>
        /// Delegate for odd number roulette set
        /// </summary>
        /// <param name="sender">Calling member</param>
        /// <param name="e">Transferred parameters</param>
        public delegate void NewRouletteOddSetEventHandler(object sender, RouletteSetEventArgs e);

        #endregion

        #region Handlers

        /// <summary>
        /// Red set handler
        /// </summary>
        public event NewRouletteRedSetEventHandler NewRouletteRedSet;

        /// <summary>
        /// Black set handler
        /// </summary>
        public event NewRouletteBlackSetEventHandler NewRouletteBlackSet;

        /// <summary>
        /// Even set handler
        /// </summary>
        public event NewRouletteEvenSetEventHandler NewRouletteEvenSet;

        /// <summary>
        /// Odd set handler
        /// </summary>
        public event NewRouletteOddSetEventHandler NewRouletteOddSet;

        #endregion

        /// <summary>
        /// Spin roulette!
        /// </summary>
        public void Spin()
        {
            int value = _rand.Next(1, 36);
            Color color = (Color)_rand.Next(0, 2);
            DateTime dateTime = DateTime.Now;

            RouletteSetEventArgs args = new RouletteSetEventArgs(color, value, dateTime);

            if (value % 2 == 0)
            {
                OnNewRouletteEvenSet(this, args);
            }
            else
            {
                OnNewRouletteOddSet(this, args);
            }

            if (color == Color.Red)
            {
                OnNewRouletteRedSet(this, args);
            }
            else
            {
                OnNewRouletteBlackSet(this, args);
            }

            try
            {
                _streamWriter.WriteLine(args.ToString());
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// Dispose log file
        /// </summary>
        public void Dispose()
        {
            _streamWriter.Close();
            _fileStream.Close();
        }

        #region Notifications

        /// <summary>
        /// Notify if roulette set is red
        /// </summary>
        /// <param name="sender">Calling member</param>
        /// <param name="e">Transferred parameters</param>
        protected virtual void OnNewRouletteRedSet(object sender, RouletteSetEventArgs e)
        {
            if (NewRouletteRedSet != null)
            {
                NewRouletteRedSet.Invoke(sender, e);
            }
        }

        /// <summary>
        /// Notify if roulette set is black
        /// </summary>
        /// <param name="sender">Calling member</param>
        /// <param name="e">Transferred parameters</param>
        protected virtual void OnNewRouletteBlackSet(object sender, RouletteSetEventArgs e)
        {
            if (NewRouletteBlackSet != null)
            {
                NewRouletteBlackSet.Invoke(sender, e);
            }
        }

        /// <summary>
        /// Notify if roulette set is even
        /// </summary>
        /// <param name="sender">Calling member</param>
        /// <param name="e">Transferred parameters</param>
        protected virtual void OnNewRouletteEvenSet(object sender, RouletteSetEventArgs e)
        {
            if (NewRouletteEvenSet != null)
            {
                NewRouletteEvenSet.Invoke(sender, e);
            }
        }

        /// <summary>
        /// Notify if roulette set is odd
        /// </summary>
        /// <param name="sender">Calling member</param>
        /// <param name="e">Transferred parameters</param>
        protected virtual void OnNewRouletteOddSet(object sender, RouletteSetEventArgs e)
        {
            if (NewRouletteOddSet != null)
            {
                NewRouletteOddSet.Invoke(sender, e);
            }
        }

        #endregion
    }
}
