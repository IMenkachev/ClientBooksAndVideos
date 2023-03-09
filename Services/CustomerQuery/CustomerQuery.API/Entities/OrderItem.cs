namespace CustomerQuery.API.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public int? Quantity { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? MembershipId { get; set; }
        public string Name { get; set; } 
    }
}
