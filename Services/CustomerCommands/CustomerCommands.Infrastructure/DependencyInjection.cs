using CustomerCommands.Application.Contracts.Persistence;
using CustomerCommands.Infrastructure.Persistence;
using CustomerCommands.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerCommands.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BooksAndVideosContext>(options => 
               options.UseSqlServer(configuration.GetConnectionString("CustomerConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IMembershipRepository, MembershipRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPhysicalProductRepository, PhysicalProductRepository>();
            services.AddScoped<IDigitalProductRepository, DigitalProductRepository>();
            services.AddScoped<IShippingSlipRepository, ShippingSlipRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
