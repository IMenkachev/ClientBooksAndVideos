using CustomerQuery.API.Contracts;
using CustomerQuery.API.Persistence;
using CustomerQuery.API.Repositories;
using MediatR;

namespace CustomerQuery.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCustomerQueryServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program).Assembly);
            services.AddMediatR(typeof(Program).Assembly);

            services.AddSingleton(typeof(IBooksAndVideosContext), typeof(BooksAndVideosContext));
            services.AddScoped(typeof(ICustomerRepository), typeof(CustomerRepository));
            services.AddScoped(typeof(IMembershipRepository), typeof(MembershipRepository));
            services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
            services.AddScoped(typeof(IOrderItemRepository), typeof(OrderItemRepository));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(IShippingSlipRepository), typeof(ShippingSlipRepository));

            return services;
        }
    }
}
