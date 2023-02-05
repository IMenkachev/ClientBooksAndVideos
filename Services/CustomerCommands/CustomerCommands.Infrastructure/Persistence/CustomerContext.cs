using CustomerCommands.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerCommands.Infrastructure.Persistence
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
