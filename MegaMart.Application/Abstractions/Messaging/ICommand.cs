using MegaMart.Domain.Shared;
using MediatR;

namespace MegaMart.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
