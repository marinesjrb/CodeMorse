using System.Collections.Generic;
using CodeMorse.Handler;
using CodeMorse.Model;
using Xunit;

namespace CodeMorse.UnitTests
{
    public class DecodeHandlerTests
    {
        [Theory]
        [InlineData(".- -... -.-.", "ABC")]
        [InlineData(".... . -.--   .--- ..- -.. .", "HEY JUDE")]
        [InlineData(" .... . -.--   .--- ..- -.. . ", "HEY JUDE")]
        [InlineData(".-   .-.. ..- .-   -- .   - .-. .- .. ..-", "A LUA ME TRAIU")]
        [InlineData("AA", "")]
        [InlineData("", "")]
        [InlineData(" ", "")]
        [InlineData("WW .- -... -.-. !!", "ABC")]
        public void Handle_ShouldTranslateMorseCodeToText(string morseCode, string expectedText)
        {
            // Arrange
            IDecodeHandler _handler = new DecodeHandler();

            // Act
            string result = _handler.HandleSingleCode(morseCode);

            // Assert
            Assert.Equal(expectedText, result);
        }

        [Fact]
        public void HandleMultipleCodes_ShouldTranslateMorseCodeToText()
        {
            // Arrange
            IDecodeHandler _handler = new DecodeHandler();

            Request request = new Request
            {
                Codes = new List<string> { ".-", ".-", " .- ", ".... . -.--   .--- ..- -.. ." }
            };

            Response expectedText = new Response
            {
                Texts = new List<string> { "A", "A", "A", "HEY JUDE" }
            };

            // Act
            Response result = _handler.HandleMultipleCodes(request);

            // Assert
            Assert.Equal(expectedText.Texts, result.Texts);
        }
    }
}