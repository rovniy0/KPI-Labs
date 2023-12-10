using Lab2.Accounts;

namespace Lab2.Games
{
    public class GameFactory
    {
        public Game StartStandartGame(GameAccount gamer, GameAccount opponent, int rating, bool isWin)
        {
            return new StandartGame(gamer, opponent, rating, isWin);
        }

        public Game StartTraningGame(GameAccount gamer, GameAccount opponent, int rating, bool isWin)
        {
            return new TraningGame(gamer, opponent, rating, isWin);
        }

        public Game StartSingleRatingGame(GameAccount gamer, GameAccount opponent, int rating, bool isWin)
        {
            return new SingleRatingGame(gamer, opponent, rating, isWin);
        }
    }
}