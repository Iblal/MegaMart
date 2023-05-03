using MediatR;
using MegaMart.Application.Orders.Commands.CreateOrder;
using MegaMart.Presentation.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MegaMart.Presentation.Controllers
{
    [Route("api/order")]

    public sealed class OrderController : ApiController
    {

        public OrderController(ISender sender) 
            : base(sender)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            var result = await Sender.Send(request, cancellationToken);

            return result.IsSuccess ? Ok("Order created successfully.") : HandleFailure(result);
        }

    }
}
