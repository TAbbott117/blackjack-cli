
namespace BlackjackCLI.Content.Game
{
    public class Session
    {
        public string PlayerName { get; set; }
        public int Chips { get; set; }

        public Session(string playerName, int chips)
        {
            PlayerName = playerName;
            Chips = chips;

            Console.WriteLine($"Welcome, {PlayerName}! You have {Chips} chips.\n");
            Console.WriteLine("You are playing Double Deck. Blackjack pays 3:2.\n");
        }

        public void StartHand()
        {
            Console.WriteLine("Start a hand by entering a bet amount:");

            int betAmount;
            if (int.TryParse(Console.ReadLine(), out betAmount))
            {
                Chips -= betAmount;
                Console.WriteLine($"You have bet {betAmount} chips. You have {Chips} chips remaining.");
                Game game = new Game(2, betAmount);
                var winnings = game.PlayGame();
                Chips += winnings;
                Console.WriteLine($"You have {Chips} chips remaining.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
