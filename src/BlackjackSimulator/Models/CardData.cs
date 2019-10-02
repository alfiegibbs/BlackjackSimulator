namespace BlackjackSimulator.Models
{
    using System.Collections.Generic;

    public static class CardData
    {
        public static readonly Dictionary<Suit, string> SuitNames = new Dictionary<Suit, string>
        {
            { Suit.Clubs, "♣" },
            { Suit.Spades, "♠" },
            { Suit.Hearts, "♠" },
            { Suit.Diamonds, "♦" }
        };

        public static readonly Dictionary<Rank, string> RankNames = new Dictionary<Rank, string>
        {
            { Rank.Ace, "A" },
            { Rank.Two, "2" },
            { Rank.Three, "3" },
            { Rank.Four, "4" },
            { Rank.Five, "5" },
            { Rank.Six, "6" },
            { Rank.Seven, "7" },
            { Rank.Eight, "8" },
            { Rank.Nine, "9" },
            { Rank.Ten, "10" },
            { Rank.Jack, "J" },
            { Rank.Queen, "Q" },
            { Rank.King, "K" },
        };

        public static readonly Dictionary<Rank, int> RankValue = new Dictionary<Rank, int>
        {
            { Rank.Ace, 11 },
            { Rank.Two, 2 },
            { Rank.Three, 3 },
            { Rank.Four, 4 },
            { Rank.Five, 5 },
            { Rank.Six, 6 },
            { Rank.Seven, 7 },
            { Rank.Eight, 8 },
            { Rank.Nine, 9 },
            { Rank.Ten, 10 },
            { Rank.Jack, 10 },
            { Rank.King, 10 },
            { Rank.Queen, 10 },
        };
    }
}
