using System.ComponentModel;
using Lab2.Games;

namespace Lab2.Accounts
{
    public abstract class GameAccount
    {
        private  List<Game> _historyGames = new List<Game>();
        public string? UserName { get; set; }
        public int CurrentRating;
        public string? AccountStatus;
        
        
        public void Play(GameAccount opponent, int rating, string playFormat)
        {
            var rnd = new Random();
            var isWin = rnd.Next(2) == 1;
            var gameBuilder = new GameFactory();
            Game game ;
            Game opponentGame;
            switch (playFormat)
            {
                case "Standart":
                    game = gameBuilder.StartStandartGame(this, opponent, rating, isWin);
                    opponentGame = gameBuilder.StartStandartGame(opponent, this, rating, !isWin);
                    break;
                case "Traning":
                    game = gameBuilder.StartTraningGame(this, opponent, rating, isWin);
                    opponentGame = gameBuilder.StartTraningGame(opponent, this, rating, !isWin);
                    break;
                case "SingleRating":
                    game = gameBuilder.StartSingleRatingGame(this, opponent, rating, isWin);
                    opponentGame = gameBuilder.StartSingleRatingGame(opponent, this, rating, !isWin);
                    break;
                default:
                    throw new InvalidEnumArgumentException("Wrong playFormat");
            }
            
            if (isWin)
            {
                WinGame(game);
            }
            else
            {
                LoseGame(game);
            }

            _historyGames.Add(game);
            opponent._historyGames.Add(opponentGame);
        }

        private protected abstract void WinGame(Game game);
        private protected abstract void LoseGame(Game game);

        public void GetStats()
        {
            Console.WriteLine($"{"Opponent",-20}{"Status",-10}{"Rating",-10}{"Game ID",-10}");
            foreach (var game in _historyGames)
            {
                string status = game.IsWin ? "WIN" : "LOSE";

                Console.WriteLine($"{game.Opponent.UserName,-20}{status,-10}{game.Rating,-10}{game.Gameid,-10}");
            }
            Console.WriteLine("\n");
        }
        
        public void ShowInfo()
        {
            Console.WriteLine($"{"Player:",-20}{UserName}");
            Console.WriteLine($"{"Current rating:",-20}{CurrentRating}");
            Console.WriteLine($"{"Account status:",-20}{AccountStatus}");
            Console.WriteLine($"{"Number of games played:",-20}{_historyGames.Count}");
            Console.WriteLine("\n");
        }
    }
}