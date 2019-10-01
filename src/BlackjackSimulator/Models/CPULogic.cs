namespace BlackjackSimulator.Models
{
    using System.Linq;

    public class CPULogic
    {
        private GameLoop GameLoop { get; } = new GameLoop();

        /* if cpu hand is from 2-8, hit, no matter the dealers cards
           if the cpu hand is a 9, and the dealers visible hand is from a 3 to a 6, double, else hit
           if cpu hand is a 10, and dealers visible hand is from a 2 to a 9, double, else hit
           if cpu hand is a 11, and dealers visible hand is from a 2 to a 10, double, else hit
           if cpu hand is a 12, and dealers visible hand is from a 4-6, stand, else hit,
           if a cpu hand is from 13-16, and dealers visible is from 2-6, stand, else hit
           no matter what, if cpu hand is above 17, stand

            soft hand, is if you have an ace
            hard hand, is if you have no ace
        */

        public void DetermineHit(GameState gameState)
        {
            if ( gameState.CPUHand.HandValue == int.Parse(Enumerable.Range( 2, 8 ).ToString()))
            {
                GameLoop.ActionHit();
            }
        }
    }
}
