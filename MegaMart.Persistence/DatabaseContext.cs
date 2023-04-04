using MegaMart.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MegaMart.Persistence
{
    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
                  : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
