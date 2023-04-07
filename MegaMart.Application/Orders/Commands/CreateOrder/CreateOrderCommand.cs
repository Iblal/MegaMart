using MegaMart.Application.Abstractions.Messaging;


namespace MegaMart.Application.Orders.Commands.CreateOrder
{
    public sealed record CreateOrderCommand(
        string currentUserId,
        string ShippingAddress,
        List<OrderItem> Items
    ) : ICommand;

    public sealed record OrderItem(
    Guid ProductId,
    int Quantity
    );

}
