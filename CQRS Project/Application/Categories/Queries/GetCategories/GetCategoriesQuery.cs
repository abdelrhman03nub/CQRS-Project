
using CQRS_Project.Domain.Entities;
using MediatR;

namespace CQRS_Project.Application.Categories.Queries.GetCategories
{
    public record GetCategoriesQuery : IRequest<List<Category>>;
}
