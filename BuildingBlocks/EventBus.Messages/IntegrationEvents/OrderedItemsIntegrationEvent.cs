namespace EventBus.Messages.IntegrationEvents
{
    public class OrderedItemsIntegrationEvent : IntegrationBaseEvent
    {
        public OrderedItemsIntegrationEvent(Guid id) : base(id)
        {
        }

        public string Name { get; set; }
        public int? Quantity { get; set; }

        public Guid? MembershipId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? OrderId { get; set; }
    }
}
