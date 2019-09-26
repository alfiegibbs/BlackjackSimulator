namespace BlackjackSimulator.Test
{
    using System.Collections.Generic;
    using BlackjackSimulator.Models;
    using Shouldly;
    using Xunit;

    public class BlackjackTest
    {
        [ Fact ]
        public void ShouldGetBlackjack()
        {
            var gameLoop = new GameLoop();

            gameLoop.GameState.PlayerHand = new Hand()
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
                        Rank = Rank.Jack,
                        Suit = Suit.Clubs
                    }
                }
            };

            gameLoop.GameState.DetectBlackjack().ShouldBeTrue();

        }
        
        [ Fact ]
        public void ShouldNotGetBlackjack()
        {
            var gameLoop = new GameLoop();

            gameLoop.GameState.PlayerHand = new Hand()
            {
                Cards = new List<Card>
                {
                    new Card
                    {
                        Rank = Rank.Seven,
                        Suit = Suit.Clubs
                    },
                    
                    new Card
                    {
                        Rank = Rank.Jack,
                        Suit = Suit.Clubs
                    }
                }
            };

            gameLoop.GameState.DetectBlackjack().ShouldBeFalse();

        }
        
    }
}
