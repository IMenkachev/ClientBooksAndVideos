using DatabaseSynchronization.Synchronization;
using EventBus.Messages.IntegrationEvents;
using MassTransit;

namespace DatabaseSynchronization.EventBusConsumer
{
    public class GetCustomersConsumer : IConsumer<DataSyncIntegrationEvent>
    {
        public GetCustomersConsumer()
        {
        }

        public async Task Consume(ConsumeContext<DataSyncIntegrationEvent> context)
        {
#if NET6_0
            SqlServerToMongoDbSync.Sync();
#else
            MongoDbToSqlServerSync.Sync();
#endif
        }
    }
}
