using CringeLazer.Bancho.Contracts;
using CringeLazer.Core;
using Microsoft.AspNetCore.Mvc;

namespace CringeLazer.Bancho.Extensions;

public static class ResultExtensions
{
    public static IActionResult ToResult<T>(this Result<T> result)
    {
        if (!result.IsError)
        {
            return new OkObjectResult(result.Value);
        }

        return new ObjectResult(new GenericErrorResponse
        {
            Error = result.Message
        });
    }
}
