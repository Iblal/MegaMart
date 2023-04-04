using MegaMart.Domain.Enums;
using MegaMart.Domain.Primitives;


namespace MegaMart.Domain.Entities
{
    public sealed class Product : Entity
    {
        private Product(Guid id, string name, string description, double price, int quantity, ProductCategory category)
        : base(id)
        {
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            Category = category;
        }

        public string Name { get; private set; }

        public ProductCategory Category { get; private set; }

        public string Description { get; private set; }

        public int Quantity { get; private set; }

        public double Price { get; private set; }

        public static Product Create(
            Guid id, string name, 
            string description, 
            double price, 
            int quantity, 
            ProductCategory category
            )
        {
            var product = new Product(
                Guid.NewGuid(),
                name,
                description,
                price, 
                quantity, 
                category
                );

            return product;
        }
    }
}
