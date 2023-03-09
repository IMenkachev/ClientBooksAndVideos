namespace CustomerQuery.API.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Guid CustomerId { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
