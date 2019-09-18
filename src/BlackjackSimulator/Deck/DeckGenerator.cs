namespace BlackjackSimulator.Deck
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BlackjackSimulator.Models;

    public class DeckGenerator
    {
        public static List<Card> GenerateDeck()
        {
            var cards = new List<Card>();

            var deck = Enum.GetValues(typeof(Rank)).Cast<Rank>();

            foreach (var suit in Enum.GetValues(typeof( Suit)).Cast<Suit>())
            {
                cards.AddRange( Enum.GetValues( typeof( Rank ) )
                                              .Cast<Rank>()
                                              .Select( rank => new Card { Rank = rank, Suit = suit } ) );
            }

            return cards;
        }
    }
}
