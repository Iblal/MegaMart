using MegaMart.Domain.Entities;

namespace MegaMart.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        void Add(Product product);
    }
}
