namespace BlackjackSimulator.Test
{
    using System;
    using BlackjackSimulator.Deck;
    using BlackjackSimulator.Models;
    using Shouldly;
    using Xunit;

    public class ASCIITests
    {
        [ Fact ]
        public void ShouldGenerateAceCard()
        {
            var generator = new ASCIICardGenerator();
            var card = new Card();

            var generatedAscii = generator.GenerateTextForCard( card );
            generatedAscii.ShouldBe( @" -------------
|A♣           |
|   -------   |
|  |       |  |
|  |       |  |
|  |       |  |
|  |   ♣   |  |
|  |       |  |
|  |       |  |
|  |       |  |
|   -------   |
|           ♣A|
 -------------" );
        }

        [ Fact ]
        public void ShouldMakeHandInline()
        {
            
        }
    }
}
