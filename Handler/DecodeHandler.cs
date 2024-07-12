using CodeMorse.Model;
using CodeMorse.Utils;
using System.Text;

namespace CodeMorse.Handler;

public class DecodeHandler : IDecodeHandler
{
    public Response Handle(string morseCode)
    {
        try
        {
            Response response = new Response();
            StringBuilder result = new StringBuilder();

            string[] words = morseCode.Split(new[] { "   " }, StringSplitOptions.RemoveEmptyEntries);

            var morseCodeToChar = StringUtils.MorseToChar();

            foreach (string word in words)
            {
                string[] letters = word.Split(' ');

                foreach (string letter in letters)
                {
                    if (morseCodeToChar.TryGetValue(letter, out char character))
                    {
                        result.Append(character);
                    }
                    else
                    {
                        result.Append("");
                    }
                }
                result.Append(" ");
            }

            response.TextTranslation = result.ToString().Trim();
            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Something went wrong. Exception: {ex.Message}");
            throw new Exception();
        }
    }
}