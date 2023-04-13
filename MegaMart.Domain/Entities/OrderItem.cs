using MegaMart.Domain.Primitives;


namespace MegaMart.Domain.Entities
{
    public sealed class OrderItem : Entity
    {
        private OrderItem(Guid id, Product product, int quantity) 
            : base(id) 
        {
            Product = product;
            Quantity = quantity;
        }

        private OrderItem() 
            : base(Guid.NewGuid())
        {

        }

        public Product Product { get; private set; }

        public int Quantity { get; set; }

        public double Subtotal => Product.Price * Quantity;


        public static OrderItem Create(
        Product product,
        int quantity)
        {
            var orderItem = new OrderItem(
                Guid.NewGuid(),
                product,
                quantity
                );

            return orderItem;
        }

    }
}
