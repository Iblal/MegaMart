using MegaMart.Application.Abstractions.Messaging;
using MegaMart.Application.Interfaces;
using MegaMart.Domain.Entities;
using MegaMart.Domain.Repositories;
using MegaMart.Domain.Shared;
using Microsoft.AspNetCore.Identity;
using static MegaMart.Domain.Errors.DomainErrors;

namespace MegaMart.Application.Orders.Commands.CreateOrder
{
    internal sealed class CreateOrderCommandHandler(IUserAccessor _userAccessor, 
    UserManager<User> _userManager, 
    IProductRepository _productRepository, 
    IOrderRepository _orderRepository,
    IUnitOfWork _unitOfWork) : ICommandHandler<CreateOrderCommand>
    {
        
        public async Task<Result> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            User? customer = await _userManager.GetUserAsync(_userAccessor.User);

            if (customer == null)
            {
                return Result.Failure(UserErrors.UserNotFound);
            }

            Order order = Order.Create(customer, request.ShippingAddress);


            foreach (var orderItem in request.OrderItems)
            {
                Product? product = await _productRepository.GetByIdAsync(orderItem.productId);

                if (product is null)
                {
                    return Result.Failure(ProductErrors.DoesNotExist);
                }

                if (product.Stock < orderItem.Quantity)
                {
                    return Result.Failure(ProductErrors.InsufficientStock);
                }

                order.AddOrderItem(product, orderItem.Quantity);
            }

            order.CalculateTotalAmount();


            foreach(var item in order.OrderItems)
            {
                item.Product.UpdateStock(item.Quantity);
            }

            _orderRepository.Add(order);

            await _unitOfWork.SaveChangesAsync();

            //Send email

            return Result.Success();
        }

    }

}

