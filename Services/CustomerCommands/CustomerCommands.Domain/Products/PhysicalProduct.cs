
namespace CustomerCommands.Domain.Products
{
    public class PhysicalProduct : Product
    {
        public PhysicalProduct(
            Guid id, 
            string name, 
            ProductType productType, 
            string description, 
            decimal price,
            int quantity) 
            : base(id, name, productType, description, price)
        {
            Quantity = quantity;
        }

        public int Quantity { get; private set; }

        public void ReduceQuantity(int count)
        {
            if (Quantity < count) 
            {
                throw new ArgumentException($"{nameof(count)} should be greater or equal to {nameof(Quantity)}");
            }

            Quantity -= count;
        }
    }
}
