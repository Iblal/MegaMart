namespace MegaMart.Presentation.Contracts.Order
{
    public sealed record CreateOrderRequest(
        string ShippingAddress,
        List<OrderItemRequest> Items
    );

    public sealed record OrderItemRequest(
    Guid ProductId,
    int Quantity
    );

}
