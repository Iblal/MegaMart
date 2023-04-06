using FluentAssertions;
using MegaMart.Application.Products.Queries.GetProductById;
using MegaMart.Domain.Entities;
using MegaMart.Domain.Enums;
using MegaMart.Domain.Repositories;
using MegaMart.Domain.Shared;
using Moq;
using Xunit;

namespace MegaMart.Application.Tests.Products.Queries
{
    public class GetProductByIdQueryTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;

        public GetProductByIdQueryTests()
        {
            _productRepositoryMock = new();
        }

        [Fact]
        public async Task Handle_Should_ReturnFailureResult_WhenProductIdIsNotFound()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var token = CancellationToken.None;

            var query = new GetProductByIdQuery(productId);


            _productRepositoryMock.Setup(
                    x => x.GetByIdAsync(query.ProductId, token)).ReturnsAsync(() => null);

            var handler = new GetProductByIdQueryHandler(
                _productRepositoryMock.Object);

            // Act
            Result result = await handler.Handle(query, default);

            // Assert
            result.IsFailure.Should().BeTrue();
        }

        [Fact]
        public async Task Handle_Should_ReturnSuccessResult_WhenProductIdIsFound()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var token = CancellationToken.None;

            var product = Product.Create(productId, "Name", "Description", 3.14, 6, (ProductCategory)Enum.Parse(typeof(ProductCategory), "1"));

            var query = new GetProductByIdQuery(productId);

            _productRepositoryMock.Setup(
                    x => x.GetByIdAsync(query.ProductId, token)).ReturnsAsync(() => product);

            var handler = new GetProductByIdQueryHandler(
                _productRepositoryMock.Object);

            // Act
            Result result = await handler.Handle(query, default);

            // Assert
            result.IsSuccess.Should().BeTrue();
        }
    }
}
