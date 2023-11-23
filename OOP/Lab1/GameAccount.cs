namespace Lab1
{
    public class GameAccount
    {
        private List<Game> gameHistory = new List<Game>();
        private string userName;
        private static int gamesCount;
        private int currentRating;

        public GameAccount(string player, int currentRating)
        {
            userName = player;
            if (currentRating <= 1)
            {
                throw new ArgumentOutOfRangeException("Rating cannot be less than 1");
            }
            this.currentRating = currentRating;
        }

        public void WinGame(GameAccount opponent, int rating)
        {
            if (rating > 0)
            {
                currentRating += rating;
                opponent.currentRating -= rating;
                if (opponent.currentRating <= 1)
                {
                    throw new ArgumentOutOfRangeException("The rating played must be positive");
                }
                gameHistory.Add(new Game(++gamesCount, opponent, "Win", rating, currentRating));
            }
            else
            {
                throw new ArgumentOutOfRangeException("The rating played must be positive");
            }
        }

        public void LoseGame(GameAccount opponent, int rating)
        {
            if (rating > 0)
            {
                currentRating -= rating;
                opponent.currentRating += rating;
                if (this.currentRating <= 1)
                {
                    throw new ArgumentOutOfRangeException("The rating played must be positive");
                }
                gameHistory.Add(new Game(++gamesCount, opponent, "Lose", rating, currentRating));
            }
            else
            {
                throw new ArgumentOutOfRangeException("The rating played must be positive");
            }
            
        }

        public void GetStats()
        {
            for (int i = 0; i < gameHistory.Count; i++)
            {
                Console.WriteLine("\n");
                Console.WriteLine(userName+"'s stats");
                Console.WriteLine("Game number " + gameHistory[i].GamesCount);
                Console.WriteLine("Game ID: " + gameHistory[i].IdGame);
                Console.WriteLine("Opponent: " + gameHistory[i].Opponent.userName);
                Console.WriteLine("Bet: " + gameHistory[i].Rating);
                Console.WriteLine("Result " + gameHistory[i].Result);
                Console.WriteLine(userName+"'s current rating after game: " + gameHistory[i].CurrentRating);
                Console.WriteLine(gameHistory[i].Opponent.userName + "'s current rating after game: " + gameHistory[i].Opponent.currentRating);
            }
        }
    }
}