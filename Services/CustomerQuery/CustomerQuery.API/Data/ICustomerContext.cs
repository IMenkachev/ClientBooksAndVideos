using CustomerQuery.API.Entities;
using MongoDB.Driver;

namespace CustomerQuery.API.Data
{
    public interface ICustomerContext
    {
        IMongoCollection<Customer> Customers { get; }
    }
}
