using Lab2.Accounts;

namespace Lab2.Games
{
    public class StandartGame: Game
    {
        public StandartGame(GameAccount gamer, GameAccount opponent, int rating, bool isWin) 
            : base(gamer, opponent, rating, isWin)
        {
            Rating = rating;
            RatingForOpponent = rating;
        }
    }
}