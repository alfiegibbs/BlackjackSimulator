namespace BlackjackSimulator
{
    using System;
    using BlackjackSimulator.Models;
    using BlackjackSimulator.Player.Actions;

    class Program
    {
        static void Main( string[] args )
        {
            var gameState = new GameState();

            Console.WriteLine( "Welcome to the Command Line Blackjack!" );

            var card = gameState.DealCard();
            DisplayCard( card );

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\r\nYour hand total value is: " + card.Value);
            Console.ResetColor();
            Console.WriteLine("Enter (h) to hit, (s) to stand, (d) to double");
        }

        public static void DisplayCard( Card card )
        {
            if ( card.Suit == Suit.Diamonds || card.Suit == Suit.Hearts )
                Console.ForegroundColor = ConsoleColor.Red;

            Console.Write( $"{card.Rank:G} of {card.Suit:G}" );
        }
    }
}