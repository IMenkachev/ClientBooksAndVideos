namespace EventBus.Messages.IntegrationEvents
{
    public class OrderCreatedIntegrationEvent : IntegrationBaseEvent
    {
        public OrderCreatedIntegrationEvent(Guid id) : base(id)
        {
        }

        public DateTime PurchaseDate { get; set; }
        public Guid CustomerId { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
