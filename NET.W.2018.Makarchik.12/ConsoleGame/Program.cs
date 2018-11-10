using Casino;
using Casino.Player;
using System;

namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Roulette newRoulette = new Roulette();
            int gamesCount = 10;

            Player firstPlayer = new Player("./firstPlayerLog.txt");
            firstPlayer.BlackBet(newRoulette);

            Player secondPlayer = new Player("./secondPlayerLog.txt");
            secondPlayer.OddBet(newRoulette);

            for(int i = 0; i < gamesCount; i++)
            {
                newRoulette.Spin();
            }

            newRoulette.Dispose();

            Console.WriteLine("Game is over");
            Console.ReadKey();
        }
    }
}
