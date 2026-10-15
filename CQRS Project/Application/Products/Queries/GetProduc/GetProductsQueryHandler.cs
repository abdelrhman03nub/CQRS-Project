using CQRS_Project.Application.DTOs;
using CQRS_Project.Domain.Entities;
using CQRS_Project.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Project.Application.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
    {
        private readonly AppDbContext _context;

        public GetProductsQueryHandler(AppDbContext context)
        {
            _context = context;
        }



        public async Task<List<ProductDto>> Handle(
            GetProductsQuery request,
            CancellationToken cancellationToken)
        {
            var query = _context.Products.AsQueryable();

            if (request.SortBy == "price")
            {
                if (request.Descending)
                {
                    query = query.OrderByDescending(product => product.Price);
                }
                else
                {
                    query = query.OrderBy(product => product.Price);
                }
            }


            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                query = query.Where(product =>
                    product.Name.Contains(request.Search));
            }

            var products = await query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var productDtos = products.Select(product => new ProductDto
            {
                Name = product.Name,
                Price = product.Price
            }).ToList();

            return productDtos;
        }


    }
}