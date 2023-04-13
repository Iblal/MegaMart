using MegaMart.Application.Abstractions.Messaging;
using MegaMart.Domain.Entities;
using MegaMart.Domain.Errors;
using MegaMart.Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace MegaMart.Application.Members.Login
{
    internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public LoginCommandHandler(
            SignInManager<User> signInManager,
            UserManager<User> userManager
        )
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<Result> Handle(LoginCommand command, CancellationToken cancellationToken)
        {

            User? user = await _userManager.FindByEmailAsync(command.Email);

            if (user is null) 
            {
                return Result.Failure<string>(DomainErrors.UserErrors.InvalidCredentials);
            }

            // Use SignInManager to authenticate user
            var signInResult = await _signInManager.PasswordSignInAsync(user, command.Password, isPersistent: true, lockoutOnFailure: false);
            if (!signInResult.Succeeded)
            {
                // Handle failed login attempt, return error response
                return Result.Failure<string>(DomainErrors.UserErrors.InvalidCredentials);
            }

            // Return success with user email
            return Result.Success("Login succesful");
        }
    }
}

