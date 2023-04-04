using MegaMart.Domain.Shared;
using MediatR;

namespace MegaMart.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}