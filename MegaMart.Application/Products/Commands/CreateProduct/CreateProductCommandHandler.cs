using MegaMart.Application.Abstractions.Messaging;
using MegaMart.Domain.Entities;
using MegaMart.Domain.Errors;
using MegaMart.Domain.Repositories;
using MegaMart.Domain.Shared;


namespace MegaMart.Application.Products.Commands.CreateProduct
{
    internal sealed class CreateProductCommandHandler(IProductRepository _productRepository, 
    IUnitOfWork _unitOfWork) : ICommandHandler<CreateProductCommand>
    {
        public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (await _productRepository.CheckProductNameExistsAsync(request.Name))
            {
                return Result.Failure(DomainErrors.ProductErrors.NameExists);
            }

            var product = Product.Create(
                Guid.NewGuid(),
                request.Name,
                request.Description,
                request.Price,
                request.Quantity,
                request.Category);
                
            _productRepository.Add(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
