using Lab2.Accounts;

namespace Lab2
{
    public abstract class Game
    {
        public  GameAccount Gamer;
        public  GameAccount Opponent;
        public  int Rating;
        public  int RatingForOpponent;
        public  bool IsWin;
        private  static int _id = 67890;
        public  int Gameid;

        public Game(GameAccount gamer, GameAccount opponent, int rating, bool isWin)
        {
            Gamer = gamer;
            Opponent = opponent;
            IsWin = isWin;
            _id++;
            Gameid = _id;
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException("Rating cannot be less than zero");
            }
        }
    }
}