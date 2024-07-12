using CodeMorse.Model;

namespace CodeMorse.Handler;

public interface IDecodeHandler
{
    public string HandleSingleCode(string morseCode);
    public Response HandleMultipleCodes(Request request);
}