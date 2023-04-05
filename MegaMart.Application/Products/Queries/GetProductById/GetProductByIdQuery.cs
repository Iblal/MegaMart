using MegaMart.Application.Abstractions.Messaging;

namespace MegaMart.Application.Products.Queries.GetProductById
{
    public sealed record GetProductByIdQuery(Guid ProductId) : IQuery<ProductResponse>;
}
