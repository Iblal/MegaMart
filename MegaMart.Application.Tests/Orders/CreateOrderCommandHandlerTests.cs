using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;
using MegaMart.Application.Orders.Commands.CreateOrder;
using MegaMart.Application.Interfaces;
using MegaMart.Domain.Entities;
using MegaMart.Domain.Repositories;
using static MegaMart.Domain.Errors.DomainErrors;
using System.Security.Claims;
using FluentAssertions;


namespace MegaMart.Application.Tests.Products.Commands
{


    public class CreateOrderCommandHandlerTests
    {
        [Fact]
        public async Task Handle_WithInvalidUser_ReturnsFailureResult()
        {
            // Arrange
            var userManager = new Mock<UserManager<User>>(Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
            userManager.Setup(u => u.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync((User)null);

            var orderRepository = new Mock<IOrderRepository>();
            var productRepository = new Mock<IProductRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var userAccessor = new Mock<IUserAccessor>();

            var request = new CreateOrderCommand("ShippingAddress", new List<OrderItemCommand>
            {

            });

            var handler = new CreateOrderCommandHandler(userAccessor.Object, userManager.Object, orderRepository.Object, productRepository.Object, unitOfWork.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(UserErrors.UserNotFound);
        }
    }

}