
using CQRS_Project.Application.Orders.Queries.GetOrderById;
using MediatR;

namespace CQRS_Project.Application.Orders.Queries.GetOrders
{
    public class GetOrdersQuery : IRequest<List<OrderDetailsDto>>
    {
    }
}
