using MegaMart.Application.Abstractions.Messaging;
using MegaMart.Domain.Shared;

namespace MegaMart.Application.Orders.Commands.CreateOrder
{
    internal sealed class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
    {
        public Task<Result> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
