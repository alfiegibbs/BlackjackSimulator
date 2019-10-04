namespace BlackjackSimulator.Models
{
    using System.Linq;

    public class GameActions
    {
        public Shoe CurrentShoe { get; set; }
        public Hand PlayerHand { get; set; } = new Hand();

        public void InitialiseGameState()
        {
            CurrentShoe = new ShoeGenerator().GenerateShoe( 4 );
            CurrentShoe.Shuffle();
        }

        public Card DealCard( Hand hand )
        {
            var cardFromShoe = CurrentShoe.DealCard();
            hand.AddCard( cardFromShoe );

            return cardFromShoe;
        }
    }
}
