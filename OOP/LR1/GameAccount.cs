using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LR1
{
    public class GameAccount
    {
        private string UserName;
        private int CurrentRating;
        private int GamesCount;

        public GameAccount(string UserName)
        {
            this.UserName = UserName;
        }

        public void WinGame(GameAccount opponentName, uint rating )
        {

        }

        public void LoseGame(GameAccount opponentName, uint rating )
        {

        }

        public void GetStats()
        {
            Console.WriteLine($"Statistics of player: {UserName}");
            Console.WriteLine($"Current rating: {CurrentRating}");
            
        }

    }
}