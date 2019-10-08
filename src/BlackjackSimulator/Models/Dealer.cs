namespace BlackjackSimulator.Models
{
    public class Dealer
    {
        public Hand DealerHand { get; set; } = new Hand();

        public Card DealCard( Hand hand )
        {
            var cardFromShoe = GameActions.CurrentShoe.DealCard();
            hand.AddCard( cardFromShoe );

            return cardFromShoe;
        }
    }
}
