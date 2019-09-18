namespace BlackjackSimulator.Deck
{
    using BlackjackSimulator.Models;

    public class ShoeGenerator
    {
        public Shoe GenerateShoe( int deckCount )
        {
            var shoe = new Shoe();
            for (int i = 0; i < deckCount; i++)
            {
                var deck = DeckGenerator.GenerateDeck();
                shoe.Populate(deck);
            }
            return shoe;
        }
    }
}
