namespace Lab1
{ 
    class GameAccount
    {
        private static int _index;
        private string UserName { get; }
        private int CurrentRating { set; get; }

        private int GamesCount { set; get; }
        private readonly List<Game> _stats = new List<Game>();

        public GameAccount(string name)
        {
            UserName = name;
            CurrentRating = 100;
            _index++;
            GamesCount = 0;
        }

        public void WinGame(string opponentName, int rating)
        {
            CurrentRating += rating;
            GamesCount++;
            var changedRating = new System.Text.StringBuilder();
            changedRating.Append($"+{rating.ToString()}");
            var result = new Game(_index, opponentName, "Win", changedRating.ToString(), CurrentRating);
            _stats.Add(result);
        }

        public void LoseGame(string opponentName, int rating)
        {
            if (rating >= CurrentRating)
            {
                CurrentRating = 1;
            }
            else
            {
                CurrentRating -= rating;
            }
            
            GamesCount++;
            var changedRating = new System.Text.StringBuilder();
            changedRating.Append($"-{rating.ToString()}");
            var result = new Game(_index, opponentName, "Lose", changedRating.ToString(), CurrentRating);
            _stats.Add(result);
        }

        public string GetStats()
        {
            var allStats = new System.Text.StringBuilder();
            allStats.AppendLine($"Stats for {UserName}:");
            allStats.AppendLine("Index\tOpponent\tEnd of game\tChanged rating\tCurrent rating\tTotal games");
            foreach (var item in _stats)
            {
                allStats.AppendLine(
                    $"{item.Index}\t{item.OpponentName}\t\t{item.EndGame}\t\t{item.ChangedRating}\t\t{item.CurrentRating}\t\t{GamesCount}");
            }
            return allStats.ToString();
        }
    }
}