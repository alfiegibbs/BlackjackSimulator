namespace BlackjackSimulator.Player.Actions
{
    using System;
    using BlackjackSimulator.Models;

    public class Hit
    {
        public static void ActionHit()
        {
            if (Console.ReadKey().KeyChar == 'h')
            {
                var gameState = new GameState();
                var card = gameState.DealCard();
                BlackjackSimulator.Program.DisplayCard( card );
                Console.ReadLine();
            }
        }

        public static void GetKeyHit()
        {
            var keyHit = Console.ReadKey();
        }
    }
}