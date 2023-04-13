using FluentValidation;
using MegaMart.Domain.Entities;

namespace MegaMart.Application.Orders.Commands.CreateOrder
{
    internal class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {

            RuleFor(x => x.ShippingAddress).NotEmpty().MaximumLength(100);

            RuleForEach(x => x.OrderItems)
            .SetValidator(new OrderItemValidator());
        }
    }

    public class OrderItemValidator : AbstractValidator<OrderItemCommand>
    {
        public OrderItemValidator()
        {
            RuleFor(x => x.productId)
                .NotEmpty()
                .WithMessage("Product ID is required.");

            RuleFor(x => x.Quantity)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than 0.");
        }
    }
}
