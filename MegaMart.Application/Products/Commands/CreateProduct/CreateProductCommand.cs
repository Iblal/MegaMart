using MegaMart.Application.Abstractions.Messaging;
using MegaMart.Domain.Enums;


namespace MegaMart.Application.Products.Commands.CreateProduct
{
    public sealed record CreateProductCommand(
        string Name,
        string Description,
        double Price,
        int Quantity,
        ProductCategory Category
        ) : ICommand;
}
