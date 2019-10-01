namespace BlackjackSimulator.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Hand
    {
        public List<Card> Cards { get; set; } = new List<Card>();
        public int HandValue => Cards.Sum( x => x.Rank == Rank.Ace && IsAceWorth1 ? 1 : x.Value );
        public bool IsAceWorth1 { get; set; }
        public bool IsBust => HandValue > 21;


        public void ReinitialiseHandFromSplit( Card card )
        {
            Cards = new List<Card>
            {
                new Card
                {
                    Rank = card.Rank,
                    Suit = card.Suit,
                    IsVisible = card.IsVisible
                }
            };
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach ( var card in Cards )
            {
                sb.Append( card );
                sb.Append( " " );
            }

            return sb.ToString();
        }
    }
}
