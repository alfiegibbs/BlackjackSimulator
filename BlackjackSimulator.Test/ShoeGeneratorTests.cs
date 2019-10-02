namespace BlackjackSimulator.Test
{
    using BlackjackSimulator.Models;
    using Shouldly;
    using Xunit;

    public class ShoeGeneratorTests
    {
        [ Theory ]
        [ InlineData( 4 ) ]
        [ InlineData( 5 ) ]
        [ InlineData( 100 ) ]
        public void ShouldGenerateShoe( int deckCount )
        {
            var shoeGenerator = new ShoeGenerator();

            var shoe = shoeGenerator.GenerateShoe( deckCount );
            shoe.Cards.Count.ShouldBe( 52 * deckCount );
        }
    }
}
