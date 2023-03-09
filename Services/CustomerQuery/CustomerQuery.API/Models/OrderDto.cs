namespace CustomerQuery.API.Models
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Guid CustomerId { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
