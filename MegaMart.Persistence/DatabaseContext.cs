﻿using MediatR;
using MegaMart.Domain.Entities;
using MegaMart.Domain.Primitives;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MegaMart.Persistence
{
    public sealed class DatabaseContext : IdentityDbContext<User>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
                  : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderItem> OrderItemQuantity { get; set; }

    }
}
