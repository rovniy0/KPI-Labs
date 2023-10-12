using LR1;

namespace Lab1;

public class Program
{
    public static void Main(string[] args)
    {
        var player1 = new GameAccount("Grisha");
        var player2 = new GameAccount("BimBam");


        player1.GetStats();
        player2.GetStats();
    }

}