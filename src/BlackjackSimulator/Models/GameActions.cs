namespace BlackjackSimulator.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    public class GameActions
    {
        private List<Player> Players { get; set; } = new List<Player>();
        private Shoe CurrentShoe { get; set; }
        public Hand PlayerHand { get; set; } = new Hand();
        public int PlayerCount => Players.Count;
        public List<Player> Hand { get; set; }
        public bool GameMode { get; set; } = true;

        public void InitialiseGameState( int i )
        {
            GeneratePlayers( i );
            CurrentShoe = new ShoeGenerator().GenerateShoe( 4 );
            CurrentShoe.Shuffle();
        }

        internal void GeneratePlayers( int i )
        {
            for ( var j = 0; j < i; j++ )
            {
                var player = new Player();
                Players.Add( player );
            }
        }

        public Card DealCard( Hand hand )
        {
            var cardFromShoe = CurrentShoe.DealCard();
            hand.AddCard( cardFromShoe );

            return cardFromShoe;
        }

        // ReSharper disable MemberCanBeMadeStatic.Global
        public void DisplayHand( Hand hand )
        {
            string text = hand.Cards
                              .Select( x => x.ToString() ) // goes over the cards and gets a string representation of them and sticks them in a list
                              .Aggregate( ( lhs, rhs ) => $"{lhs}\r\n{rhs}" ); // sticking the hand together, separated by new lines.

            Console.WriteLine( text );
        }

        public void GetUserChoice()
        {
            var key = Console.ReadKey();

            switch ( key.Key )
            {
                case ConsoleKey.H:
                    break;
                case ConsoleKey.S:
                    break;
                case ConsoleKey.D:
                    break;
                case ConsoleKey.P:
                    break;
                case ConsoleKey.Q:
                    Environment.Exit( 0 );
                    break;
                default:
                    Console.WriteLine( "\r\nThat is not a valid choice!" );
                    break;
            }
        }

        public void Hit() { }
        public void Stand() { }
        public void Double() { }
        public void Split() { }
    }
}
