using CQRS_Project.Application.DTOs;
using MediatR;

namespace CQRS_Project.Application.Products.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<List<ProductDto>>
    {
        public string? Search { get; set; }
        public string? SortBy { get; set; }

        public bool Descending { get; set; } = false;
        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}