namespace BlackjackSimulator.Models
{
    using System;

    public class Card
    {
        public Rank Rank { get; set; }
        public Suit Suit { get; set; }

        public int Value
        {
            get
            {
                switch ( Rank )
                {
                    case Rank.Ace:
                        return 11;
                    case Rank.Two:
                        return 2;
                    case Rank.Three:
                        return 3;
                    case Rank.Four:
                        return 4;
                    case Rank.Five:
                        return 5;
                    case Rank.Six:
                        return 6;
                    case Rank.Seven:
                        return 7;
                    case Rank.Eight:
                        return 8;
                    case Rank.Nine:
                        return 9;
                    case Rank.Ten:
                    case Rank.Jack:
                    case Rank.Queen:
                    case Rank.King:
                        return 10;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public override string ToString()
        {
            return $"{Rank.ToString()}_{Suit:G}";
        }
    }
}
