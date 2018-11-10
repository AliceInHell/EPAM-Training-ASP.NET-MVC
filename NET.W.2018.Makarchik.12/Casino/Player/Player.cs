using System;
using System.IO;

namespace Casino.Player
{
    /// <summary>
    /// Casino player
    /// </summary>
    public class Player : IPlayer
    {
        /// <summary>
        /// Log file path
        /// </summary>
        private readonly string _logFilePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class
        /// </summary>
        /// <param name="logFilePath"></param>
        public Player(string logFilePath)
        {
            _logFilePath = logFilePath;
            File.Create(_logFilePath).Close();
        }

        #region Bets

        /// <summary>
        /// Bet on black
        /// </summary>
        /// <param name="roulette">Offered roulette</param>
        public void BlackBet(Roulette roulette)
        {
            roulette.NewRouletteRedSet -= Bet;
            roulette.NewRouletteBlackSet += Bet;
        }

        /// <summary>
        /// Bet on even
        /// </summary>
        /// <param name="roulette">Offered roulette</param>
        public void EvenBet(Roulette roulette)
        {
            roulette.NewRouletteOddSet -= Bet;
            roulette.NewRouletteEvenSet += Bet;
        }

        /// <summary>
        /// Bet on odd
        /// </summary>
        /// <param name="roulette">Offered roulette</param>
        public void OddBet(Roulette roulette)
        {
            roulette.NewRouletteOddSet += Bet;
            roulette.NewRouletteEvenSet -= Bet;
        }

        /// <summary>
        /// Bet on red
        /// </summary>
        /// <param name="roulette">Offered roulette</param>
        public void RedBet(Roulette roulette)
        {
            roulette.NewRouletteRedSet += Bet;
            roulette.NewRouletteBlackSet -= Bet;
        }

        #endregion

        /// <summary>
        /// Cancel bets
        /// </summary>
        /// <param name="roulette">Offered roulette</param>
        public void CancelBet(Roulette roulette)
        {
            roulette.NewRouletteRedSet -= Bet;
            roulette.NewRouletteBlackSet -= Bet;
            roulette.NewRouletteOddSet -= Bet;
            roulette.NewRouletteEvenSet -= Bet;
        }

        /// <summary>
        /// Player bet handler
        /// </summary>
        /// <param name="sender">Calling member</param>
        /// <param name="e">Transferred parameter</param>
        public void Bet(object sender, RouletteSetEventArgs e)
        {
            using (FileStream fs = new FileStream(_logFilePath, FileMode.Append))
            {
                using (StreamWriter sr = new StreamWriter(fs))
                {
                    sr.WriteLine(e.ToString());
                }
            }
        }
    }
}
