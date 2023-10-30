
namespace LR1
{
    class Game
    {
        public string OpponentName { get; }
        public bool IsWin { get; }
        public int Rating { get; }

        public Game(string opponentName, bool isWin, int rating)
        {
            OpponentName = opponentName;
            IsWin = isWin;
            Rating = rating;
        }
    }
}