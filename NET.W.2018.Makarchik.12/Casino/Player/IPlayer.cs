using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Casino.Player
{
    /// <summary>
    /// Player interface
    /// </summary>
    public interface IPlayer
    {
        void RedBet(Roulette roulette);
        void BlackBet(Roulette roulette);
        void EvenBet(Roulette roulette);
        void OddBet(Roulette roulette);
        void CancelBet(Roulette roulette);
    }
}
