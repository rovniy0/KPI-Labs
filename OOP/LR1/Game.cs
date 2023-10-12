using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LR1
{
    public class Game
    {
        private static uint idCounter = 0;
        

        public GameAccount winner { get; }
        public GameAccount loser { get; }
        public uint rating { get; }
        public uint GameId { get; }

        public Game(GameAccount winner, GameAccount loser, uint rating)
    {
        this.winner = winner;
        this.loser = loser;
        this.rating = rating;
        
        GameId = idCounter++;
    }
    }
}