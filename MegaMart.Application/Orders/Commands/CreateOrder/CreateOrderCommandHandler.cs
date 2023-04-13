using MegaMart.Application.Abstractions.Messaging;
using MegaMart.Application.Interfaces;
using MegaMart.Domain.Entities;
using MegaMart.Domain.Repositories;
using MegaMart.Domain.Shared;
using Microsoft.AspNetCore.Identity;
using static MegaMart.Domain.Errors.DomainErrors;

namespace MegaMart.Application.Orders.Commands.CreateOrder
{
    internal sealed class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
    {
        private readonly IUserAccessor _userAccessor;
        private readonly UserManager<User> _userManager;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommandHandler(IUserAccessor userAccessor, UserManager<User> userManager, IOrderRepository orderRepository,
            IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _userAccessor = userAccessor;
            _userManager = userManager;

        }

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

            return Result.Success();
        }

    }

}

