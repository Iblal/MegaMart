using MegaMart.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MegaMart.Application.Products.Commands.CreateProduct;
using MegaMart.Domain.Enums;
using MegaMart.Domain.Entities;
using MegaMart.Domain.Shared;

namespace MegaMart.Presentation.Controllers
{
    [Route("api/products")]
    public sealed class ProductController : ApiController
    {
        public ProductController(ISender sender)
        : base(sender)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CancellationToken cancellationToken)
        {
            var command = new CreateProductCommand("ProductName2", "ProductDescription2", 87.18, 4, (ProductCategory)Enum.Parse(typeof(ProductCategory), "1"));

            var result = await Sender.Send(command, cancellationToken);

            return result.IsSuccess ? Ok("Product added succesfully.") : HandleFailure(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetProductByIdQuery(id);

            Result<MemberResponse> response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
        }
    }
}
