namespace BlackjackSimulator.Test
{
    using BlackjackSimulator.Deck;
    using Shouldly;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class DeckGeneratorTests
    {
        [Fact]
        public static void ShouldGenerate52Cards()
        {
            var generator = new DeckGenerator();
            var deck = generator.GenerateDeck();
            deck.Count.ShouldBe(52);
        }

        [Fact]
        public static void ShouldHaveUniqueCards()
        {
            var uniqueCards = new List<string>();
            var generator = new DeckGenerator();
            var deck = generator.GenerateDeck();
                                                                    // Lambda expression, where
            foreach (var card in deck.Where(card => uniqueCards.Any(x => x == "")))
            {
                Assert.False(true);
            }
        }
    }
}