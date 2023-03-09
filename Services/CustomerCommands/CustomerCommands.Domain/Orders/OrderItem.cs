using CustomerCommands.Domain.Common;
using CustomerCommands.Domain.Memberships;
using CustomerCommands.Domain.Products;

namespace CustomerCommands.Domain.Orders
{
    public class OrderItem : EntityBase
    {
        public OrderItem(
            Guid id,
            string name,
            int? quantity,
            Guid? membershipId,
            Guid? productId) 
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            MembershipId = membershipId;
            ProductId = productId;
        }

        public string Name { get; private set; }
        public int? Quantity { get; private set; }

        public Guid? MembershipId { get; private set; }
        public Membership? Membership { get; private set; }
        public Guid? ProductId { get; private set; }
        public Product? Product { get; private set; }
        public Guid? OrderId { get; private set; }
        public Order? Order { get; private set; } 
    }
}
