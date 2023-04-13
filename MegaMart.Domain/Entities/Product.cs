using MegaMart.Domain.Enums;
using MegaMart.Domain.Primitives;


namespace MegaMart.Domain.Entities
{
    public sealed class Product : Entity
    {
        private Product(Guid id, string name, string description,
            double price, int stock, ProductCategory category, DateTime createdDateTime)
        : base(id)
        {
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Category = category;
            CreatedDate = createdDateTime;
        }

        private Product()
        : base(Guid.NewGuid())
        {
        }

        public string Name { get; private set; }

        public ProductCategory Category { get; private set; }

        public string Description { get; private set; }

        public int Stock { get; private set; }

        public double Price { get; private set; }

        public DateTime CreatedDate { get; private set; }


        public static Product Create(
            Guid id, string name, 
            string description, 
            double price, 
            int stock, 
            ProductCategory category
            )
        {
            var product = new Product(
                Guid.NewGuid(),
                name,
                description,
                price, 
                stock, 
                category,
                DateTime.Now
                );

            return product;
        }

        public void UpdateStock(int quantity)
        {
            Stock -= quantity;
        }
    }
}
