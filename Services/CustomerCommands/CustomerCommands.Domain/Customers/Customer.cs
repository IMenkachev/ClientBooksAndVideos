using CustomerCommands.Domain.Common;
using CustomerCommands.Domain.Memberships;
using CustomerCommands.Domain.Orders;
using CustomerCommands.Domain.Products;

namespace CustomerCommands.Domain.Customers
{
    public class Customer : EntityBase
    {
        public Customer(
            Guid id,
            string firstName,
            string lastName) 
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Guid? MembershipId { get; private set; }
        public Membership? Membership { get; private set; }

        public ICollection<Product> Products { get; private set; } = new HashSet<Product>();
        public ICollection<Order> Orders { get; private set; } = new HashSet<Order>();
      
        public void UpdateCustomer(
            Guid id,
            string firstName, 
            string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        
        public void AddProducts(List<Product> products)
        {
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }

        public void UpdateMembership(Membership? membership)
        {
            MembershipId = membership.Id;
            Membership = membership;
        }

    }
}
