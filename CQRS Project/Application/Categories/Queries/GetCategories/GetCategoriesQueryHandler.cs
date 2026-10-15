
using CQRS_Project.Domain.Entities;
using CQRS_Project.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Project.Application.Categories.Queries.GetCategories
{
    public class GetCategoriesQueryHandler
        : IRequestHandler<GetCategoriesQuery, List<Category>>
    {
        private readonly AppDbContext _context;

        public GetCategoriesQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> Handle(
            GetCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Categories
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
