namespace Lab1
{
    public class Game
    {
        public GameAccount Opponent;
        public string Result;
        public int Rating; 
        public int CurrentRating; 
        private static int _gameIndexSeed = 67890;
        public int IdGame;
        

        public Game(GameAccount opponent, string result, int userRating, int opponentRating)
        {
            Opponent = opponent;
            Result = result;
            Rating = userRating;
            CurrentRating = opponentRating;
            IdGame = _gameIndexSeed++;
        }
    }
}