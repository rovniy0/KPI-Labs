using LR1;

namespace Lab1;

public class Program
{
    public static void Main()
    {
        GameAccount player1 = new GameAccount("Biber");
        GameAccount player2 = new GameAccount("Dolik");

        // Імітація гри
        player1.WinGame(player2, 50);
        player1.LoseGame(player2, 30);
        player2.WinGame(player1, 40);
        player2.WinGame(player1, 60);

        player1.GetStats();
        player2.GetStats();
    }

}