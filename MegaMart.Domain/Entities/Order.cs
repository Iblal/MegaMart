using MegaMart.Domain.Primitives;


namespace MegaMart.Domain.Entities
{
    public sealed class Order : Entity
    {
        public Order(Guid id) : base(id)
        {

        }

        public User Customer { get; private set; }

        public string ShippingAddress { get; private set; }

        public decimal Total { get; private set; }

    }
}
