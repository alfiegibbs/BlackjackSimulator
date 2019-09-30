namespace BlackjackSimulator.Test
{
    using BlackjackSimulator.Models;
    using Shouldly;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class SplitabilityTests
    {
        [ Fact ]
        public void ShouldDetectSplitability()
        {
            var gameLoop = new GameLoop();

            var gameState = new GameState
            {
                PlayerHand = new Hand
                {
                    Cards = new List<Card>
                    {
                        new Card
                        {
                            Rank = Rank.Five,
                            Suit = Suit.Clubs
                        },

                        new Card
                        {
                            Rank = Rank.Five,
                            Suit = Suit.Clubs
                        }
                    }
                }
            };

            
            var groups = gameState.PlayerHand.Cards.GroupBy( x => new { x.Rank, x.Suit } );
            var cardsPerGroup = groups.Select( x => x.Count() );

            var splitCard = gameState.PlayerHand.Cards[ 0 ];
            gameState.PlayerHand.Cards.Remove( gameState.PlayerHand.Cards[ 0 ] );

            var playerSplitHand = gameState.PlayerSplitHand = new Hand
            {
                Cards = new List<Card>()
            };

            playerSplitHand.Cards.Add( splitCard );

            var first = gameState.PlayerHand.Cards.First();
            var expected = gameState.PlayerSplitHand.Cards.First();
            first.Suit.ShouldBe( expected.Suit );
            first.Rank.ShouldBe( expected.Rank );
        }
    }
}
