
using CQRS_Project.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Project.Application.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler
        : IRequestHandler<GetOrderByIdQuery, OrderDetailsDto?>
    {
        private readonly AppDbContext _context;

        public GetOrderByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<OrderDetailsDto?> Handle(
            GetOrderByIdQuery request,
            CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(
                    o => o.Id == request.Id,
                    cancellationToken);

            if (order == null)
            {
                return null;
            }

            return new OrderDetailsDto
            {
                OrderId = order.Id,
                TotalAmount = order.TotalAmount,
                Items = order.Items.Select(item => new OrderItemDetailsDto
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                }).ToList()
            };
        }
    }
}
