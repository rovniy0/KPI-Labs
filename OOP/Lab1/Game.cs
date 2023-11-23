namespace Lab1
{
    public class Game
    {
        public int GamesCount;
        public GameAccount Opponent;
        public string Result;
        public int Rating; 
        public int CurrentRating; 
        private static int _gameIndexSeed = 67890;
        public int IdGame;
        

        public Game(int gamesCount, GameAccount opponent, string result, int userRating, int opponentRating)
        {
            Opponent = opponent;
            Result = result;
            GamesCount = gamesCount;
            Rating = userRating;
            CurrentRating = opponentRating;
            IdGame = _gameIndexSeed++;
        }
    }
}