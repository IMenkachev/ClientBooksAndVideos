namespace EventBus.Messages.IntegrationEvents
{
    public class CustomerDeletedIntegrationEvent : IntegrationBaseEvent
    {
        public CustomerDeletedIntegrationEvent(Guid id) : base(id)
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
