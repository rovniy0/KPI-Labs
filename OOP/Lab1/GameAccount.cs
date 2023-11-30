namespace Lab1
{
    public class GameAccount
    {
        private List<Game> gameHistory = new List<Game>();
        private string userName;
        public int gamesCount{get {return gameHistory.Count;}}
        private int currentRating = 1;
        public int CurrentRating {
            get
            {
                return currentRating;
            }
            set
            {
                if (value < 1)
                {
                    currentRating =1;
                }
                else
                {
                    currentRating = value;
                }
            }
        }

        public GameAccount(string player, int currentRating)
        {
            userName = player;
            this.CurrentRating = currentRating;
        }

        public void WinGame(GameAccount opponent, int rating)
        {
            if (rating > 0)
            {
                CurrentRating += rating;
                opponent.CurrentRating -= rating;
                gameHistory.Add(new Game(opponent, "Win", rating, CurrentRating));
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
                CurrentRating -= rating;
                opponent.CurrentRating += rating;
                gameHistory.Add(new Game(opponent, "Lose", rating, CurrentRating));
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
                Console.WriteLine("Game ID: " + gameHistory[i].IdGame);
                Console.WriteLine("Opponent: " + gameHistory[i].Opponent.userName);
                Console.WriteLine("Bet: " + gameHistory[i].Rating);
                Console.WriteLine("Result " + gameHistory[i].Result);
                Console.WriteLine(userName+"'s current rating after game: " + gameHistory[i].CurrentRating);
                Console.WriteLine(gameHistory[i].Opponent.userName + "'s current rating after game: " + gameHistory[i].Opponent.CurrentRating);
            }
        }
    }
}