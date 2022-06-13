using FluentValidation;

namespace CringeLazer.Bancho._Features_.Auth.User.Register;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8);

        RuleFor(x => x.Username)
            .NotEmpty()
            .MinimumLength(4);
    }
}
