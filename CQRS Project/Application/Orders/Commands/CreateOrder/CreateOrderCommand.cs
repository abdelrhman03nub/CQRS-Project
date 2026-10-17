
using MediatR;


namespace CQRS_Project.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public List<CreateOrderItemDto> Items { get; set; }
            = new List<CreateOrderItemDto>();
    }

    public class CreateOrderItemDto
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}