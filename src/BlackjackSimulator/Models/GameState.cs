namespace BlackjackSimulator.Models
{
    using System;
    using BlackjackSimulator.Deck;
    using System.Linq;

    public class GameState
    {
        public Shoe CurrentShoe { get; set; }
        public double Money { get; set; } = 1000;
        public Hand PlayerHand { get; set; }
        public Hand PlayerSplitHand { get; set; }
        public Hand DealerHand { get; set; }
        public Hand CPUHand { get; set; }
        public double Bet { get; set; } = 100;

        public GameState()
        {
            ResetGameState();
        }

        public void ResetGameState()
        {
            CurrentShoe = new ShoeGenerator().GenerateShoe( 4 );
            PlayerHand = new Hand();
            PlayerSplitHand = new Hand();
            CPUHand = new Hand();
            DealerHand = new Hand();

            CurrentShoe.Shuffle();
            CheckPlayerHasMoney();
        }

        public Card DealPlayerCard()
        {
            var originalShoe = CurrentShoe.Cards.ToList();
            var card = originalShoe[ 0 ];

            PlayerHand.Cards.Add( card );
            CurrentShoe.Cards.Remove( card );

            DetectSplitability();

            return card;
        }
        public Card DealCPUCard()
        {
            var originalShoe = CurrentShoe.Cards.ToList();
            var card = originalShoe[ 0 ];

            CPUHand.Cards.Add( card );
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

            var visibleCard = new Card
            {
                Rank = card.Rank,
                Suit = card.Suit,
                IsVisible = true
            };
            DealerHand.Cards.Add( visibleCard );

            CurrentShoe.Cards.Remove( card );


            return card;
        }

        public bool DetectBlackjack()
        {
            if ( PlayerHand.Cards.Count != 2 )
            {
                return false;
            }

            if (PlayerHand.HandValue == 21 && PlayerHand.Cards.All( card => card.Rank == Rank.Ace || card.Rank == Rank.King || card.Rank == Rank.Queen || card.Rank == Rank.King || card.Rank == Rank.Jack ))
            {
                var oC = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine( "Blackjack! You have earnt 2.5x your initial bet!" );
                Money += Bet * 2.5;
                Console.ForegroundColor = oC;

                return true;
            }

            return false;
        }

        public bool DetectSplitability()
        {
            var groups = PlayerHand.Cards.GroupBy( x => new { x.Rank, x.Suit } );
            var cardsPerGroup = groups.Select( x => x.Count() );
            Console.WriteLine("Splitability detected!");
            return cardsPerGroup.Any( x => x >= 2);

        }

        public void CheckPlayerHasMoney()
        {
            if ( Money <= 0 )
            {
                Console.WriteLine( "You have ran out of money! Restart the application to get more." );
                Console.ReadLine();
                Environment.Exit( 0 );
            }
        }
    }
}
