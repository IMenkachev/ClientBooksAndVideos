
namespace CustomerCommands.Domain.Products
{
    public class DigitalProduct : Product
    {
        public DigitalProduct(
            Guid id, 
            string name, 
            ProductType productType, 
            string description, 
            decimal price,
            int sizeInMb) 
            : base(id, name, productType, description, price)
        {
            SizeInMb = sizeInMb;
        }

        public int SizeInMb { get; private set; }
    }
}
