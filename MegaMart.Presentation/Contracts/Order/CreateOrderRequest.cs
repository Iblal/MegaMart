namespace MegaMart.Presentation.Contracts.Order
{
    public sealed record CreateOrderRequest(
        string ShippingAddress,
        List<OrderItemRequest> OrderItems
    );

    public sealed record OrderItemRequest(
    Guid productId,
    int quantity);

}
