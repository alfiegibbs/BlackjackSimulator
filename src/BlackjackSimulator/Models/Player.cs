namespace BlackjackSimulator.Models
{
    using System.Collections.Generic;

    public class Player
    {
        public double Money { get; set; } = 1000;
        public double Bet { get; set; } = 100;
        public List<Result> Results { get; set; }
        public List<Hand> Hands { get; set; }
    }
}
