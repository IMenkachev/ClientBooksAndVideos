using DatabaseSynchronization.Models;
using MongoDB.Driver;

namespace DatabaseSynchronization.Persistence
{
    public interface IBooksAndVideosContext
    {
        IMongoCollection<CustomerDto> Customers { get; }
        IMongoCollection<MembershipDto> Memberships { get; }
        IMongoCollection<ProductDto> Products { get; }
        IMongoCollection<OrderDto> Orders { get; }
        IMongoCollection<OrderItemDto> OrderItems { get; }
        IMongoCollection<ShippingSlipDto> ShippingSlips { get; }
    }
}
