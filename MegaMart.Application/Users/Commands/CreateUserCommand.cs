using MediatR;
using Microsoft.AspNetCore.Identity;

namespace MegaMart.Application.Users.Commands.CreateUser
{
    public sealed record CreateUserCommand(
        string Email,
        string UserName,
        string Password,
        string ConfirmPassword
        ) : IRequest<IdentityResult>;

}
