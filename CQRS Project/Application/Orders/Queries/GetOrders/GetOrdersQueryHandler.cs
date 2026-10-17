
using CQRS_Project.Application.Orders.Queries.GetOrderById;
using CQRS_Project.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Project.Application.Orders.Queries.GetOrders
{
    public class GetOrdersQueryHandler
        : IRequestHandler<GetOrdersQuery, List<OrderDetailsDto>>
    {
        private readonly AppDbContext _context;

        public GetOrdersQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderDetailsDto>> Handle(
            GetOrdersQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Orders
                .AsNoTracking()
                .Include(o => o.Items)
                .Select(o => new OrderDetailsDto
                {
                    OrderId = o.Id,
                    TotalAmount = o.TotalAmount,
                    Items = o.Items.Select(item => new OrderItemDetailsDto
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    }).ToList()
                })
                .ToListAsync(cancellationToken);
        }
    }
}
