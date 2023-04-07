using MegaMart.Domain.Primitives;
using Microsoft.EntityFrameworkCore.Metadata;


namespace MegaMart.Domain.Entities
{
    public sealed class Order : Entity
    {
        private readonly List<OrderItemQuantity> _orderItemQuantity = new();

        private Order(Guid id) 
            : base(id)
        {

        }

        public User Customer { get; private set; }

        public string ShippingAddress { get; private set; }

        public decimal Total { get; private set; }

        public IReadOnlyCollection<OrderItemQuantity> OrderItemQuantity => _orderItemQuantity;

    }
}
