namespace CustomerQuery.API.Entities
{
    public class ShippingSlip
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string ShippingAddress { get; set; }
        public string BillTo { get; set; }
        public Guid PurchaseOrderId { get; set; }
        
        
    }
}
