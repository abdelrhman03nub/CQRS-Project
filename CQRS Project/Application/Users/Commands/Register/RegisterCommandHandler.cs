
using CQRS_Project.Application.Common.Exceptions;
using CQRS_Project.Domain.Entities;
using CQRS_Project.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace CQRS_Project.Application.Users.Commands.Register
{
    public class RegisterCommandHandler
        : IRequestHandler<RegisterCommand, int>
    {
        private readonly AppDbContext _context;

        public RegisterCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(
            RegisterCommand request,
            CancellationToken cancellationToken)
        {
            var emailExists = await _context.Users
                .AnyAsync(u => u.Email == request.Email,
                    cancellationToken);

            if (emailExists)
            {
                throw new ConflictException(
                    "Email is already registered.");
            }

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(
                    request.Password),
                Role = "Customer"
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
