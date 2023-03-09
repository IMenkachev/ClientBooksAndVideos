using DatabaseSynchronization.EventBusConsumer;
using EventBus.Messages.Common;
using MassTransit;

namespace DatabaseSynchronization
{
    public static class MassTransitServiceRegistration
    {
        public static IServiceCollection AddMassTransitServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add consumers
            services.AddScoped<GetCustomersConsumer>();
            services.AddScoped<CustomerUpdatedConsumer>();
            services.AddScoped<CustomerAddedConsumer>();
            services.AddScoped<CustomerDeletedConsumer>();
            services.AddScoped<OrderCreatedConsumer>();
            services.AddScoped<OrderedItemsConsumer>();
            services.AddScoped<ShippingSlipCreatedConsumer>();

            // MassTransit-RabbitMQ Configuration
            services.AddMassTransit(config =>
            {
                config.AddConsumer<GetCustomersConsumer>();
                config.AddConsumer<CustomerUpdatedConsumer>();
                config.AddConsumer<CustomerAddedConsumer>();
                config.AddConsumer<CustomerDeletedConsumer>();
                config.AddConsumer<OrderCreatedConsumer>();
                config.AddConsumer<OrderedItemsConsumer>();
                config.AddConsumer<ShippingSlipCreatedConsumer>();

                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(configuration["EventBusSettings:HostAddress"]);
                    cfg.ReceiveEndpoint(EventBusConstants.CustomersQueue, c =>
                    {
                        c.ConfigureConsumer<GetCustomersConsumer>(ctx);
                        c.ConfigureConsumer<CustomerUpdatedConsumer>(ctx);
                        c.ConfigureConsumer<CustomerAddedConsumer>(ctx);
                        c.ConfigureConsumer<CustomerDeletedConsumer>(ctx);
                        c.ConfigureConsumer<OrderCreatedConsumer>(ctx);
                        c.ConfigureConsumer<OrderedItemsConsumer>(ctx);
                        c.ConfigureConsumer<ShippingSlipCreatedConsumer>(ctx);
                    });
                });
            });

            return services;
        }
    }
}
