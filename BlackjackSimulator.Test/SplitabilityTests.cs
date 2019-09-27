namespace BlackjackSimulator.Test
{
    using BlackjackSimulator.Models;
    using Shouldly;
    using System.Collections.Generic;
    using Xunit;

    public class SplitabilityTests
    {
        [ Fact ]
        public void ShouldDetectSplitability()
        {
            var gameState = new GameState
            {
                PlayerHand = new Hand
                {
                    Cards = new List<Card>
                    {
                        new Card
                        {
                            Rank = Rank.Ace, 
                            Suit = Suit.Clubs
                        },

                        new Card
                        {
                            Rank = Rank.Ace, 
                            Suit = Suit.Clubs
                        }
                    }
                }
            };


            gameState.DetectSplitability().ShouldBeTrue();
        }
    }
}
