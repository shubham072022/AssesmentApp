using FluentValidation;
using Todo.Application.Features.Authentication.Commands.LoginCommand;

namespace Todo.Application.Validation.Authentication
{
    public class LoginCommandValidator : AbstractValidator<LoginCommandRequest>
    {
        public LoginCommandValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Please enter proper email address");
            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password must be atleast 8 characters long");
        }
    }
}
