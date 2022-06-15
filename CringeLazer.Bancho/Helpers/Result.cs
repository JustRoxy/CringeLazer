namespace CringeLazer.Bancho.Helpers;

public class Result<T>
{
    public T Value { get; }
    public List<Error> Errors { get; }
    public bool IsError { get; }

    private Result(T value)
    {
        Value = value;
        IsError = false;
    }

    private Result(List<Error> error)
    {
        Errors = error;
        IsError = true;
    }

    public static Result<T> Some(T value)
    {
        return new Result<T>(value);
    }

    public static Result<T> Error(string message, ErrorType type)
    {
        return Error(new Error(message, type));
    }

    public static Result<T> Error(Error error)
    {
        return new Result<T>(new List<Error> {error});
    }

    public static Result<T> Error(List<Error> errors)
    {
        return new Result<T>(errors);
    }
}

public class Error
{
    public Error(string message, ErrorType errorType)
    {
        Message = message;
        ErrorType = errorType;
    }

    public string Message { get; set; }
    public ErrorType ErrorType { get; set; }
}

public enum ErrorType
{
    NotFound,
    BadRequest,
    Conflict
}
