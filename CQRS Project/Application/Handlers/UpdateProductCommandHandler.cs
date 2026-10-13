
using CQRS_Project.Application.Commands;
using CQRS_Project.Domain.Entities;
using CQRS_Project.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Project.Application.Handlers
{
    public class UpdateProductCommandHandler
        : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly AppDbContext _context;

        public UpdateProductCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(
            UpdateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(
                    p => p.Id == request.Id,
                    cancellationToken);

            if (product == null)
            {
                return false;
            }

            product.Name = request.Name;
            product.Price = request.Price;
            product.Stock = request.Stock;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
