namespace BlackjackSimulator
{
    using System;
    using System.Linq;
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
            // Give the dealer two initial cards
            GameState.DealDealerCardUp();
            GameState.DealDealerCard();
        }

        public void Game()
        {
            PlaceBet();

            GameState.DealPlayerCard();
            DisplayPlayerHand();
            Console.WriteLine( $"A table fee of {GameState.Bet} has been taken." );

            while ( true )
            {
                var choice = GetUserChoice();

                switch ( choice )
                {
                    case PlayerAction.Hit:
                        ActionHit();
                        break;
                    case PlayerAction.Stand:
                        ActionStand();
                        break;
                    case PlayerAction.Double:
                        ActionDouble();
                        break;
                    case PlayerAction.Exit:
                        return;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                CPULogic();
            }
        }

        private void PlaceBet()
        {
            GameState.Money -= GameState.Bet;
        }

        public void DisplayPlayerHand()
        {
            Console.Clear();
            var hand = asciiGenerator.GenerateCardHandRepresentation( GameState.PlayerHand );
            hand.Render();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine( $"\r\nYour hand total value is: {GameState.PlayerHand.HandValue}" );

            GameState.DetectBlackjack();
        }

        public void DisplayDealerHand()
        {
            foreach ( var card in GameState.DealerHand.Cards )
            {
                card.IsVisible = true;
            }

            var hand = asciiGenerator.GenerateCardHandRepresentation( GameState.DealerHand );
            hand.Render();
        }

        public void DisplayCPUHand()
        {


            var hand = asciiGenerator.GenerateCardHandRepresentation( GameState.CPUHand );
            hand.Render();
        }

        public PlayerAction GetUserChoice()
        {
            while ( true )
            {
                Console.ResetColor();
                Console.WriteLine( $"Money: {GameState.Money}, Stake: {GameState.Bet}" );
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

        public void CPULogic()
        {
            if ( GameState.CPUHand.IsBust )
            {
                return;
            }

            if ( GameState.CPUHand.HandValue < 17 )
            {
                ActionHitCPU();
            }
            else if ( GameState.CPUHand.HandValue > 17 )
            {
                ActionStandCPU();
            }
        }

        public void ActionHit()
        {
            Console.WriteLine( "\r\nYou chose hit!" );

            GameState.DealPlayerCard();
            DisplayPlayerHand();

            if ( GameState.PlayerHand.HandValue > 21 )
            {
                var oldColour = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine( "You have gone bust!" );
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine( "To start a new game press (h)." );
                Console.ForegroundColor = oldColour;
                GameState.ResetGameState();
                Console.WriteLine( $"Money: {GameState.Money}, Stake: {GameState.Bet}" );
                PlaceBet();
            }
        }

        public void ActionHitCPU()
        {
            Console.WriteLine( "CPU Chose hit!" );
            GameState.DealCPUCard();

            if ( GameState.CPUHand.HandValue > 21 )
            {
                GameState.ResetGameState();
                PlaceBet();
            }
        }

        public void ActionStand()
        {
            if ( GameState.PlayerHand.HandValue < 17 )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine( "\r\nYou cannot stand yet, you need a hand value of 17 or above to stand" );
            }
            else
            {
                Console.WriteLine( "\r\nYou chose stand!" );

                DealDealerCards();
                Console.WriteLine( "\r\nDealer Cards:\r\n" );
                DisplayDealerHand();
                DetermineWinner();
                GameState.ResetGameState();
                PlaceBet();
            }
        }

        public void ActionStandCPU()
        {
            Console.WriteLine( "CPU Chose stand!" );

            if ( GameState.PlayerHand.HandValue < 17 )
            {
                Console.WriteLine( "CPU Stood!" );
            }
            else
            {
                DetermineWinner();
                GameState.ResetGameState();
                PlaceBet();
            }
        }

        private void DealDealerCards()
        {
            while ( GameState.DealerHand.HandValue < 17 )
            {
                GameState.DealDealerCardUp();
            }
        }

        public void ActionDouble()
        {
            if ( GameState.Money <= GameState.Bet )
            {
                Console.WriteLine( "\r\nYou chose double!" );
                GameState.Money -= GameState.Bet;
                GameState.Bet *= 2;

                GameState.DealPlayerCard();
                DisplayPlayerHand();
                DealDealerCards();
                Console.WriteLine( "\r\nDealer Cards:\r\n" );
                DisplayDealerHand();
                DetermineWinner();
                GameState.ResetGameState();
                GameState.Bet /= 2;
                PlaceBet();
            }
            else
            {
                Console.WriteLine( $"You do not have enough money to double, at least {GameState.Bet} is required" );
            }
        }

        public void DetermineWinner()
        {
            DisplayCPUHand();
            if ( ( GameState.DealerHand.HandValue < GameState.PlayerHand.HandValue ) && !GameState.PlayerHand.IsBust )
            {
                Console.WriteLine( "Player has won" );
                var oC = Console.ForegroundColor; // Original console foreground colour
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine( "You have earnt 2x your initial bet!" );
                GameState.Money += GameState.Bet * 2;
                Console.ForegroundColor = oC;
            }
            else if ( !GameState.DealerHand.IsBust )
            {
                Console.WriteLine( "Dealer has won" );
            }
            else if ( GameState.DealerHand.HandValue == GameState.PlayerHand.HandValue && !GameState.PlayerHand.IsBust )
            {
                Console.WriteLine( "It's a draw! Initial bet has been returned to the player" );
                GameState.Money += GameState.Bet;
            }
            else if ( GameState.DealerHand.IsBust )
            {
                Console.WriteLine( "The player has won! Dealer went bust." );
                var oC = Console.ForegroundColor; // Original console foreground colour
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine( "You have earnt 2x your initial bet!" );
                GameState.Money += GameState.Bet * 2;
                Console.ForegroundColor = oC;
            }
            else
            {
                Console.WriteLine( "No one has won! Both player and dealer went bust!" );
            }

            // CPUHand

            if ( ( GameState.DealerHand.HandValue < GameState.CPUHand.HandValue ) && !GameState.CPUHand.IsBust )
            {
                Console.WriteLine( "CPU has won" );
            }
            else if ( !GameState.DealerHand.IsBust )
            {
                Console.WriteLine( "Dealer has won" );
            }
            else if ( GameState.DealerHand.HandValue == GameState.CPUHand.HandValue && !GameState.CPUHand.IsBust )
            {
                GameState.Money += GameState.Bet;
            }
            else if ( GameState.DealerHand.IsBust )
            {
                Console.WriteLine( "The CPU has won! Dealer went bust." );
                GameState.Money += GameState.Bet * 2;
            }
            else
            {
                Console.WriteLine( "No one has won! Both player and dealer went bust!" );
            }
        }
    }
}
