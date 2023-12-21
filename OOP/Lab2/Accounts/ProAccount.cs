
namespace Lab2.Accounts
{
    public class ProAccount: GameAccount
    {
        public  ProAccount(string userName, int rating)
        {
            UserName = userName;
            AccountStatus = "Pro";
            if (rating < 0)
            {
                string error = "Rating cannot be less than zero";
                throw new ArgumentOutOfRangeException(error);
            }

            CurrentRating = rating;
        }

        private protected override void WinGame(Game game)
        {
            CurrentRating += game.Rating*2;
            if (game.Opponent.CurrentRating - game.Rating < 1)
            {
                game.Opponent.CurrentRating = 1;
            }
            else
            {
                game.Opponent.CurrentRating -= game.RatingForOpponent;
            }
            
        }

        private protected override void LoseGame(Game game)
        {
            game.Opponent.CurrentRating += game.RatingForOpponent;
            
        }
    }
}