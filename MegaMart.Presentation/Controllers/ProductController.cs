using MegaMart.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MegaMart.Application.Products.Commands.CreateProduct;
using System.Drawing;
using MegaMart.Domain.Enums;

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
            var command = new CreateProductCommand("ProductName2", "ProductDescription2", 87.18, 4, (ProductCategory)Enum.Parse(typeof(ProductCategory), "0"));

            var result = await Sender.Send(command, cancellationToken);

            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }
    }
}
