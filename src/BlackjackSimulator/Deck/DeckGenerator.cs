namespace BlackjackSimulator.Deck
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BlackjackSimulator.Models;

    public class DeckGenerator
    {
        public List<Card> GenerateDeck()
        {
            var cards = new List<Card>();

            var deck = Enum.GetValues( typeof( Rank ) ).Cast<Rank>();

            foreach ( var suit in Enum.GetValues( typeof( Suit ) ).Cast<Suit>() )
            {
                foreach ( var rank in Enum.GetValues( typeof( Rank ) ).Cast<Rank>() )
                {
                    cards.Add( new Card
                    {
                        Rank = rank,
                        Suit = suit
                    } );
                }
            }

            return cards;
        }
    }
}
