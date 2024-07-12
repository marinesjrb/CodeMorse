namespace CodeMorse.Handler;

public interface IDecodeHandler
{
    public string Handle(string morseCode);
}