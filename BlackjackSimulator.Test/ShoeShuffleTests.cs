namespace BlackjackSimulator.Test
{
    using System.Linq;
    using BlackjackSimulator.Deck;
    using Shouldly;
    using Xunit;

    public static class ShoeShuffleTests
    {
        // Shuffle cards in a shoe so two simultaneous cards are not in sequence
        [ Fact ]
        public static void ShouldShuffle()
        {
            var shoeGenerator = new ShoeGenerator();
            var shoe = shoeGenerator.GenerateShoe( 4 );
            var originalShoe = shoe.Cards.ToList();

            shoe.Shuffle();

            // count how many clashes, compare the index of shoe and originalShoe
            int clashes = 0;

            for ( int i = 0; i < shoe.Cards.Count; i++ )
            {
                var originalRank = originalShoe[ i ].Rank;
                var originalSuit = originalShoe[ i ].Suit;

                var shuffledRank = shoe.Cards[ i ].Rank;
                var shuffledSuit = shoe.Cards[ i ].Suit;


                //If original rank and suit is the same as the shuffled rank and suit, add to the clashes variable
                if ( originalRank == shuffledRank && originalSuit == shuffledSuit )
                {
                    clashes++;
                }
            }

            double clashPercent = ( clashes / (double) shoe.Cards.Count ) * 100;

            if ( clashPercent >= 10 )
            {
                Assert.False( true, "Over 10% Clash rate" );
            }
        }

        // Shuffle cards in a shoe so two simultaneous cards are not in sequence
        [ Theory ]
        [ InlineData( 4 ) ]
        [ InlineData( 5 ) ]
        public static void ShouldOnlyBeDeckCountOfOneCard( int deckCount )
        {
            var shoeGenerator = new ShoeGenerator();
            var shoe = shoeGenerator.GenerateShoe( deckCount );

            shoe.Shuffle();

            var groups = shoe.Cards.GroupBy( x => new { x.Rank, x.Suit } ).ToList();
            groups.Count.ShouldBe( 52 );

            var cardsPerGroup = groups.Select( x => x.Count() );
            cardsPerGroup.All( x => x == deckCount ).ShouldBeTrue();
        }
    }
}
