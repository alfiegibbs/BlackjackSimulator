namespace BlackjackSimulator.Deck
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using BlackjackSimulator.Models;
    using BlackjackSimulator.Models.CardColour;

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

//        public string GenerateTextForHand( Hand hand )
//        {
//            var sb = new StringBuilder();
//
//            var cardList = hand.Cards.Select( GenerateTextForCard ).ToList();
//
//            string firstCard = cardList.FirstOrDefault();
//            if ( firstCard == null )
//            {
//                return "Card is null.";
//            }
//
//            int numLines = firstCard.Length - firstCard.Replace( Environment.NewLine, string.Empty ).Length;
//
//            for ( int i = 0; i < numLines; i++ )
//            {
//                var lineBuilder = new StringBuilder();
//                foreach ( string line in cardList.Select( cardAscii => GetLine( cardAscii, i + 1 ) ) )
//                {
//                    lineBuilder.Append( line + " " );
//                }
//
//                sb.AppendLine( lineBuilder.ToString() );
//            }
//
//            return sb.ToString();
//        }

        public CardHandRepresentation GenerateCardHandRepresentation( Hand hand )
        {
            var cardHandRepresentation = new CardHandRepresentation
            {
                RawText = hand.Cards
                              .Select( x => x.ToString() ) // goes over the cards and gets a string representation of them and sticks them in a list
                              .Aggregate( ( lhs, rhs ) => lhs + $"\r\n{rhs}" ) // sticking the hand together, seperated by new lines.
            };

            if ( hand.Cards.Count >= 7 )
            {
                cardHandRepresentation.IsOverCardLimit = true;
                return cardHandRepresentation;
            }

            var cardList = hand.Cards.Select( GenerateTextForCard ).ToList();

            string firstCard = cardList.FirstOrDefault();
            if ( firstCard == null )
            {
                return null;
            }

            for ( int i = 0; i < 13; i++ )
            {
                var cardHandLine = new CardHandLine();
                foreach ( var card in hand.Cards )
                {
                    string cardAscii = GetLine( GenerateTextForCard( card ), i + 1 ); // get the specified line
                    cardHandLine.CardLineSegments.Add( new CardLineSegment // add properties, Text, Colour, to CardLineSegment
                    {
                        Text = cardAscii,
                        Colour = card.Suit == Models.Suit.Diamonds || card.Suit == Models.Suit.Hearts // if the suit is diamonds or hearts, set the colour to red, by default the colour will be white
                            ? Color.FromArgb( 231, 72, 86 )
                            : Color.FromArgb( 204, 204, 204 )
                    } );
                }

                cardHandRepresentation.CardHandLines.Add( cardHandLine );
            }

            return cardHandRepresentation;
        }

        private string GetLine( string text, int lineNo )
        {
            string[] lines = text.Replace( "\r", "" ).Split( '\n' );
            return lines.Length >= lineNo ? lines[ lineNo - 1 ] : null;
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
 ------------- ";

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
 ------------- ";

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
 ------------- ";

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
 ------------- ";

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
 ------------- ";

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
 ------------- ";

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
 ------------- ";

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
 ------------- ";

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
 ------------- ";

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
 ------------- ";

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
 ------------- ";

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
 ------------- ";

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
 ------------- ";

        public static string BackCard = @" ------------- 
|* * * * * * *|
| * * * * * * |
|* * * * * * *|
| * * * * * * |
|* * * * * * *|
| * * * * * * |
|* * * * * * *|
| * * * * * * |
|* * * * * * *|
| * * * * * * |
|* * * * * * *|
 ------------- ";

    }
}
