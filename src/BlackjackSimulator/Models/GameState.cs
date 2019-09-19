namespace BlackjackSimulator.Models
{
    using BlackjackSimulator.Deck;
    using System.Linq;

    public class GameState
    {
        public Shoe CurrentShoe { get; set; }

        public GameState()
        {
            CurrentShoe = new ShoeGenerator().GenerateShoe( 4 );
            CurrentShoe.Shuffle();
        }

        public Card DealCard()
        {
            var originalShoe = CurrentShoe.Cards.ToList();
            var card = originalShoe[ 0 ];
            CurrentShoe.Cards.Remove( card );

            return card;
        }
    }
}
