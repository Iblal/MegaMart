using MediatR;
using MegaMart.Application.Interfaces;
using MegaMart.Application.Orders.Commands.CreateOrder;
using MegaMart.Domain.Entities;
using MegaMart.Domain.Errors;
using MegaMart.Domain.Shared;
using MegaMart.Presentation.Abstractions;
using MegaMart.Presentation.Contracts.Order;
using Microsoft.AspNetCore.Identity;
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
