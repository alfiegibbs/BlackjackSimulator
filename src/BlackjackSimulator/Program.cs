namespace BlackjackSimulator
{
    using System;
    using System.CodeDom;
    using System.Linq;
    using BlackjackSimulator.GlobalActions;
    using BlackjackSimulator.Models;

    class Program
    {
        static void Main( string[] args )
        {
            var gameState = new GameState();

            Console.WriteLine( "Welcome to the Command Line Blackjack!" );

            var card = gameState.DealCard();
            DisplayCard( card );
            Console.ReadLine();
        }

        public static void DisplayCard( Card card )
        {
            if ( card.Suit == Suit.Diamonds || card.Suit == Suit.Hearts )
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ResetColor();
            }

            Console.Write( $"{card.Rank.ToString()} of {card.Suit:G}" );
        }
    }
}
