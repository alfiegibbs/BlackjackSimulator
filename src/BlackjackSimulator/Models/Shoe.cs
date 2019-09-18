namespace BlackjackSimulator.Models
{
    using System.Collections.Generic;

    public class Shoe
    {
        public List<Card> Cards { get; } = new List<Card>();

        public void Populate(List<Card> deck)
        {
            Cards.AddRange(deck);
        }
    }
}