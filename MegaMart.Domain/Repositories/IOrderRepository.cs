using MegaMart.Domain.Entities;

namespace MegaMart.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<Order?>> GetCustomerOrder(Guid id);

        void Add(Order order);
    }
}
