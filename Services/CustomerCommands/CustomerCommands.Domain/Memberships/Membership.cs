using CustomerCommands.Domain.Common;

namespace CustomerCommands.Domain.Memberships
{
    public class Membership : EntityBase
    {
        public Membership(
            Guid id,
            string name,
            decimal price) 
        {
            Id = id;
            Name = name;
            Price = price;
        }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
    }
}
