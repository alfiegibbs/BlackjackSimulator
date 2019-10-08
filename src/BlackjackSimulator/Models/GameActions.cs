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
        private Hand PlayerHand { get; set; } = new Hand();
        public int PlayerCount => Players.Count;
        public List<Player> Hand { get; set; }
        public bool IsGameCancelled { get; set; }

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

        public void GeneratePlayerHands()
        {
            foreach ( var player in Players )
            {
                player.AddToHand( new Hand() );
                foreach ( var playerHand in player.Hands ) player.AddInitialCardsToHand( playerHand, CurrentShoe );
            }
        }

        private Card DealCard( Hand hand )
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

        public void GetAndInvokePlayerChoice()
        {
            Console.WriteLine( "\r\nPress (h) to hit, (s) to stand, (d) to double, (p) to split, (q) to quit." );
            var key = Console.ReadKey();

            switch ( key.Key )
            {
                case ConsoleKey.H:
                    Hit();
                    break;
                case ConsoleKey.S:
                    Stand();
                    break;
                case ConsoleKey.D:
                    Double();
                    break;
                case ConsoleKey.P:
                    Split();
                    break;
                case ConsoleKey.Q:
                    Environment.Exit( 0 );
                    break;
                default:
                    Console.WriteLine( "\r\nThat is not a valid choice!" );
                    break;
            }
        }

        private void Hit()
        {
            Console.WriteLine( "You chose hit!\r\n" );
            DealCard( PlayerHand );

            // Need to treat CPU player and non cpu player the same.
        }

        private void Stand()
        {
            Console.WriteLine( "You chose stand!\r\n" );
        }

        private void Double()
        {
            Console.WriteLine( "You chose double!\r\n" );
        }

        private void Split()
        {
            Console.WriteLine( "You chose split!\r\n" );
        }

        public void TakeBet()
        {
            foreach ( var player in Players )
            {
                player.TakeBet();
            }
        }

        public void InitialPlayerDeal()
        {
            for ( var i = 0; i < 2; i++ )
            {
                GeneratePlayerHands();
            }
        }
    }
}
