namespace BlackjackSimulator.GlobalActions
{
    using BlackjackSimulator.Deck;
    using BlackjackSimulator.Models;
    using System;
    using System.Linq;
    using BlackjackSimulator.Player;

    public class DealCards
    {
        public void CardDeal()
        {
            var shoeGenerator = new ShoeGenerator();
            Shoe shoe = shoeGenerator.GenerateShoe( 4 );

            shoe.Shuffle();

            var originalShoe = shoe.Cards.ToList();

            var cardRank = originalShoe[ 0 ].Rank;
            var cardSuit = originalShoe[ 0 ].Suit;
            string card = $"{cardRank} of {cardSuit}";

            if ( cardSuit == Suit.Diamonds || cardSuit == Suit.Hearts )
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            originalShoe.RemoveAt( 0 );
        }
    }
}
