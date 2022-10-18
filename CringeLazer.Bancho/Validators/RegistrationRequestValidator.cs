using CringeLazer.Bancho.Contracts.Requests;
using FluentValidation;

namespace CringeLazer.Bancho.Validators;

public class RegistrationRequestValidator : AbstractValidator<RegistrationRequest>
{
    public RegistrationRequestValidator()
    {
        RuleFor(x => x.Username)
            .MinimumLength(3)
            .Matches("^[a-zA-Z0-9]+$");

        RuleFor(x => x.Password)
            .MinimumLength(6);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
    }
}
