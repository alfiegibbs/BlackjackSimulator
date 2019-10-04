namespace BlackjackSimulator.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Shoe
    {
        public List<Card> Cards { get; } = new List<Card>();

        public Card DealCard()
        {
            var card = Cards[ 0 ];
            Cards.Remove( card );
            return card;
        }

        public void Populate( List<Card> deck )
        {
            Cards.AddRange( deck );
        }

        public void Shuffle()
        {
            var random = new Random();

            int n = Cards.Count;
            while ( n > 1 )
            {
                n--;
                int k = random.Next( n + 1 );
                var value = Cards[ k ];
                Cards[ k ] = Cards[ n ];
                Cards[ n ] = value;
            }
        }
    }
}
