namespace BlackjackSimulator
{
    using System.Collections.Generic;
    using BlackjackSimulator.Models;

    public class Dealer
    {
        public List<Result> Results { get; set; } = new List<Result>();
        public Hand DealerHand { get; set; } = new Hand();
    }
}
