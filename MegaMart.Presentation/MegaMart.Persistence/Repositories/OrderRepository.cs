using MegaMart.Domain.Entities;
using MegaMart.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MegaMart.Persistence.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly DatabaseContext _context;

        public OrderRepository(DatabaseContext context) => _context = context;

        public void Add(Order order) 
        {
            _context.Set<Order>().Add(order);
        }
            

        public async Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _context.Set<Order>()
            .FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
    }
}
