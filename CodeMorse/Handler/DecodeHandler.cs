using CodeMorse.Model;
using CodeMorse.Utils;
using System.Text;

namespace CodeMorse.Handler;

public class DecodeHandler : IDecodeHandler
{
    public string HandleSingleCode(string morseCode)
    {
        try
        {
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

            return result.ToString().Trim();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Something went wrong. Exception: {ex.Message}");
            throw new Exception();
        }
    }

    public Response HandleMultipleCodes(Request request)
    {
        try
        {
            Response response = new Response
            {
                Texts = new List<string>()
            };

            foreach (string code in request.Codes)
            {
                string translatedText = HandleSingleCode(code);

                response.Texts.Add(translatedText);
            }

            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Something went wrong. Exception: {ex.Message}");
            throw new Exception();
        }
    }
}