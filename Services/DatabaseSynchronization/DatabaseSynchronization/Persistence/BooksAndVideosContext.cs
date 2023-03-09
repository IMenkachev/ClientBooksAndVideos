using DatabaseSynchronization.Models;
using MongoDB.Driver;

namespace DatabaseSynchronization.Persistence
{
    public class BooksAndVideosContext : IBooksAndVideosContext
    {
        public BooksAndVideosContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Customers = database.GetCollection<CustomerDto>("Customers");
            Memberships = database.GetCollection<MembershipDto>("Memberships");
            Products = database.GetCollection<ProductDto>("Products");
            Orders = database.GetCollection<OrderDto>("Orders");
            OrderItems = database.GetCollection<OrderItemDto>("OrderItems");
            ShippingSlips = database.GetCollection<ShippingSlipDto>("ShippingSlips");
        }
        public IMongoCollection<CustomerDto> Customers { get; }
        public IMongoCollection<MembershipDto> Memberships { get; }
        public IMongoCollection<ProductDto> Products { get; }
        public IMongoCollection<OrderDto> Orders { get; }
        public IMongoCollection<OrderItemDto> OrderItems { get; }
        public IMongoCollection<ShippingSlipDto> ShippingSlips { get; }
    }
}
