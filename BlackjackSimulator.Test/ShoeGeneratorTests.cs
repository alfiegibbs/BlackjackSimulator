namespace BlackjackSimulator.Test
{
    using BlackjackSimulator.Deck;
    using Shouldly;
    using Xunit;

    public class ShoeGeneratorTests
    {
        [ Theory ] // what if
        [ InlineData( 4 ) ]
        [ InlineData( 5 ) ]
        [ InlineData( 100 ) ]
        public static void ShouldGenerateShoe( int deckCount )
        {
            var shoeGenerator = new ShoeGenerator();
            var shoe = shoeGenerator.GenerateShoe( deckCount );
            shoe.Cards.Count.ShouldBe( 52 * deckCount );
        }
    }
}
