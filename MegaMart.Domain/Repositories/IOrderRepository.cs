using MegaMart.Domain.Entities;

namespace MegaMart.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        void Add(Order order);
    }
}
