using BlackjackCLI.Content.Models;

namespace BlackjackCLI.Content.Game
{
    public class Game
    {
        public Hand DealerHand;
        public Hand PlayerHand;
        public Shoe Shoe;
        public int Bet;
        public int Payout = 0;

        public Game(int bet)
        {
            DealerHand = new Hand();
            PlayerHand = new Hand();
            Shoe = new Shoe();
            Bet = bet;
        }

        public Game(int numberOfDecks, int bet)
        {
            DealerHand = new Hand();
            PlayerHand = new Hand();
            Shoe = new Shoe(numberOfDecks);
            Bet = bet;
        }

        public int PlayGame()
        {
            Shoe.ShuffleShoe();
            DealInitialCards();

            // Display first cards
            Console.WriteLine("Welcome to Blackjack!");
            Console.WriteLine("----------------------");

            var canPlay = CheckInitialStateCanPlay();
            if (!canPlay)
            {
                return Payout;
            }

            HandlePlayerTurn();

            if (PlayerHand.IsBusted())
            {
                Console.WriteLine("You busted! Dealer wins.");
                return Payout;
            }

            HandleDealerTurn();
            FinalScoreCheck();
            return Payout;
        }

        public void DealInitialCards()
        {
            // Alternate drawing cards for player and dealer
            PlayerHand.AddCard(Shoe.DrawCard());
            DealerHand.AddCard(Shoe.DrawCard());
            PlayerHand.AddCard(Shoe.DrawCard());
            DealerHand.AddCard(Shoe.DrawCard());
        }

        public bool CheckInitialStateCanPlay()
        {
            Console.WriteLine("Dealer's hand: " + DealerHand.ToString());
            Console.WriteLine("Your hand: " + PlayerHand.ToString());

            if (PlayerHand.IsBlackjack() && DealerHand.IsBlackjack())
            {
                Console.WriteLine("Push!");
                return false;
            }
            else if (PlayerHand.IsBlackjack())
            {
                Payout = (int)(Bet * 1.5) + Bet; // Todo: Set payout to be configurable and handle rounding
                Console.WriteLine($"Blackjack! You win {Payout} chips!");
                return false;
            }
            else if (DealerHand.IsBlackjack())
            {
                Console.WriteLine("Dealer has blackjack! Dealer wins.");
                return false;
            }
            return true;
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
                Payout = Bet * 2;
                Console.WriteLine($"Dealer busted! You win {Payout} chips!");
            }
            else if (PlayerHand.Value > DealerHand.Value)
            {
                Payout = Bet * 2;
                Console.WriteLine($"You win {Payout} chips!");
            }
            else if (PlayerHand.Value < DealerHand.Value)
            {
                Console.WriteLine("Dealer wins.");
            }
            else
            {
                Console.WriteLine("Push!");
            }
            Console.WriteLine("----------------------\n");
        }
    }
}
