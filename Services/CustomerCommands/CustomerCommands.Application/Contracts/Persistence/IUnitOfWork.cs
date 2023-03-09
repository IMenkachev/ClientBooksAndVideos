namespace CustomerCommands.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IProductRepository Products { get; }
        IDigitalProductRepository DigitalProducts { get; }
        IPhysicalProductRepository PhysicalProducts { get; }
        IMembershipRepository Memberships { get; }
        IOrderRepository Orders { get; }
        IShippingSlipRepository ShippingSlips { get; }

        Task SaveChangesAsync();
    }
}
