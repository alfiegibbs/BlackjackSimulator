namespace BlackjackSimulator.Models
{
    using System.Collections.Generic;
    using System.Text;

    public class Hand
    {
        public List<Card> Cards { get; set; } = new List<Card>();

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach ( var card in Cards )
            {
                sb.Append( card );
                sb.Append( " " );
            }

            return sb.ToString();
        }
    }
}
