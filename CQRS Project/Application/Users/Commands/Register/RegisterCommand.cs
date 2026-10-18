
using MediatR;

namespace CQRS_Project.Application.Users.Commands.Register
{
    public record RegisterCommand(
        string Name,
        string Email,
        string Password
    ) : IRequest<int>;
}
