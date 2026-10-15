
using MediatR;

namespace CQRS_Project.Application.Categories.Commands.CreateCategory
{
    public record CreateCategoryCommand(string Name) : IRequest<int>;
}
