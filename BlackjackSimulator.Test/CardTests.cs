namespace BlackjackSimulator.Test
{
    using BlackjackSimulator.Models;
    using Shouldly;
    using Xunit;

    public class CardTests
    {
        [ Fact ]
        public static void CardShouldGenerateHash()
        {
            var card = new Card();
            card.ToString().ShouldBe( "Ace_Clubs" );
        }

        [ Fact ]
        public static void ShouldGenerateSameHashTwice()
        {
            var card = new Card();
            var card2 = new Card();
            card.ToString().ShouldBe( card2.ToString() );
        }

        [ Fact ]
        public static void ShouldNotGenerateSameHashTwice()
        {
            var card = new Card();
            var card2 = new Card
            {
                Rank = Rank.Eight,
                Suit = Suit.Diamonds
            };
            card.ToString().ShouldNotBe( card2.ToString() );
        }
    }
}
