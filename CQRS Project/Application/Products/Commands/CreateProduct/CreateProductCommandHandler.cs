
using Microsoft.EntityFrameworkCore;
using CQRS_Project.Domain.Entities;
using CQRS_Project.Infrastructure.Data;
using MediatR;

namespace CQRS_Project.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler
        : IRequestHandler<CreateProductCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateProductCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(
            CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            if (request.CategoryId.HasValue)
            {
                var categoryExists = await _context.Categories
                    .AnyAsync(
                        category => category.Id == request.CategoryId.Value,
                        cancellationToken);

                if (!categoryExists)
                {
                    throw new FluentValidation.ValidationException(
                        new[]

                        {
                             new FluentValidation.Results.ValidationFailure(
                                  "CategoryId",
                                  "The specified category does not exist.")
                        });
                }
            }

            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
                CategoryId = request.CategoryId
            };

            _context.Products.Add(product);

            await _context.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
