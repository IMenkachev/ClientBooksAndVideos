using CustomerQuery.API.Entities;
using MongoDB.Driver;

namespace CustomerQuery.API.Persistence
{
    public class BooksAndVideosContext : IBooksAndVideosContext
    {
        public BooksAndVideosContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Customers = database.GetCollection<Customer>("Customers");
            Memberships = database.GetCollection<Membership>("Memberships");
            Orders = database.GetCollection<Order>("Orders");
            OrderItems = database.GetCollection<OrderItem>("OrderItems");
            Products = database.GetCollection<Product>("Products");
            ShippingSlips = database.GetCollection<ShippingSlip>("ShippingSlips");
        }

        public IMongoCollection<Customer> Customers { get; }

        public IMongoCollection<Membership> Memberships { get; }

        public IMongoCollection<Order> Orders { get; }

        public IMongoCollection<OrderItem> OrderItems { get; }

        public IMongoCollection<Product> Products { get; }

        public IMongoCollection<ShippingSlip> ShippingSlips { get; }
    }
}
