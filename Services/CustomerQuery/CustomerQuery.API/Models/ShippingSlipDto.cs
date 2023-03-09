namespace CustomerQuery.API.Models
{
    public class ShippingSlipDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string ShippingAddress { get; set; }
        public string BillTo { get; set; }
        public Guid PurchaseOrderId { get; set; }
    }
}
