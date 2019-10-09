namespace BlackjackSimulator.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class Hand
    {
        public List<Card> Cards { get; set; } = new List<Card>();
        public int Value => Cards.Sum( card => CardData.RankValue[ card.Rank ] );
        public bool IsAceWorth1 { get; set; }

        public void AddCard(Card card)
        {
            Cards.Add( card );
        }
    }
}
