namespace BlackjackSimulator
{
    using System;
    using BlackjackSimulator.Models;

    public class GameLoop
    {
        private readonly GameState gameState = new GameState();

        public void Start()
        {
            Console.WriteLine( "Welcome to the Command Line Blackjack!" );
            Game();
        }

        public void Game()
        {
            while ( true )
            {
                var card = gameState.DealCard();
                DisplayCard( card );
                DisplayChoice();
                ActionHit();
            }
        }

        public void DisplayCard( Card card )
        {
            if ( card.Suit == Suit.Diamonds || card.Suit == Suit.Hearts )
                Console.ForegroundColor = ConsoleColor.Red;

            Console.Write( $"{card.Rank:G} of {card.Suit:G}" );
            gameState.HandValue += card.Value;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine( "\r\nYour hand total value is: " + gameState.HandValue );
        }

        public PlayerAction DisplayChoice()
        {
            Console.ResetColor();
            Console.WriteLine( $"HandValue: {gameState.HandValue}" );
            Console.WriteLine( "Enter (h) to hit, (s) to stand, (d) to double, (q) to quit" );

            var option = Console.ReadKey();

            if ( option.KeyChar == 'h' )
            {
                Console.WriteLine( "\r\nYou chose hit!" );
                ActionHit();
                return PlayerAction.Hit;
            }

            if ( option.KeyChar == 'q' )
            {
                Environment.Exit(0);
                return PlayerAction.Exit;
            }

            if ( option.KeyChar == 's' )
            {
                Console.WriteLine( "\r\nYou chose stand!" );
                return PlayerAction.Stand;
            }

            if ( option.KeyChar == 'd' )
            {
                Console.WriteLine( "\r\nYou chose double!" );
                return PlayerAction.Double;
            }

            return PlayerAction.Exit;
        }

        public void ActionHit()
        {
            Console.WriteLine( "\r\nYou chose hit!" );
            gameState.DealCard();
        }
    }
}
