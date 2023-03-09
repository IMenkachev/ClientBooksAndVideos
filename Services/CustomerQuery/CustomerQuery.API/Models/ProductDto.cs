namespace CustomerQuery.API.Models
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int ProductType { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Discriminator { get; set; }
        public int SizeInMb { get; set; }
        public int Quantity { get; set; }
    }
}
