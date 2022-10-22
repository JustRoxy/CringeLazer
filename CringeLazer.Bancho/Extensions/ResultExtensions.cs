using CringeLazer.Bancho.Contracts;
using CringeLazer.Core.Exceptions;
using LanguageExt;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;

namespace CringeLazer.Bancho.Extensions;

public static class ResultExtensions
{
    public static Result<Unit> Drop<T>(this Result<T> result)
    {
        return result.Map(_ => Unit.Default);
    }

    public static IActionResult ToResult<T>(this Result<T> result)
    {
        return result.Match<IActionResult>(
            x =>
            {
                if (typeof(T) == typeof(Unit))
                {
                    return new OkResult();
                }

                return new OkObjectResult(x);
            },
            x =>
            {
                var statusCode = 500;
                if (x is StatusCodeException sce)
                {
                    statusCode = sce.StatusCode;
                }

                var error = new GenericErrorResponse
                {
                    Error = x.Message
                };

                return new ObjectResult(error)
                {
                    StatusCode = statusCode
                };
            });
    }
}
