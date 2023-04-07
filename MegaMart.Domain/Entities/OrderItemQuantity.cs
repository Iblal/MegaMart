using MegaMart.Domain.Primitives;


namespace MegaMart.Domain.Entities
{
    public sealed class OrderItemQuantity : Entity
    {
        private OrderItemQuantity(Guid id) 
            : base(id) 
        { 
                    
        }

        public Product Product { get; private set; }

        public int Quantity { get; private set; }

        public Order Order { get; private set; }

    }
}
