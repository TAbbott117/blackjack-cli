using BlackjackCLI.Content.Models;

namespace BlackjackCLI.Content.Game
{
    public class Game
    {
        public Hand DealerHand;
        public Hand PlayerHand;
        public Shoe Shoe;

        public Game()
        {
            DealerHand = new Hand();
            PlayerHand = new Hand();
            Shoe = new Shoe();
        }

        public Game(int numberOfDecks)
        {
            DealerHand = new Hand();
            PlayerHand = new Hand();
            Shoe = new Shoe(numberOfDecks);
        }

        public void StartGame()
        {
            Shoe.ShuffleShoe();
            DealInitialCards();

            // Display first cards
            Console.WriteLine("Welcome to Blackjack!");
            Console.WriteLine("----------------------");

            CheckInitialState();
            HandlePlayerTurn();

            if (PlayerHand.IsBusted())
            {
                Console.WriteLine("You busted! Dealer wins.");
                return;
            }

            HandleDealerTurn();
            FinalScoreCheck();
        }

        public void DealInitialCards()
        {
            // Alternate drawing cards for player and dealer
            PlayerHand.AddCard(Shoe.DrawCard());
            DealerHand.AddCard(Shoe.DrawCard());
            PlayerHand.AddCard(Shoe.DrawCard());
            DealerHand.AddCard(Shoe.DrawCard());
        }

        public void CheckInitialState()
        {
            Console.WriteLine("Dealer's hand: " + DealerHand.ToString());
            Console.WriteLine("Your hand: " + PlayerHand.ToString());

            if (PlayerHand.IsBlackjack() && DealerHand.IsBlackjack())
            {
                Console.WriteLine("Push!");
                return;
            }
            else if (PlayerHand.IsBlackjack())
            {
                Console.WriteLine("Blackjack! You win!");
                return;
            }
            else if (DealerHand.IsBlackjack())
            {
                Console.WriteLine("Dealer has blackjack! Dealer wins.");
                return;
            }
        }

        public void HandlePlayerTurn()
        {
            while (!PlayerHand.IsBusted() && !PlayerHand.IsBlackjack())
            {
                Console.WriteLine("Do you want to hit (h) or stand (s)?");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "h")
                {
                    PlayerHand.AddCard(Shoe.DrawCard());
                    Console.WriteLine("Your hand: " + PlayerHand.ToString());
                }
                else if (choice.ToLower() == "s")
                {
                    break;
            }
                }
        }
        public void HandleDealerTurn()
        {
            while (DealerHand.Value < 17)
            {
                DealerHand.AddCard(Shoe.DrawCard());
                Console.WriteLine("Dealer's hand: " + DealerHand.ToString());
            }
        }

        public void FinalScoreCheck()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Final hands:");
            Console.WriteLine("Dealer's hand: " + DealerHand.ToString());
            Console.WriteLine("Your hand: " + PlayerHand.ToString());

            if (DealerHand.IsBusted())
            {
                Console.WriteLine("Dealer busted! You win.");
            }
            else if (PlayerHand.Value > DealerHand.Value)
            {
                Console.WriteLine("You win!");
            }
            else if (PlayerHand.Value < DealerHand.Value)
            {
                Console.WriteLine("Dealer wins.");
            }
            else
            {
                Console.WriteLine("Push!");
            }
        }
    }
}
