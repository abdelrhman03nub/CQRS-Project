
using MediatR;

namespace CQRS_Project.Application.Users.Commands.Login
{
    public record LoginCommand(
        string Email,
        string Password
    ) : IRequest<string>;
}
