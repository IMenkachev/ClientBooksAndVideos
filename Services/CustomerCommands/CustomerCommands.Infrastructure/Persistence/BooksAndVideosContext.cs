using CustomerCommands.Domain.Customers;
using CustomerCommands.Domain.Memberships;
using CustomerCommands.Domain.Orders;
using CustomerCommands.Domain.Products;
using CustomerCommands.Domain.ShippingSlips;
using Microsoft.EntityFrameworkCore;

namespace CustomerCommands.Infrastructure.Persistence
{
    public class BooksAndVideosContext : DbContext
    {
        public BooksAndVideosContext(DbContextOptions<BooksAndVideosContext> options) : base(options)
        {
        }

        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Membership>? Memberships { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<DigitalProduct>? DigitalProducts { get; set; }
        public DbSet<PhysicalProduct>? PhysycalProducts { get; set; }
        public DbSet<ShippingSlip>? ShippingSlips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BooksAndVideosContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
