
namespace EventBus.Messages.IntegrationEvents
{
    public class DataSyncIntegrationEvent : IntegrationBaseEvent
    {
        public DataSyncIntegrationEvent(Guid id) : base(id)
        {
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
