
namespace EventBus.Messages.IntegrationEvents
{
    public class CustomerAddedIntegrationEvent : IntegrationBaseEvent
    {
        public CustomerAddedIntegrationEvent(Guid id) : base(id)
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
