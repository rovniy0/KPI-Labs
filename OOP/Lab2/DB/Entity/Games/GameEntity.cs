using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Accounts;

namespace Lab2.DB.Entity.Games
{
    public class GameEntity
    {
        public int Id { get; set; }
        public GameAccount Player1 { get; set; }
        public GameAccount Player2 { get; set; }
        public int PlayRating { get; set; }
    }
}
