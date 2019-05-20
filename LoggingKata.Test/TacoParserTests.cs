using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything
        }

        [Theory]
        [InlineData("34.073638,-84.677017,Taco Bell Acwort... (Free trial * Add to Cart for a full POI info)")]
        [InlineData("0,0,Taco Test")]
        [InlineData("90,90,Taco Test")]
        [InlineData("-90,-90,Taco Test")]
        [InlineData("-90,90,Taco Test")]
        public void ShouldParse(string str)
        {
            // Arrange
            TacoParser tacoParser = new TacoParser();

            // Act
            ITrackable actual = tacoParser.Parse(str);

            // Assert
            Assert.NotNull(actual);
            Assert.NotNull(actual.Location);
            Assert.NotNull(actual.Name);
            Assert.True(actual.Name.Length > 0);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("0,abc,TacoBell")]
        [InlineData("abc,abc,TacoBell")]
        [InlineData("0,0")]
        [InlineData("abc,0,TacoBell")]
        [InlineData("0,abc,TacoBell")]
        [InlineData("")]
        public void ShouldFailParse(string str)
        {
            // Arrange
            TacoParser tacoParser = new TacoParser();

            // Act
            ITrackable actual = tacoParser.Parse(str);


            // Assert
            Assert.Null(actual);
            
        }
    }
}
