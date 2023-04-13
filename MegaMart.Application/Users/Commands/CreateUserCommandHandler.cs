using MediatR;
using MegaMart.Domain.Entities;
using MegaMart.Domain.Errors;
using Microsoft.AspNetCore.Identity;

namespace MegaMart.Application.Users.Commands.CreateUser
{
    internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IdentityResult>
    {
        private readonly UserManager<User> _userManager;
        private readonly PasswordHasher<User> _passwordHasher;

        public CreateUserCommandHandler(UserManager<User> userManager, PasswordHasher<User> passwordHasher)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }

        public async Task<IdentityResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User? userExists = await _userManager.FindByEmailAsync(request.Email);

            if (userExists is not null)
            {
                return IdentityResult.Failed(DomainErrors.UserErrors.EmailAlreadyRegistered);
            }

            var user = User.Create(request.Email, request.UserName, request.Password);

            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

            var result = await _userManager.CreateAsync(user);

            return result;
        }
    }
}
