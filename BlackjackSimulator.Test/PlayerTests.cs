namespace BlackjackSimulator.Test
{
    using BlackjackSimulator.Models;
    using Shouldly;
    using Xunit;

    public class PlayerTests
    {
        [ Theory ]
        [ InlineData( 5 ) ]
        [ InlineData( 10 ) ]
        public void ShouldGeneratePlayers( int i )
        {
            var gameAction = new GameActions();
            gameAction.GeneratePlayers( i );
            gameAction.PlayerCount.ShouldBe( i );
        }
    }
}
