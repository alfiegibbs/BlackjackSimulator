namespace BlackjackSimulator.Models.CardColour
{
    using System.Collections.Generic;
    using System.Drawing;
    using Colorful;

    public class CardHandRepresentation
    {
        public bool IsOverCardLimit { get; set; }
        public string RawText { get; set; }
        public List<CardHandLine> CardHandLines { get; set; } = new List<CardHandLine>();

        public void Render()
        {
            if ( IsOverCardLimit )
            {
                Console.WriteLine(RawText);
                return;
            }

            foreach ( var cardHandLine in CardHandLines )
            {
                foreach ( var segment in cardHandLine.CardLineSegments )
                {
                    Console.Write( segment.Text + " ", segment.Colour );
                }

                Console.Write( System.Environment.NewLine );
            }
        }
    }

    public class CardHandLine
    {
        public List<CardLineSegment> CardLineSegments { get; set; } = new List<CardLineSegment>();
    }

    public class CardLineSegment
    {
        public string Text { get; set; }
        public Color Colour { get; set; }
    }
}
