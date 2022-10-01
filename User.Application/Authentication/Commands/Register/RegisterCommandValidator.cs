using FluentValidation;

namespace User.Application.Authentication.Commands.Register;

public class RegisterCommandValidator: AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.LastName)
            .NotNull()
            .NotEmpty();
        
        RuleFor(x => x.Email)
            .NotNull()
            .NotEmpty()
            .EmailAddress();
        
        RuleFor(x => x.Password)
            .NotNull()
            .NotEmpty()
            /*
             * At least one lower case letter,
             * At least one upper case letter,
             * At least special character,
             * At least one number
             * At least 8 characters length
             */
            .Matches("^.*(?=.{8,})(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$")
            .WithMessage("{PropertyName} must be valid");
    }
}