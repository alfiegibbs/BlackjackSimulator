namespace BlackjackSimulator
{
    using System;
    using BlackjackSimulator.Models;

    class Program
    {
        private static readonly GameState gameState = new GameState();

        private static void Main( string[] args )
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var game = new GameLoop();
            game.Start();
        }
    }
}
