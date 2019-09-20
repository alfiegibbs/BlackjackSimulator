namespace BlackjackSimulator.Models
{
    using System;

    public static class CardExtensions
    {
        public static string ToSuitUTF8( this Card card )
        {
            switch ( card.Suit )
            {
                case Suit.Spades:
                    return "♠";
                case Suit.Diamonds:
                    return "♦";
                case Suit.Hearts:
                    return "♥";
                case Suit.Clubs:
                    return "♣";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        public static string ToRank( this Card card )
        {
            switch ( card.Rank )
            {
                case Rank.Ace:
                    return "11";
                case Rank.Two:
                    return "2";
                case Rank.Three:
                    return "3";
                case Rank.Four:
                    return "4";
                case Rank.Five:
                    return "5";
                case Rank.Six:
                    return "6";
                case Rank.Seven:
                    return "7";
                case Rank.Eight:
                    return "8";
                case Rank.Nine:
                    return "9";
                case Rank.Ten:
                    return "10";
                case Rank.Jack:
                    return "J";
                case Rank.Queen:
                    return "Q";
                case Rank.King:
                    return "K";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


    }
}
