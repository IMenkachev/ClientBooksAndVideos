using CustomerCommands.Domain.Common;
using CustomerCommands.Domain.Customers;

namespace CustomerCommands.Domain.Products
{
    public abstract class Product : EntityBase
    {
        public Product(
            Guid id,
            string name,
            ProductType productType,
            string description,
            decimal price) 
        {
            Id = id;
            Name = name;
            ProductType = productType;
            Description = description;
            Price = price;
        }

        public string Name { get; private set; }
        public ProductType ProductType { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public ICollection<Customer> Customers { get; private set; } = new HashSet<Customer>();
    }
}
