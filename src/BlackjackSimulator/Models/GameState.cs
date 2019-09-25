namespace BlackjackSimulator.Models
{
    using BlackjackSimulator.Deck;
    using System.Linq;

    public class GameState
    {
        public Shoe CurrentShoe { get; set; }
        public int Money { get; set; } = 500;
        public Hand PlayerHand { get; set; }
        public Hand DealerHand { get; set; }
        public int Bet { get; set; } = 100;

        public GameState()
        {
            ResetGameState();
        }

        public void ResetGameState()
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

            var invisibleCard = new Card()
            {
                Rank = card.Rank,
                Suit = card.Suit,
                IsVisible = false
            };
            DealerHand.Cards.Add( invisibleCard );

            CurrentShoe.Cards.Remove( card );

            return card;
        }

        public Card DealDealerCardUp()
        {
            var originalShoe = CurrentShoe.Cards.ToList();
            var card = originalShoe[ 0 ];

            var visibleCard = new Card()
            {
                Rank = card.Rank,
                Suit = card.Suit,
                IsVisible = true
            };
            DealerHand.Cards.Add( visibleCard );

            CurrentShoe.Cards.Remove( card );


            return card;
        }
    }
}
