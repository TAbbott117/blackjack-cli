
namespace BlackjackCLI.Content.Models
{
    public struct Hand
    {
        List<Card> Cards;
        public int Value;

        public Hand()
        {
            Cards = new List<Card>();
            Value = 0;
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
            Value += card.GetValue();
        }

        public bool IsBusted()
        {
            return Value > 21;
        }

        public bool IsBlackjack()
        {
            return Cards.Count == 2 && Value == 21;
        }

        public bool CanSplit()
        {
            return Cards.Count == 2 && Cards[0].Face == Cards[1].Face;
        }

        // Todo: Probably clean this up
        public override string ToString() 
        {
            var str = string.Join(", ", Cards);
            str += $" (Value: {Value})";
            return str;
        }
    }
}
