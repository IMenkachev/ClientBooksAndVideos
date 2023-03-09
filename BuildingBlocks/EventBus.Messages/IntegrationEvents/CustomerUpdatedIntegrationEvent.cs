
namespace EventBus.Messages.IntegrationEvents
{
    public class CustomerUpdatedIntegrationEvent : IntegrationBaseEvent
    {
        public CustomerUpdatedIntegrationEvent(Guid id) : base(id)
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
