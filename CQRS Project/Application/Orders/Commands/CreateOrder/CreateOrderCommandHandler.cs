
using CQRS_Project.Domain.Entities;
using CQRS_Project.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.Results;

namespace CQRS_Project.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler
        : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateOrderCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(
            CreateOrderCommand request,
            CancellationToken cancellationToken)
        {
            // Check that the order contains at least one item
            if (request.Items == null || !request.Items.Any())
            {
                throw new ValidationException(
                    "Order must contain at least one item.");
            }

            // Validate all order items before creating the order
            foreach (var item in request.Items)
            {
                if (item.Quantity <= 0)
                {
                    throw new ValidationException(
                        "Quantity must be greater than zero.");
                }

                var product = await _context.Products
                    .FirstOrDefaultAsync(
                        p => p.Id == item.ProductId,
                        cancellationToken);

                if (product == null)
                {
                    throw new ValidationException(
                        $"Product with ID {item.ProductId} does not exist.");
                }

                // Check available stock
                if (product.Stock < item.Quantity)
                {
                    var errors = new List<ValidationFailure>
                    {
                        new ValidationFailure(
                            "Quantity",
                            $"Not enough stock. Available: {product.Stock}")
                    };

                    throw new ValidationException(errors);
                }
            }

            // Create the order
            var order = new Order();

            foreach (var item in request.Items)
            {
                var product = await _context.Products
                    .FirstAsync(
                        p => p.Id == item.ProductId,
                        cancellationToken);

                var orderItem = new OrderItem
                {
                    ProductId = product.Id,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                };

                order.Items.Add(orderItem);

                order.TotalAmount += product.Price * item.Quantity;

                // Decrease stock
                product.Stock -= item.Quantity;
            }

            // Save order and update product stock
            _context.Orders.Add(order);

            await _context.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
