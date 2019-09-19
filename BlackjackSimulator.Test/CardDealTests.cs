namespace BlackjackSimulator.Test
{
    using System.Collections.Generic;
    using BlackjackSimulator.GlobalActions;
    using BlackjackSimulator.Models;
    using BlackjackSimulator.Player;
    using Shouldly;
    using Xunit;

    public class CardDealTests
    {
        [ Fact ]
        public static void ShouldAddDealtCardsToList()
        {
            var card = new DealCards();
            var hand = new List<PlayerHand>();

            hand.Count.ShouldNotBe( 0 );
        }
    }
}
