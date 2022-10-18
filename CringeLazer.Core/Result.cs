namespace CringeLazer.Core;

public class Result<T>
{
    public string Message { get; }
    public int StatusCode { get; }
    public bool IsError { get; }
    public T Value { get; }

    public Result(string message, int statusCode)
    {
        Message = message;
        StatusCode = statusCode;
        IsError = true;
    }

    public Result(T value)
    {
        Value = value;
        IsError = false;
    }

    public TResult Match<TResult>(Func<T, TResult> ok, Func<Result<T>, TResult> fault)
    {
        if (IsError)
        {
            return fault(this);
        }

        return ok(Value);
    }

    public async Task<Result<TResult>> MapAsync<TResult>(Func<T, Task<TResult>> map)
    {
        if (IsError)
        {
            return new Result<TResult>(Message, StatusCode);
        }

        return new Result<TResult>(await map(Value));
    }

    public Result<TResult> Map<TResult>(Func<T, TResult> map)
    {
        if (IsError)
        {
            return new Result<TResult>(Message, StatusCode);
        }

        return new Result<TResult>(map(Value));
    }
}
