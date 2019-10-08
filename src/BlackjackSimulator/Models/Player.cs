namespace BlackjackSimulator.Models
{
    using System.Collections.Generic;

    public class Player
    {
        private const double Bet = 100;
        private double Money { get; set; } = 1000;
        public List<Result> Results { get; set; } = new List<Result>();
        public List<Hand> Hands { get; set; } = new List<Hand>();

        public void TakeBet()
        {
            Money -= Bet;
        }

        public void AddToHand( Hand hand )
        {
            Hands.Add( hand );
        }
    }
}
