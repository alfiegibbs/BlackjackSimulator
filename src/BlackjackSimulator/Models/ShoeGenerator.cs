namespace BlackjackSimulator.Models
{
    public class ShoeGenerator
    {
        public Shoe GenerateShoe( int deckCount )
        {
            var shoe = new Shoe();
            for ( var i = 0; i < deckCount; i++ )
            {
                var deckG = new DeckGenerator();
                var deck = deckG.GenerateDeck();
                shoe.Populate( deck );
            }

            return shoe;
        }
    }
}
