namespace BlackjackSimulator.Test
{
    using System.Collections.Generic;
    using System.Linq;
    using BlackjackSimulator.Deck;
    using Shouldly;
    using Xunit;

    public class CardTests
    {
        [ Fact ]
        public static void ShouldGenerate52Cards()
        {
            var generator = new DeckGenerator();
            var deck = generator.GenerateDeck();
            deck.Count.ShouldBe( 52 );
        }
    }
}
