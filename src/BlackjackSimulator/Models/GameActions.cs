namespace BlackjackSimulator.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GameActions
    {
        private Shoe CurrentShoe { get; set; }
        public Hand PlayerHand { get; set; } = new Hand();
        public List<Player> Hand { get; set; }

        public void InitialiseGameState()
        {
            CurrentShoe = new ShoeGenerator().GenerateShoe( 4 );
            CurrentShoe.Shuffle();
        }

        public Card DealCard( Hand hand )
        {
            var cardFromShoe = CurrentShoe.DealCard();
            hand.AddCard( cardFromShoe );

            return cardFromShoe;
        }

        // ReSharper disable once MemberCanBeMadeStatic.Global
        public void DisplayHand( Hand hand )
        {
            string text = hand.Cards
                           .Select( x => x.ToString() )
                           .Aggregate( ( lhs, rhs ) => lhs + $"\r\n{rhs}" );

            Console.WriteLine(text);
        }
    }
}
