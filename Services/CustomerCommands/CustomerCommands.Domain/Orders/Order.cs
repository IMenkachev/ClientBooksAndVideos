using CustomerCommands.Domain.Common;
using CustomerCommands.Domain.Customers;

namespace CustomerCommands.Domain.Orders
{
    public class Order : EntityBase
    {
        public Order(
            Guid id,
            decimal totalPrice,
            string deliveryAddress,
            DateTime purchaseDate, 
            Guid customerId
            ) 
        {
            Id = id;
            TotalPrice = totalPrice;
            DeliveryAddress = deliveryAddress;
            PurchaseDate = purchaseDate;
            CustomerId = customerId;
        }

        public decimal TotalPrice { get; private set; }
        public string DeliveryAddress { get; private set; }
        public DateTime PurchaseDate { get; private set; }

        public Customer? Customer { get; private set; }
        public Guid CustomerId { get; private set; }

        public ICollection<OrderItem> OrderItems { get; private set; } = new HashSet<OrderItem>();
    }
}
