using Gatherly.Application.Members.Login;
using MediatR;
using MegaMart.Application.Members.Login;
using MegaMart.Application.Users.Commands.CreateUser;
using MegaMart.Presentation.Abstractions;
using MegaMart.Presentation.Contracts.Account;
using Microsoft.AspNetCore.Mvc;

namespace MegaMart.Presentation.Controllers
{
    [Route("api/account")]
    public sealed class AccountController : ApiController
    {
        public AccountController(ISender sender)
        : base(sender)
        {
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginMember(
        [FromBody] LoginRequest request,
        CancellationToken cancellationToken)
        {
            var command = new LoginCommand(request.Email, request.Password);

            var result = await Sender.Send(
                command,
                cancellationToken);


            return result.IsSuccess ? Ok("Login succesful.") : HandleFailure(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request,
        CancellationToken cancellationToken)
        {
            var command = new CreateUserCommand(
            request.Email,
            request.Username,
            request.Password,
            request.ConfirmPassword);

            var result = await Sender.Send(command);

            return result.Succeeded ? Ok("Registration succesful.") : BadRequest(result.Errors);
        }
    }

}

