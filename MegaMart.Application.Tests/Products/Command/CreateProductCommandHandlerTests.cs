using FluentAssertions;
using MegaMart.Application.Products.Commands.CreateProduct;
using MegaMart.Domain.Entities;
using MegaMart.Domain.Errors;
using MegaMart.Domain.Repositories;
using MegaMart.Domain.Shared;
using MegaMart.Domain.Enums;
using Moq;
using Xunit;

namespace MegaMart.Application.UnitTests.Members.Commands;

public class CreateProductCommandHandlerTests
{
    private readonly Mock<IProductRepository> _productRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;

    public CreateProductCommandHandlerTests()
    {
        _productRepositoryMock = new();
        _unitOfWorkMock = new();
    }

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_WhenProductNameIsNotUnique()
    {
        // Arrange
        var command = new CreateProductCommand(
            "productName", "productDescription", 1.55, 4, (ProductCategory)Enum.Parse(typeof(ProductCategory), "1"));

        _productRepositoryMock.Setup(
                x => x.CheckProductNameExistsAsync(command.Name))
            .ReturnsAsync(true);

        var handler = new CreateProductCommandHandler(
            _productRepositoryMock.Object,
            _unitOfWorkMock.Object);

        // Act
        Result result = await handler.Handle(command, default);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Product.ProductNameExists);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_WhenProductNameIsUnique()
    {
        // Arrange
        var command = new CreateProductCommand(
            "productName", "productDescription", 1.55, 4, (ProductCategory)Enum.Parse(typeof(ProductCategory), "1"));

        _productRepositoryMock.Setup(
                x => x.CheckProductNameExistsAsync(command.Name))
            .ReturnsAsync(false);

        var handler = new CreateProductCommandHandler(
            _productRepositoryMock.Object,
            _unitOfWorkMock.Object);

        // Act
        Result result = await handler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Handle_Should_CallAddOnRepository_WhenProductNameIsUnique()
    {
        // Arrange
        var command = new CreateProductCommand(
            "productName", "productDescription", 1.55, 4, (ProductCategory)Enum.Parse(typeof(ProductCategory), "1"));

        _productRepositoryMock.Setup(
                x => x.CheckProductNameExistsAsync(command.Name))
            .ReturnsAsync(false);

        var handler = new CreateProductCommandHandler(
            _productRepositoryMock.Object,
            _unitOfWorkMock.Object);

        // Act
        Result result = await handler.Handle(command, default);

        // Assert
        _productRepositoryMock.Verify(
            x => x.Add(It.IsAny<Product>()),
            Times.Once);
    }

    [Fact]
    public async Task Handle_Should_NotCallUnitOfWork_WhenProductIsNotUnique()
    {
        // Arrange
        var command = new CreateProductCommand(
            "productName", "productDescription", 1.55, 4, (ProductCategory)Enum.Parse(typeof(ProductCategory), "1"));

        _productRepositoryMock.Setup(
                x => x.CheckProductNameExistsAsync(command.Name))
            .ReturnsAsync(true);

        var handler = new CreateProductCommandHandler(
            _productRepositoryMock.Object,
            _unitOfWorkMock.Object);

        // Act
        Result result = await handler.Handle(command, default);

        // Assert
        _unitOfWorkMock.Verify(
            x => x.SaveChangesAsync(It.IsAny<CancellationToken>()),
            Times.Never);
    }
}
