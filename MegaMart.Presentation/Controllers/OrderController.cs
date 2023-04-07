using MediatR;
using MegaMart.Application.Orders.Commands.CreateOrder;
using MegaMart.Application.Users.Commands.CreateUser;
using MegaMart.Domain.Entities;
using MegaMart.Presentation.Abstractions;
using MegaMart.Presentation.Contracts.Order;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request, CancellationToken cancellationToken)
        {
            string? currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier); 

            if (string.IsNullOrEmpty(currentUserId))
            {
                return BadRequest("You need to login before placing an order");
            }

            var orderItems = new List<OrderItem>();

            
            foreach (var item in request.Items)
            {
                var orderItem = new OrderItem(
                    item.ProductId,
                    item.Quantity
                );
                orderItems.Add(orderItem);
            }

            var command = new CreateOrderCommand(
                currentUserId,
                request.ShippingAddress,
                orderItems
            );


            var result = await Sender.Send(command, cancellationToken);

            return result.IsSuccess ? Ok("Product added succesfully.") : HandleFailure(result);
        }
    }
}
