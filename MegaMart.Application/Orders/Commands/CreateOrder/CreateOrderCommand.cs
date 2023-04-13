using MegaMart.Application.Abstractions.Messaging;


namespace MegaMart.Application.Orders.Commands.CreateOrder
{
    public sealed record CreateOrderCommand(
        string ShippingAddress,
        List<OrderItemCommand> OrderItems
    ) : ICommand;

    public sealed record OrderItemCommand(
        Guid productId,
        int Quantity); 

}
