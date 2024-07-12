using CodeMorse.Model;

namespace CodeMorse.Handler;

public interface IDecodeHandler
{
    public Response Handle(string morseCode);
}