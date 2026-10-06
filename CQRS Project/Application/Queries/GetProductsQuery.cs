using CQRS_Project.Domain.Entities;
using MediatR;

namespace CQRS_Project.Application.Queries
{
    public class GetProductsQuery : IRequest<List<Product>>
    {
    }
}