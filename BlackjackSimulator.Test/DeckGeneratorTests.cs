namespace BlackjackSimulator.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using BlackjackSimulator.Deck;
    using Shouldly;

    public class DeckGeneratorTests
    {
        [ Fact ]
        public static void ShouldGenerate52Cards()
        {
            var generator = new DeckGenerator();
            var deck = generator.GenerateDeck();
            deck.Count.ShouldBe( 52 );
        }

        [ Fact ]
        public static void ShouldHaveUniqueCards()
        {
            var uniqueCards = new List<string>();
            var generator = new DeckGenerator();
            var deck = generator.GenerateDeck();

            foreach (var card in deck)
            {

                if ( uniqueCards.Any( x => x == "" ) )
                {
                    Assert.False(true);
                }
            }
        }
    }
}
