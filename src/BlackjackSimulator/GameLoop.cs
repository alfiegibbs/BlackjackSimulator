namespace BlackjackSimulator
{
    using System;
    using BlackjackSimulator.Models;

    public class GameLoop
    {
        private GameActions GameActions { get; } = new GameActions();

        public GameLoop()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        public void Start()
        {
            Console.WriteLine( "Welcome to the Command Line Blackjack!" );
            GameActions.InitialiseGameState();
            GameActions.DealCard( GameActions.PlayerHand);
            GameActions.DisplayHand( GameActions.PlayerHand );
            Console.ReadLine();
        }
    }
} 
