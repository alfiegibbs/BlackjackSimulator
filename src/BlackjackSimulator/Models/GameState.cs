namespace BlackjackSimulator.Models
{
    using System;
    using System.Collections.Generic;
    using BlackjackSimulator.Deck;
    using System.Linq;

    public class GameState
    {
        public Shoe CurrentShoe { get; set; }
        public int Money { get; set; }
        public Hand PlayerHand { get; set; }
        public Hand DealerHand { get; set; }
        public int Bet { get; set; }

        public GameState()
        {
            CurrentShoe = new ShoeGenerator().GenerateShoe( 4 );
            PlayerHand = new Hand();
            DealerHand = new Hand();

            CurrentShoe.Shuffle();
        }

        public Card DealPlayerCard()
        {
            var originalShoe = CurrentShoe.Cards.ToList();
            var card = originalShoe[ 0 ];

            PlayerHand.Cards.Add( card );
            CurrentShoe.Cards.Remove( card );

            return card;
        }
        public Card DealDealerCard()
        {
            var originalShoe = CurrentShoe.Cards.ToList();
            var card = originalShoe[ 0 ];

            DealerHand.Cards.Add( card );
            CurrentShoe.Cards.Remove( card );

            return card;
        }
        public Card DealDealerCardUp()
        {
            var originalShoe = CurrentShoe.Cards.ToList();
            var card = originalShoe[ 0 ];

//            var invisibleCard = originalShoe[0].IsVisible = false;
//
//            DealerHand.Cards.Add( invisibleCard );
            CurrentShoe.Cards.Remove( card );


            return card;
        }
    }
}
