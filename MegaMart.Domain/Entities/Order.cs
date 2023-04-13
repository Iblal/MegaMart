using MegaMart.Domain.Primitives;

namespace MegaMart.Domain.Entities
{
    public sealed class Order : Entity
    {
        private readonly List<OrderItem> _orderItems = new();

        private Order(Guid id, User customer, string shippingAddress, DateTime createdDate)
            : base(id)
        {
            Customer = customer;
            ShippingAddress = shippingAddress;
            CreatedDate = createdDate;  
        }

        private Order()
            : base(Guid.NewGuid())
        {
        }

        public User Customer { get; private set; }

        public string ShippingAddress { get; private set; }

        public double Total { get; private set; }

        public DateTime CreatedDate { get; private set; }

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;


        public static Order Create(
            User customer,
            string shippingAddress
            )
        {
            var order = new Order(
                Guid.NewGuid(),
                customer,
                shippingAddress,
                DateTime.Now
                );

            return order;
        }


        public void AddOrderItem(Product product, int quantity)
        {
            
           var orderItem = OrderItem.Create(product, quantity);
           _orderItems.Add(orderItem);
        }

        public void CalculateTotalAmount()
        {
            Total = OrderItems.Sum(product => product.Subtotal);
        }

    }
}
