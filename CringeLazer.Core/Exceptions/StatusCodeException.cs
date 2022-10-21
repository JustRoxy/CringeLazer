namespace CringeLazer.Core.Exceptions;

public class StatusCodeException : Exception
{
    public StatusCodeException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }

    public int StatusCode { get; set; }
}
