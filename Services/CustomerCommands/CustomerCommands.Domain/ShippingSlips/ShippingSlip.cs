using CustomerCommands.Domain.Common;

namespace CustomerCommands.Domain.ShippingSlips
{
    public class ShippingSlip : EntityBase
    {
        public ShippingSlip(
            Guid id,
            Guid customerId,
            Guid purchaseOrderId,
            string shippingAddress,
            string billTo)
        {
            Id = id;
            CustomerId = customerId;
            PurchaseOrderId = purchaseOrderId;
            ShippingAddress = shippingAddress;
            BillTo = billTo;
        }

        public Guid CustomerId { get; private set; }
        public Guid PurchaseOrderId { get; private set; }
        public string ShippingAddress { get; private set; }
        public string BillTo { get; private set; }
        public ICollection<ShippingSlipItem> ShippingSlipItems { get; private set; } = new HashSet<ShippingSlipItem>();

        public void AddSlipItem(ShippingSlipItem shippingSlipItem)
        {
            ShippingSlipItems.Add(shippingSlipItem);
        }
    }
}
