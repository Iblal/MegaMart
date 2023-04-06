using MegaMart.Application.Abstractions.Messaging;

namespace MegaMart.Application.Members.Login;
public record LoginCommand(string Email, string Password) : ICommand;
