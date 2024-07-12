using System.Text;

namespace CodeMorse.Handler;

public class DecodeHandler : IDecodeHandler
{
    public DecodeHandler()
    {
    }

    public string Handle(string morseCode)
    {
        try
        {
            StringBuilder result = new();
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
}