namespace BlackjackSimulator
{
    using System;
    using BlackjackSimulator.Deck;
    using BlackjackSimulator.Models;

    public class GameLoop
    {
        private readonly ASCIICardGenerator asciiGenerator = new ASCIICardGenerator();
        private readonly GameState gameState = new GameState();

        public GameLoop()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        public void Start()
        {
            Console.WriteLine( "Welcome to the Command Line Blackjack!" );
            gameState.Money = 500;
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
            if ( card.Suit == Models.Suit.Diamonds || card.Suit == Models.Suit.Hearts )
                Console.ForegroundColor = ConsoleColor.Red;


            Console.Write( asciiGenerator.GenerateTextForCard( card ) + "\r\n" );

//            Console.WriteLine( $"{card.ToRank()}{card.ToSuitUTF8()}" );
            gameState.HandValue += card.Value;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine( "\r\nYour hand total value is: " + gameState.HandValue );
        }

        public PlayerAction GetUserChoice()
        {
            while ( true )
            {
                Console.ResetColor();
                Console.WriteLine( "Money: " + gameState.Money );
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
                        Console.WriteLine( "\r\nThat is not a valid choice." );
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
