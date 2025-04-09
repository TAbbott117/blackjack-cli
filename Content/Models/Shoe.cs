
namespace BlackjackCLI.Content.Models
{
    public struct Shoe
    {
        public List<Card> Cards; // Todo: Look into making stack instead of list since we just pop 
        public int NumberOfDecks;

        // Default Constructor creates a shoe with 2 ordered decks
        public Shoe()
        {
            NumberOfDecks = 2;
            Cards = [];
            InitializeShoe();
        }

        // Allow for different shoe sizes
        public Shoe(int numberOfDecks)
        {
            NumberOfDecks = numberOfDecks;
            Cards = new List<Card>();
            InitializeShoe();
        }

        public void ShuffleShoe()
        {
            Random rand = new();
            Cards = Cards.OrderBy(c => rand.Next()).ToList();
        }

        public Card DrawCard()
        {
            if (Cards.Count != 0)
            {
                var card = Cards[0];
                Cards.RemoveAt(0);
                return card;
            }
            else
            {
                throw new InvalidOperationException("No cards left in the shoe.");
            }
        }

        public readonly int GetCardsLeft()
        {
            return Cards.Count;
        }

        private void InitializeShoe()
        {
            for (int i = 0; i < NumberOfDecks; i++)
            {
                for (int suit = 0; suit < 4; suit++)
                {
                    for (int face = 1; face <= 13; face++)
                    {
                        Cards.Add(new Card((CardFace)face, (CardSuit)suit));
                    }
                }
            }
        }
    }
}
