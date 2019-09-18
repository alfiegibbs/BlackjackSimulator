namespace BlackjackSimulator.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BlackjackSimulator.Deck;
    using BlackjackSimulator.Models;
    using Shouldly;
    using Xunit;

    public class ShoeShuffleTests
    {
        // Shuffle cards in a shoe so two simultaneous cards are not in sequence
        [ Fact ]
        public Shoe ShouldShuffleShoe()
        {
            // Generate a shoe of 4 decks
            var shoe = new ShoeGenerator();
            shoe.GenerateShoe( 4 );

            // Make sure card are not simultaneous
            var cards = new List<Card>();
            Random random = new Random();
            // generate random number with a maximum number of the amount of cards in the shoe
            foreach ( var unused in cards )
            {
                int randomNumber = random.Next( cards.Count );
                var card = cards[ randomNumber ];
                cards.RemoveAt( randomNumber );
                cards.Add(card);
            }
            var shoeReturn = new Shoe();
            return shoeReturn;
        }
    }
}
