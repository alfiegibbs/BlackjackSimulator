namespace BlackjackSimulator
{
    using System;
    using BlackjackSimulator.Models;
    using BlackjackSimulator.Player.Actions;

    class Program
    {
        static readonly GameState gameState = new GameState();

        static void Main( string[] args )
        {
            var game = new GameLoop();
            game.Start();
        }
    }
}
