using CQRS_Project.Application.Orders.Commands.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(
            CreateOrderCommand command)
        {
            var orderId = await _mediator.Send(command);

            return CreatedAtAction(
                nameof(CreateOrder),
                new { id = orderId },
                new { orderId });
        }
    }
}