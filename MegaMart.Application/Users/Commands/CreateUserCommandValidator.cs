using FluentValidation;

namespace MegaMart.Application.Users.Commands.CreateUser
{
    internal class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {

            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .MaximumLength(256).WithMessage("Email must not exceed 256 characters.")
            .EmailAddress().WithMessage("Email is not in a valid format.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .MaximumLength(50).WithMessage("Username must not exceed 50 characters.");

            RuleFor(x => x.Password)
           .NotEmpty().WithMessage("Password is required.")
           .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
           .Matches(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")
           .WithMessage("Password must contain at least one letter, one number, and one special character.");

            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword)
                       .WithMessage("Password and Confirm Password do not match.");
        }
    }
}
