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

            gameState.DetectSplitability().ShouldBeTrue();
        }
    }
}
