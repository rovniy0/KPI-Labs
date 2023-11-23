namespace Lab1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Zhorik = new GameAccount("Zhorik");
            var Senia = new GameAccount("Senia");

            Zhorik.WinGame("Senia", 20);
            Senia.WinGame("Zhorik", 20);

            Console.WriteLine(Zhorik.GetStats() + "\n" + Senia.GetStats());
        }
    }
}