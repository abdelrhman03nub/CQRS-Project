using MediatR;

namespace CQRS_Project.Application.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}