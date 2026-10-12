using CQRS_Project.Application.DTOs;
using MediatR;


namespace CQRS_Project.Application.Queries

{
    public class GetProductByIdQuery : IRequest<ProductDto?>
    {
        public int Id { get; set; }
    }
}
