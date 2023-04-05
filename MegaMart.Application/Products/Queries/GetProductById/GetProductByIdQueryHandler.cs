using MegaMart.Application.Abstractions.Messaging;
using MegaMart.Domain.Repositories;
using MegaMart.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMart.Application.Products.Queries.GetProductById
{
    internal sealed class GetProductByIdQueryHandler
        : IQueryHandler<GetProductByIdQuery, ProductResponse>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<ProductResponse>> Handle(
            GetProductByIdQuery request,
            CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(
                request.ProductId,
                cancellationToken);

            if (product is null)
            {
                return Result.Failure<ProductResponse>(new Error(
                    "Product.NotFound",
                    $"The product with Id {request.ProductId} was not found"));
            }

            var response = new ProductResponse(product.Id, product.Name, product.Description, product.Price);

            return response;
        }
    }
}
