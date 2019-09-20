namespace BlackjackSimulator.Deck
{
    using System;
    using BlackjackSimulator.Models;

    public class ASCIICardGenerator
    {
        public string GenerateTextForCard( Card card )
        {
            string cardText = GetCardText( card );

            switch ( card.Suit )
            {
                case Suit.Clubs:
                    return cardText.Replace( "X", "♣" );
                case Suit.Hearts:
                    return cardText.Replace( "X", "♥" );
                case Suit.Spades:
                    return cardText.Replace( "X", "♠" );
                case Suit.Diamonds:
                    return cardText.Replace( "X", "♦" );
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public string GetCardText( Card card )
        {
            switch ( card.Rank )
            {
                case Rank.Ace:
                    return AceCard;
                case Rank.Two:
                    return TwoCard;
                case Rank.Three:
                    return ThreeCard;
                case Rank.Four:
                    return FourCard;
                case Rank.Five:
                    return FiveCard;
                case Rank.Six:
                    return SixCard;
                case Rank.Seven:
                    return SevenCard;
                case Rank.Eight:
                    return EightCard;
                case Rank.Nine:
                    return NineCard;
                case Rank.Ten:
                    return TenCard;
                case Rank.Jack:
                    return JackCard;
                case Rank.Queen:
                    return QueenCard;
                case Rank.King:
                    return KingCard;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string AceCard =
            @" -------------
|AX           |
|   -------   |
|  |       |  |
|  |       |  |
|  |       |  |
|  |   X   |  |
|  |       |  |
|  |       |  |
|  |       |  |
|   -------   |
|           XA|
 -------------";

        public static string TwoCard = @" -------------
|2X           |
|   -------   |
|  |       |  |
|  |   X   |  |
|  |       |  |
|  |       |  |
|  |       |  |
|  |   X   |  |
|  |       |  |
|   -------   |
|           X2|
 -------------";

        public static string ThreeCard = @" -------------
|3X           |
|   -------   |
|  |   X   |  |
|  |       |  |
|  |       |  |
|  |   X   |  |
|  |       |  |
|  |       |  |
|  |   X   |  |
|   -------   |
|           X3|
 -------------";

        public static string FourCard = @" -------------
|4X           |
|   -------   |
|  |X     X|  |
|  |       |  |
|  |       |  |
|  |       |  |
|  |       |  |
|  |       |  |
|  |X     X|  |
|   -------   |
|           X4|
 -------------";

        public static string FiveCard = @" -------------
|5X           |
|   -------   |
|  |X     X|  |
|  |       |  |
|  |       |  |
|  |   X   |  |
|  |       |  |
|  |       |  |
|  |X     X|  |
|   -------   |
|           X5|
 -------------";

        public static string SixCard = @" -------------
|6X           |
|   -------   |
|  |X     X|  |
|  |       |  |
|  |       |  |
|  |X     X|  |
|  |       |  |
|  |       |  |
|  |X     X|  |
|   -------   |
|           X6|
 -------------";

        public static string SevenCard = @" -------------
|7X           |
|   -------   |
|  |X     X|  |
|  |   X   |  |
|  |       |  |
|  |X     X|  |
|  |       |  |
|  |       |  |
|  |X     X|  |
|   -------   |
|           X7|
 -------------";

        public static string EightCard = @" -------------
|8X           |
|   -------   |
|  |X     X|  |
|  |       |  |
|  |X     X|  |
|  |       |  |
|  |X     X|  |
|  |       |  |
|  |X     X|  |
|   -------   |
|           X8|
 -------------";

        public static string NineCard = @" -------------
|9X           |
|   -------   |
|  |X     X|  |
|  |       |  |
|  |X     X|  |
|  |   X   |  |
|  |X     X|  |
|  |       |  |
|  |X     X|  |
|   -------   |
|           X9|
 -------------";

        public static string TenCard = @" -------------
|10X          |
|   -------   |
|  |X     X|  |
|  |   X   |  |
|  |X     X|  |
|  |       |  |
|  |X     X|  |
|  |   X   |  |
|  |X     X|  |
|   -------   |
|          X10|
 -------------";

        public static string JackCard = @" -------------
|JX           |
|   -------   |
|  |X      |  |
|  |       |  |
|  |       |  |
|  |   J   |  |
|  |       |  |
|  |       |  |
|  |      X|  |
|   -------   |
|           XJ|
 -------------";

        public static string QueenCard = @" -------------
|QX           |
|   -------   |
|  |X      |  |
|  |       |  |
|  |       |  |
|  |   Q   |  |
|  |       |  |
|  |       |  |
|  |      X|  |
|   -------   |
|           XQ|
 -------------";

        public static string KingCard = @" -------------
|KX           |
|   -------   |
|  |X      |  |
|  |       |  |
|  |       |  |
|  |   K   |  |
|  |       |  |
|  |       |  |
|  |      X|  |
|   -------   |
|           XK|
 -------------";

    }
}
