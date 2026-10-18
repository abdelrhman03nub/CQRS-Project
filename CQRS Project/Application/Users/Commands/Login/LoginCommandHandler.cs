
using CQRS_Project.Infrastructure.Data;
using CQRS_Project.Infrastructure.Authentication;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Project.Application.Users.Commands.Login
{
    public class LoginCommandHandler
        : IRequestHandler<LoginCommand, string>
    {
        private readonly AppDbContext _context;
        private readonly IJwtService _jwtService;

        public LoginCommandHandler(
            AppDbContext context,
            IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<string> Handle(
            LoginCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(
                    u => u.Email == request.Email,
                    cancellationToken);

            if (user == null)
            {
                throw new UnauthorizedAccessException(
                    "Invalid email or password.");
            }

            var isPasswordValid =
                BCrypt.Net.BCrypt.Verify(
                    request.Password,
                    user.PasswordHash);

            if (!isPasswordValid)
            {
                throw new UnauthorizedAccessException(
                    "Invalid email or password.");
            }

            return _jwtService.GenerateToken(user);
        }
    }
}
