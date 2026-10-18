
using CQRS_Project.Domain.Entities;

namespace CQRS_Project.Infrastructure.Authentication
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
