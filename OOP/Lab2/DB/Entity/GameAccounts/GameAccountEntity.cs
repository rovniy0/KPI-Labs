using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.DB.Entity
{
    public class GameAccountEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; } 
        public int CurrentRating { get; set; }
        public int GamesCount { get; set; } = 0; // Кількість ігор гравця
        public List<GameResultEntity> GameHistory { get; set; }
    }
}
