namespace BlackjackSimulator.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DeckGenerator
    {
        public List<Card> GenerateDeck()
        {
            var cards = new List<Card>();

            foreach ( var suit in Enum.GetValues( typeof( Suit ) ).Cast<Suit>() )
            {
                cards.AddRange( Enum.GetValues( typeof( Rank ) )
                                    .Cast<Rank>()
                                    .Select( rank => new Card(rank, suit) ) );
            }

            return cards;
        }
    }
}
