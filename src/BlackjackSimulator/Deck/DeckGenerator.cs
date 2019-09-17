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

            // Add a card to the List of "cards" 52 times, to generate a full deck.
            for (int i = 0; i < 52; i++)
            {
                cards.Add(new Card());
            }

            return cards;
        }
    }
}