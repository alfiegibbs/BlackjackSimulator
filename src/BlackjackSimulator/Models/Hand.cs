namespace BlackjackSimulator.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class Hand
    {
        private List<Card> Cards { get; set; } = new List<Card>();

        public void AddCard(Card card)
        {
            Cards.Add( card );
        }
    }
}
