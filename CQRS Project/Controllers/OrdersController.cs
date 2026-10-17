
using CQRS_Project.Application.Orders.Commands.CreateOrder;
using CQRS_Project.Application.Orders.Queries.GetOrderById;
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
                nameof(GetOrderById),
                new { id = orderId },
                new { orderId });
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _mediator.Send(
                new GetOrderByIdQuery(id));

            if (order == null)
            {
                return NotFound(new
                {
                    message = $"Order with ID {id} was not found."
                });
            }

            return Ok(order);
        }
    }
}
