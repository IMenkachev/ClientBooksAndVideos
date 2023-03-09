namespace EventBus.Messages.IntegrationEvents
{
    public class ShippingSlipCreatedIntegrationEvent : IntegrationBaseEvent
    {
        public ShippingSlipCreatedIntegrationEvent(Guid id) : base(id)
        {
        }

        public Guid CustomerId { get; set; }
        public Guid PurchaseOrderId { get; set; }
        public string ShippingAddress { get; set; }
        public string BillTo { get; set; }
    }
}