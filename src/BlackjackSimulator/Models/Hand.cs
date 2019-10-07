namespace BlackjackSimulator.Models
{
    using System.Collections.Generic;

    public class Hand
    {
        public List<Card> Cards { get; set; } = new List<Card>();

        public void AddCard(Card card)
        {
            Cards.Add( card );
        }
    }
}
