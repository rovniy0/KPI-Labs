using Lab2.Accounts;

namespace Lab2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var account1 = new PremiumAccount("Zhorik (Premium)");
            var account2 = new BaseAccount("Tolik (Base)");
            var account3 = new ProAccount("Anonim (Pro)", 32);
                
            account1.Play(account2, 200, "Standart");
            account2.Play(account3, 19, "Traning");
            account3.Play(account1, 5, "SingleRating");

            account1.GetStats();
            account2.GetStats();
            account3.GetStats();
                
            account1.ShowInfo();
            account2.ShowInfo();
            account3.ShowInfo();
            
        }
    }
}