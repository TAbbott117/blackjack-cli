
namespace BlackjackCLI.Content.Models
{
    public enum CardSuit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public enum CardFace
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }

    public struct Card
    {
        public readonly CardFace Face;
        public readonly CardSuit Suit;

        public Card(CardFace face, CardSuit suit)
        {
            Face = face;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"{Face} of {Suit}";
        }

        public int GetValue()
        {
            if (Face == CardFace.Ace)
            {
                return 11; // Ace can be 1 or 11, but we'll use 11 for now
            }
            else if (Face >= CardFace.Ten)
            {
                return 10; // Face cards (Jack, Queen, King) are worth 10
            }
            else
            {
                return (int)Face; // Number cards are worth their face value
            }
        }

    }


}
