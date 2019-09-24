namespace BlackjackSimulator.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Hand
    {
        public List<Card> Cards { get; set; } = new List<Card>();
        public int HandValue => Cards.Sum( x => x.Value );
        public bool IsBust => HandValue > 21;


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
