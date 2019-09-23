namespace BlackjackSimulator.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BlackjackSimulator.Models;
    using BlackjackSimulator.Models.CardColour;
    using Shouldly;
    using Xunit;

    public class DealerTests
    {
        [ Fact ]
        public void DealerShouldHaveTwoCardsAtStartOfGame()
        {
            var gameLoop = new GameLoop();
            gameLoop.InitialiseGameState();
            gameLoop.GameState.DealerHand.Cards.Count.ShouldBe( 2 );
        }

        [ Fact ]
        public void DealerShouldGetCardsUntil17OrMore()
        {
            var gameLoop = new GameLoop();

            gameLoop.GameState.Bet = 50;
            gameLoop.GameState.PlayerHand = new Hand
            {
                Cards = new List<Card>
                {
                    new Card
                    {
                        Suit = Suit.Clubs,
                        Rank = Rank.Eight
                    },
                    new Card
                    {
                        Suit = Suit.Diamonds,
                        Rank = Rank.Seven
                    },
                    new Card
                    {
                        Suit = Suit.Clubs,
                        Rank = Rank.Three
                    }
                }
            };


            gameLoop.GameState.DealerHand = new Hand
            {
                Cards = new List<Card>
                {
                    new Card
                    {
                        Suit = Suit.Clubs,
                        Rank = Rank.Five
                    },
                    new Card
                    {
                        Suit = Suit.Diamonds,
                        Rank = Rank.Nine
                    },
                    new Card
                    {
                        Suit = Suit.Clubs,
                        Rank = Rank.Three
                    }
                }
            };

            gameLoop.ActionStand();
        }
    }
}
