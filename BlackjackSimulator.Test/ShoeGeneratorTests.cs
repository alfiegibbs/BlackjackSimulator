namespace BlackjackSimulator.Test
{
    using BlackjackSimulator.Deck;
    using Shouldly;
    using Xunit;

    public class ShoeGeneratorTests
    {
        [ Theory ] // what if
//      [ Fact ] is, run the code and tell me the output
        [ InlineData( 4 ) ]
        [ InlineData( 5 ) ]
        [ InlineData( 100 ) ]
        public static void ShouldGenerateShoe( int deckCount )
        {
            var shoeGenerator = new ShoeGenerator();
            var shoe = shoeGenerator.GenerateShoe( deckCount );
            shoe.Cards.Count.ShouldBe( 52 * deckCount ); // 52 * how many decks you specify,
        }                                                        // to make sure that the that there are no extra
    }                                                            // cards, or no less cards
}                
     

