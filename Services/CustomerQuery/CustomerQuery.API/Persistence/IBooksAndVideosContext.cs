using CustomerQuery.API.Entities;
using MongoDB.Driver;

namespace CustomerQuery.API.Persistence
{
    public interface IBooksAndVideosContext
    {
        IMongoCollection<Customer> Customers { get; }
        IMongoCollection<Membership> Memberships { get; }
        IMongoCollection<Order> Orders { get; }
        IMongoCollection<OrderItem> OrderItems { get; }
        IMongoCollection<Product> Products { get; }
        IMongoCollection<ShippingSlip> ShippingSlips { get; }
    }
}
