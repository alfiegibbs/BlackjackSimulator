namespace BlackjackSimulator.Test
{
    using BlackjackSimulator.Models;
    using Shouldly;
    using Xunit;

    public class CardTests
    {
        [ Fact ]
        public void RanksShouldHaveStringValues()
        {
            var x = new Card(Rank.Ace, Suit.Clubs );
            string y = CardData.RankNames[ Rank.Five ];
            y.ShouldBe( "5" );
        }

        [ Fact ]
        public void RankShouldHaveIntValues()
        {
            var x = new Card(Rank.Ace, Suit.Clubs);
            int y = CardData.RankValue[ Rank.Five ];
            y.ShouldBe( 5 );
        }

        [ Fact ]
        public void SuitShouldHaveStringValue()
        {
            var x = new Card(Rank.Ace, Suit.Clubs);
            string y = CardData.SuitNames[ Suit.Clubs ];
            y.ShouldBe( "♣" );
        }
    }
}
