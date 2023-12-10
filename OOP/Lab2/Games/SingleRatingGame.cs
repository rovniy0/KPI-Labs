using Lab2.Accounts;

namespace Lab2.Games
{
    public class SingleRatingGame: Game
    {
        public SingleRatingGame(GameAccount gamer, GameAccount opponent, int rating, bool isWin) 
            : base(gamer, opponent, rating, isWin)
        {
            Rating = rating;
            RatingForOpponent = 0;
        }
    }
}