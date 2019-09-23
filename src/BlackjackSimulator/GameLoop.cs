namespace BlackjackSimulator
{
    using System;
    using BlackjackSimulator.Deck;
    using BlackjackSimulator.Models;

    public class GameLoop
    {
        private readonly ASCIICardGenerator asciiGenerator = new ASCIICardGenerator();
        internal GameState GameState { get; } = new GameState();


        public GameLoop()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        public void Start()
        {
            Console.WriteLine( "Welcome to the Command Line Blackjack!" );
            InitialiseGameState();
            Game();
        }

        internal void InitialiseGameState()
        {
            GameState.Money = 500;
            // Give the dealer two initial cards
            GameState.DealDealerCard();
            GameState.DealDealerCard();
        }

        public void Game()
        {
            var card = GameState.DealPlayerCard();
            DisplayCard( card );

            while ( true )
            {
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
            Console.Clear();
            var hand = asciiGenerator.GenerateCardHandRepresentation( GameState.PlayerHand );
            hand.Render();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine( "\r\nYour hand total value is: " + GameState.PlayerHand.HandValue );
        }

        public PlayerAction GetUserChoice()
        {
            while ( true )
            {
                Console.ResetColor();
                Console.WriteLine( "Money: " + GameState.Money );
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
            var card = GameState.DealPlayerCard();
            DisplayCard( card );
        }

        public void ActionStand()
        {
            Console.WriteLine( "\r\nYou chose stand!" );
            
        }

        public void ActionDouble()
        {
            Console.WriteLine( "\r\nYou chose double!" );
            GameState.DealPlayerCard();
        }
    }
}
