namespace Lab1
{
    public class Game
    {
        public string OpponentName { get; }
        public string EndGame { get; }
        public int CurrentRating { get; }
        public string ChangedRating { get; }
        public int Index { get; }

        public Game(int index, string opponentName, string endGame, string changedRating, int currentRating)
        {
            Index = index;
            OpponentName = opponentName;
            EndGame = endGame;
            ChangedRating = changedRating;
            CurrentRating = currentRating;
        }
    }
}