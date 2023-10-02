using MediatR;
using MegaMart.Domain.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMart.Application.Events
{
    internal sealed class OrderCreatedDomainEventHandler
        : INotificationHandler<OrderCreatedDomainEvent>
    {
        public async Task Handle(OrderCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
