using MegaMart.Domain.Entities;
using MegaMart.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MegaMart.Persistence.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _context;

        public ProductRepository(DatabaseContext context) => _context = context;
        

        public void Add(Product product) =>
            _context.Set<Product>().Add(product);

        public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _context.Set<Product>()
            .FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
        
    }
}
