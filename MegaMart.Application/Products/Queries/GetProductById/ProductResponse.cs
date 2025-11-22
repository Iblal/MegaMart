
namespace MegaMart.Application.Products.Queries.GetProductById
{
    public sealed record ProductResponse(Guid Id, string Name, string Description, double Price);
}
