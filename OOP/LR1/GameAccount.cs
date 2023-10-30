
namespace LR1
{
    public class GameAccount
    {
        private string UserName;
        private int CurrentRating;
        private int GamesCount;
        private List<Game> gameHistory;

         public GameAccount(string userName)
         {
            UserName = userName;
            gameHistory = new List<Game>();
            CurrentRating = 1000;
            GamesCount = 0;
         }
        
            
        

        public void WinGame(GameAccount opponentName, int rating )
        {
            if (rating<0)
            {
                throw new ArgumentException("Ставка рейтину не може бути від'ємною");
            }
            CurrentRating += rating;
            GamesCount++;
            gameHistory.Add(new Game(opponentName.UserName, true, rating));
        }

        public void LoseGame(GameAccount opponentName, int rating )
        {
            if (rating < 0)
            {
                throw new ArgumentException("Рейтинг не може бути від'ємним.");
            }

            if (CurrentRating - rating < 1)
            {
                CurrentRating = 1;
            }
            else
            {
                CurrentRating -= rating;
            }

            GamesCount++;
            gameHistory.Add(new Game(opponentName.UserName, false, rating));
        }

        public void GetStats()
        {
            Console.WriteLine($"Статистика для гравця {UserName}:");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Проти кого\tПеремога/Поразка\tРейтинг\tІндекс гри");
            Console.WriteLine("------------------------------------------------------------");

            for (int i = 0; i < gameHistory.Count; i++)
            {
                Console.WriteLine(
                    $"{gameHistory[i].OpponentName}\t\t" +
                    $"{(gameHistory[i].IsWin ? "Перемога" : "Поразка")}\t\t" +
                    $"{gameHistory[i].Rating}\t\t{i + 1}");
            }
        }

    }
}