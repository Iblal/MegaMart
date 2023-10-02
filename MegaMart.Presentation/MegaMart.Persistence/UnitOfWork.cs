using MegaMart.Domain.Repositories;

namespace MegaMart.Persistence;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _context;

    public UnitOfWork(DatabaseContext context) =>
        _context = context;

    public Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
          _context.SaveChangesAsync(cancellationToken);
}