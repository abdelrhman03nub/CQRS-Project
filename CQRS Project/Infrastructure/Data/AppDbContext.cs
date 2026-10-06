using CQRS_Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Project.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}