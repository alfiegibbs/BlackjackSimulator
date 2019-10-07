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

            Console.WriteLine( "How many players are playing?:" );
            int count = int.Parse( Console.ReadLine() ?? throw new InvalidOperationException() );
            GameActions.InitialiseGameState( count );
            Game();
        }

        private void Game()
        {
            while ( GameActions.GameMode )
            {
                Console.WriteLine( "\r\nPress (h) to hit, (s) to stand, (d) to double, (p) to split, (q) to quit." );
                GameActions.GetUserChoice();
            }
        }
    }
}
