using MegaMart.Domain.Primitives;

namespace MegaMart.Domain.DomainEvents;

public sealed record OrderCreatedDomainEvent(Guid InvitationId, Guid GatheringId) : IDomainEvent
{
}