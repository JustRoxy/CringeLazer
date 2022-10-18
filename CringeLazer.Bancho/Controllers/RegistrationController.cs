using CringeLazer.Bancho.Contracts.Requests;
using CringeLazer.Bancho.Contracts.Responses;
using CringeLazer.Bancho.Extensions;
using CringeLazer.Core.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CringeLazer.Bancho.Controllers;

[ApiController]
[Route("users")]
public class RegistrationController : ControllerBase
{
    private readonly IValidator<RegistrationRequest> _registrationValidator;
    private readonly IUserService _userService;

    public RegistrationController(IValidator<RegistrationRequest> registrationValidator, IUserService userService)
    {
        _registrationValidator = registrationValidator;
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegistrationRequest request)
    {
        var validationResult = await _registrationValidator.ValidateAsync(request);
        if (validationResult.IsValid)
        {
            var result = await _userService.Create(request.Username, request.Email, request.Password);
            return result.ToResult();
        }

        return BadRequest(new RegistrationErrorResponse()
        {
            FormErrors = new RegistrationErrors()
            {
                Username = validationResult.Errors.Where(x => x.PropertyName == "Username").Select(x => x.ErrorMessage).ToArray(),
                Email = validationResult.Errors.Where(x => x.PropertyName == "Email").Select(x => x.ErrorMessage).ToArray(),
                Password = validationResult.Errors.Where(x => x.PropertyName == "Password").Select(x => x.ErrorMessage).ToArray()
            }
        });
    }
}
