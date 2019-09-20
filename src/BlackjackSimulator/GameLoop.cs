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
                var choice = GetUserChoice();

                switch ( choice )
                {
                    case PlayerAction.Hit:
                        ActionHit();
                        break;
                    case PlayerAction.Stand:
                        break;
                    case PlayerAction.Double:
                        break;
                    case PlayerAction.Exit:
                        return;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
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

        public PlayerAction GetUserChoice()
        {
            while ( true )
            {
                Console.ResetColor();
                Console.WriteLine( $"HandValue: {gameState.HandValue}" );
                Console.WriteLine( "Enter (h) to hit, (s) to stand, (d) to double, (q) to quit" );

                var option = Console.ReadKey();

                switch ( option.KeyChar )
                {
                    case 'h':
                        return PlayerAction.Hit;
                    case 'q':
                        return PlayerAction.Exit;
                    case 's':
                        return PlayerAction.Stand;
                    case 'd':
                        return PlayerAction.Double;
                    default:
                        Console.WriteLine("\r\nThat is not a valid choice.");
                        break;
                }
            }
        }

        public void ActionHit()
        {
            Console.WriteLine( "\r\nYou chose hit!" );
            gameState.DealCard();
        }

        public void ActionStand()
        {
            Console.WriteLine( "\r\nYou chose stand!" );
        }

        public void ActionDouble()
        {
            Console.WriteLine( "\r\nYou chose double!" );
            gameState.DealCard();
        }
    }
}
