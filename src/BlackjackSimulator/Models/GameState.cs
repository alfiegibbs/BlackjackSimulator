namespace BlackjackSimulator.Models
{
    using System;
    using System.Collections.Generic;
    using BlackjackSimulator.Deck;
    using System.Linq;

    public class GameState
    {
        public int HandValue => CurrentHand.Cards.Sum( x => x.Value );

        public Shoe CurrentShoe { get; set; }
        public int Money { get; set; }
        public Hand CurrentHand { get; set; }
        public int Bet { get; set; }

        public GameState()
        {
            CurrentShoe = new ShoeGenerator().GenerateShoe( 4 );
            CurrentHand = new Hand();

            CurrentShoe.Shuffle();
        }

        public Card DealCard()
        {
            var originalShoe = CurrentShoe.Cards.ToList();
            var card = originalShoe[ 0 ];

            CurrentHand.Cards.Add( card );
            CurrentShoe.Cards.Remove( card );

            return card;
        }
    }
}
