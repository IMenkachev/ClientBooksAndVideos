using DatabaseSynchronization.Persistence;
using System.Reflection;

namespace DatabaseSynchronization
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabaseSynchronizationServices(this IServiceCollection services)
        {
            services.AddScoped<IBooksAndVideosContext, BooksAndVideosContext>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
