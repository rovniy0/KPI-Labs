namespace Lab1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Zhorik = new GameAccount("Zhorik", 10);
            var Senia = new GameAccount("Senia", 10);
            Zhorik.WinGame(Senia, 30);
            Zhorik.LoseGame(Senia, 40);
            Senia.WinGame(Zhorik, 20);
            Senia.LoseGame(Zhorik, 50);
            //Test
            // var Ralf = new GameAccount("Ralf", -10);
            // Zhorik.LoseGame(Senia, -100);
            // Senia.WinGame(Zhorik, -1);
            
            Zhorik.GetStats();
            Senia.GetStats();
        }
    }
}