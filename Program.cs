
using BlackjackCLI.Content.Game;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Blackjack CLI!");
        Session session = new Session("Player", 1000);

        bool quit = false;
        while (!quit)
        {
            session.StartHand();
            Console.WriteLine("Do you want to play again? (y/n)");
            string input = Console.ReadLine();
            if (input.ToLower() != "y")
            {
                quit = true;
                Console.WriteLine("Thanks for playing!");
            }
            else
            {
                Console.Clear();
            }
        }
    }
}
