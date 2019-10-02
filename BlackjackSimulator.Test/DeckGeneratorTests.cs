namespace BlackjackSimulator.Test
{
    using System.Collections.Generic;
    using System.Linq;
    using BlackjackSimulator.Models;
    using Shouldly;
    using Xunit;

    public class DeckGeneratorTests
    {
        [ Fact ]
        public void ShouldGenerate52Cards()
        {
            var deck = new DeckGenerator();
            var realDeck = deck.GenerateDeck();
            realDeck.Count.ShouldBe( 52 );
        }

        [ Fact ]
        public void ShouldHaveUniqueCards()
        {
            var deck = new DeckGenerator();

            var uniqueCards = new List<string>();
            var realDeck = deck.GenerateDeck();

            foreach ( var card in realDeck )
            {
                if ( uniqueCards.Any( x => x == card.ToString() ) )
                {
                    Assert.False( true, $"Duplicate card found: {card}" );
                }
                else
                {
                    uniqueCards.Add( card.ToString() );
                }
            }
        }
    }
}
