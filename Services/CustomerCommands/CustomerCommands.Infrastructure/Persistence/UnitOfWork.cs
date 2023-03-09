using CustomerCommands.Application.Contracts.Persistence;
using CustomerCommands.Infrastructure.Repositories;

namespace CustomerCommands.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BooksAndVideosContext _context;
        private CustomerRepository? _customerRepository;
        private ProductRepository? _productRepository;
        private DigitalProductRepository? _digitalProductRepository;
        private PhysicalProductRepository? _physicalProductRepository;
        private MembershipRepository? _membershipRepository;
        private IOrderRepository? _orderRepository;
        private ShippingSlipRepository? _shippingSlipRepository;

        public UnitOfWork(BooksAndVideosContext context)
        {
            _context = context;
        }

        public ICustomerRepository Customers => 
            _customerRepository ??= new CustomerRepository(_context);

        public IProductRepository Products => 
            _productRepository ??= new ProductRepository(_context);

        public IDigitalProductRepository DigitalProducts => 
            _digitalProductRepository ??= new DigitalProductRepository(_context);

        public IPhysicalProductRepository PhysicalProducts => 
            _physicalProductRepository ??= new PhysicalProductRepository(_context);

        public IMembershipRepository Memberships => 
            _membershipRepository ??= new MembershipRepository(_context);

        public IOrderRepository Orders => 
            _orderRepository ??= new OrderRepository(_context);

        public IShippingSlipRepository ShippingSlips => 
            _shippingSlipRepository ??= new ShippingSlipRepository(_context);

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
