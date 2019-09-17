namespace BlackjackSimulator.Deck
{
    using System.Collections.Generic;
    using System.Linq;
    using BlackjackSimulator.Models;

    public class DeckGenerator
    {
        public List<Card> GenerateDeck()
        {
            var cards = new List<Card>();

            for (int i = 0; i < 52; i++)
            {
                cards.Add(new Card());
            }

            return cards;
        }
    }
}