
using MediatR;

namespace CQRS_Project.Application.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrderDetailsDto?>
    {
        public int Id { get; set; }

        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class OrderDetailsDto
    {
        public int OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItemDetailsDto> Items { get; set; } = new();
    }

    public class OrderItemDetailsDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
